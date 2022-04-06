using System.Reflection;
using IdentityServer4;
using JRovnySites.IdentityManagement.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace JRovnySites.IdentityManagement
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }
        private readonly IConfiguration _configuration;
        private readonly string _migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            _configuration = configuration;
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
                options.KnownNetworks.Clear();
                options.KnownProxies.Clear();
            });

            var connectionString = _configuration.GetConnectionString("Default");

            if (connectionString == null)
                throw new System.Exception("No connection string found");

            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));

            services.AddIdentity<ApplicationUser, IdentityRole<int>>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            var builder = services.AddIdentityServer(options =>
            {
                // see https://identityserver4.readthedocs.io/en/latest/topics/resources.html
                options.EmitStaticAudienceClaim = true;
            })
            .AddConfigurationStore<CustomConfigurationDbContext>(options =>
            {
                options.ConfigureDbContext = b => b.UseNpgsql(connectionString,
                    sql => sql.MigrationsAssembly(_migrationsAssembly));
            })
            .AddOperationalStore<CustomPersistedGrantDbContext>(options =>
            {
                options.ConfigureDbContext = b => b.UseNpgsql(connectionString,
                    sql => sql.MigrationsAssembly(_migrationsAssembly));
            });

            IConfigurationSection configurationSection =
                _configuration.GetSection("ApplicationSettings").GetSection("Google");
            var clientId = configurationSection.GetValue<string>("ClientId");
            var clientSecret = configurationSection.GetValue<string>("ClientSecret");

            services.AddAuthentication()
                .AddGoogle("Google", options =>
                {
                    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                    options.ClientId = clientId;
                    options.ClientSecret = clientSecret;
                });

            if (Environment.IsDevelopment())
            {
                builder.AddDeveloperSigningCredential();
            }
            else
            {
                string x509CertificatePath = _configuration["X509CertificatePath"];
                Log.Information($"X509CertificatePath: '{x509CertificatePath}'");
                if (string.IsNullOrWhiteSpace(x509CertificatePath))
                {
                    throw new System.Exception("No X509CertificatePath found");
                }
                builder.AddSigningCredential(X509CertificateManager.GetX509Certificate2(x509CertificatePath));
            }
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseForwardedHeaders();

            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseIdentityServer();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
