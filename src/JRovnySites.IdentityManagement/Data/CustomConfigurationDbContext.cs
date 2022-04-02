using System;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace JRovnySites.IdentityManagement.Data
{
    public class CustomConfigurationDbContext : ConfigurationDbContext<CustomConfigurationDbContext>
    {
        public CustomConfigurationDbContext
        (DbContextOptions<CustomConfigurationDbContext> options,
        ConfigurationStoreOptions storeOptions) : base(options, storeOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiResource", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AllowedAccessTokenSigningAlgorithms")
                        .HasColumnName("allowed_access_token_signing_algorithms")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("Created")
                        .HasColumnName("created")
                        .HasDefaultValueSql("now()")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("character varying(1000)")
                        .HasMaxLength(1000);

                    b.Property<string>("DisplayName")
                        .HasColumnName("display_name")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<bool>("Enabled")
                        .HasDefaultValue(true)
                        .HasColumnName("enabled")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastAccessed")
                        .HasColumnName("last_accessed")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .IsRequired()
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<bool>("NonEditable")
                        .HasDefaultValue(false)
                        .HasColumnName("non_editable")
                        .HasColumnType("boolean");

                    b.Property<bool>("ShowInDiscoveryDocument")
                        .HasDefaultValue(false)
                        .HasColumnName("show_in_discovery_document")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("Updated")
                        .HasColumnName("updated")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id").HasName("pk_api_resource_id");

                    b.HasIndex("Name").HasName("ix_api_resource_name")
                        .IsUnique();

                    b.ToTable("api_resource");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiResourceClaim", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ApiResourceId")
                        .HasColumnName("api_resource_id")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .HasColumnName("type")
                        .IsRequired()
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id").HasName("pk_api_resource_claim_id");

                    b.HasIndex("ApiResourceId").HasName("ix_api_resource_claim_api_resource_id");

                    b.ToTable("api_resource_claim");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiResourceProperty", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ApiResourceId")
                        .HasColumnName("api_resource_id")
                        .HasColumnType("integer");

                    b.Property<string>("Key")
                        .HasColumnName("key")
                        .IsRequired()
                        .HasColumnType("character varying(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Value")
                        .HasColumnName("value")
                        .IsRequired()
                        .HasColumnType("character varying(2000)")
                        .HasMaxLength(2000);

                    b.HasKey("Id").HasName("pk_api_resource_property_id");

                    b.HasIndex("ApiResourceId").HasName("ix_api_resource_property_api_resource_id");

                    b.ToTable("api_resource_property");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiResourceScope", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ApiResourceId")
                        .HasColumnName("api_resource_id")
                        .HasColumnType("integer");

                    b.Property<string>("Scope")
                        .HasColumnName("scope")
                        .IsRequired()
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id").HasName("pk_api_resource_scope_id");

                    b.HasIndex("ApiResourceId").HasName("ix_api_resource_scope_api_resource_id");

                    b.ToTable("api_resource_scope");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiResourceSecret", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ApiResourceId")
                        .HasColumnName("api_resource_id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Created")
                        .HasColumnName("created")
                        .HasDefaultValueSql("now()")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("character varying(1000)")
                        .HasMaxLength(1000);

                    b.Property<DateTime?>("Expiration")
                        .HasColumnName("expiration")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Type")
                        .HasColumnName("type")
                        .IsRequired()
                        .HasColumnType("character varying(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Value")
                        .HasColumnName("value")
                        .IsRequired()
                        .HasColumnType("character varying(4000)")
                        .HasMaxLength(4000);

                    b.HasKey("Id").HasName("pk_api_resource_secret_id");

                    b.HasIndex("ApiResourceId").HasName("ix_api_resource_secret_api_resource_id");

                    b.ToTable("api_resource_secret");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiScope", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("character varying(1000)")
                        .HasMaxLength(1000);

                    b.Property<string>("DisplayName")
                        .HasColumnName("display_name")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<bool>("Emphasize")
                        .HasDefaultValue(false)
                        .HasColumnName("emphasize")
                        .HasColumnType("boolean");

                    b.Property<bool>("Enabled")
                        .HasDefaultValue(true)
                        .HasColumnName("enabled")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .IsRequired()
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<bool>("Required")
                        .HasDefaultValue(false)
                        .HasColumnName("required")
                        .HasColumnType("boolean");

                    b.Property<bool>("ShowInDiscoveryDocument")
                        .HasDefaultValue(false)
                        .HasColumnName("show_in_discovery_document")
                        .HasColumnType("boolean");

                    b.HasKey("Id").HasName("pk_api_scope_id");

                    b.HasIndex("Name").HasName("ix_api_scope_name")
                        .IsUnique();

                    b.ToTable("api_scope");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiScopeClaim", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ScopeId")
                        .HasColumnName("scope_id")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .HasColumnName("type")
                        .IsRequired()
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id").HasName("pk_api_scope_claim_id");

                    b.HasIndex("ScopeId").HasName("ix_api_scope_claim_scope_id");

                    b.ToTable("api_scope_claim");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiScopeProperty", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Key")
                        .HasColumnName("key")
                        .IsRequired()
                        .HasColumnType("character varying(250)")
                        .HasMaxLength(250);

                    b.Property<int>("ScopeId")
                        .HasColumnName("scope_id")
                        .HasColumnType("integer");

                    b.Property<string>("Value")
                        .HasColumnName("value")
                        .IsRequired()
                        .HasColumnType("character varying(2000)")
                        .HasMaxLength(2000);

                    b.HasKey("Id").HasName("pk_api_scope_property_id");

                    b.HasIndex("ScopeId").HasName("ix_api_scope_property_scope_id");

                    b.ToTable("api_scope_property");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AbsoluteRefreshTokenLifetime")
                        .HasDefaultValue(2592000)
                        .HasColumnName("absolute_refresh_token_lifetime")
                        .HasColumnType("integer");

                    b.Property<int>("AccessTokenLifetime")
                        .HasDefaultValue(3600)
                        .HasColumnName("access_token_lifetime")
                        .HasColumnType("integer");

                    b.Property<int>("AccessTokenType")
                        .HasDefaultValue(0) // AccessTokenType.Jwt
                        .HasColumnName("access_token_type")
                        .HasColumnType("integer");

                    b.Property<bool>("AllowAccessTokensViaBrowser")
                        .HasDefaultValue(false)
                        .HasColumnName("allow_access_tokens_via_browser")
                        .HasColumnType("boolean");

                    b.Property<bool>("AllowOfflineAccess")
                        .HasDefaultValue(false)
                        .HasColumnName("allow_offline_access")
                        .HasColumnType("boolean");

                    b.Property<bool>("AllowPlainTextPkce")
                        .HasDefaultValue(false)
                        .HasColumnName("allow_plain_text_pkce")
                        .HasColumnType("boolean");

                    b.Property<bool>("AllowRememberConsent")
                        .HasDefaultValue(false)
                        .HasColumnName("allow_remember_consent")
                        .HasColumnType("boolean");

                    b.Property<string>("AllowedIdentityTokenSigningAlgorithms")
                        .HasColumnName("allowed_identity_token_signing_algorithms")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("AlwaysIncludeUserClaimsInIdToken")
                        .HasDefaultValue(false)
                        .HasColumnName("always_include_user_claims_in_id_token")
                        .HasColumnType("boolean");

                    b.Property<bool>("AlwaysSendClientClaims")
                        .HasDefaultValue(false)
                        .HasColumnName("always_send_client_claims")
                        .HasColumnType("boolean");

                    b.Property<int>("AuthorizationCodeLifetime")
                        .HasDefaultValue(300)
                        .HasColumnName("authorization_code_lifetime")
                        .HasColumnType("integer");

                    b.Property<bool>("BackChannelLogoutSessionRequired")
                        .HasDefaultValue(true)
                        .HasColumnName("back_channel_logout_session_required")
                        .HasColumnType("boolean");

                    b.Property<string>("BackChannelLogoutUri")
                        .HasColumnName("back_channel_logout_uri")
                        .HasColumnType("character varying(2000)")
                        .HasMaxLength(2000);

                    b.Property<string>("ClientClaimsPrefix")
                        .HasDefaultValue("client_")
                        .HasColumnName("client_claims_prefix")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<string>("ClientId")
                        .HasColumnName("client_id")
                        .IsRequired()
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<string>("ClientName")
                        .HasColumnName("client_name")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<string>("ClientUri")
                        .HasColumnName("client_uri")
                        .HasColumnType("character varying(2000)")
                        .HasMaxLength(2000);

                    b.Property<int?>("ConsentLifetime")
                        .HasColumnName("consent_lifetime")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Created")
                        .HasColumnName("created")
                        .HasDefaultValueSql("now()")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("character varying(1000)")
                        .HasMaxLength(1000);

                    b.Property<int>("DeviceCodeLifetime")
                        .HasDefaultValue(300)
                        .HasColumnName("device_code_lifetime")
                        .HasColumnType("integer");

                    b.Property<bool>("EnableLocalLogin")
                        .HasDefaultValue(false)
                        .HasColumnName("enable_local_login")
                        .HasColumnType("boolean");

                    b.Property<bool>("Enabled")
                        .HasDefaultValue(true)
                        .HasColumnName("enabled")
                        .HasColumnType("boolean");

                    b.Property<bool>("FrontChannelLogoutSessionRequired")
                        .HasDefaultValue(true)
                        .HasColumnName("front_channel_logout_session_required")
                        .HasColumnType("boolean");

                    b.Property<string>("FrontChannelLogoutUri")
                        .HasColumnName("front_channel_logout_uri")
                        .HasColumnType("character varying(2000)")
                        .HasMaxLength(2000);

                    b.Property<int>("IdentityTokenLifetime")
                        .HasDefaultValue(300)
                        .HasColumnName("identity_token_lifetime")
                        .HasColumnType("integer");

                    b.Property<bool>("IncludeJwtId")
                        .HasDefaultValue(false)
                        .HasColumnName("include_jwt_id")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastAccessed")
                        .HasColumnName("last_accessed")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LogoUri")
                        .HasColumnName("logo_uri")
                        .HasColumnType("character varying(2000)")
                        .HasMaxLength(2000);

                    b.Property<bool>("NonEditable")
                        .HasDefaultValue(false)
                        .HasColumnName("non_editable")
                        .HasColumnType("boolean");

                    b.Property<string>("PairWiseSubjectSalt")
                        .HasColumnName("pair_wise_subject_salt")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<string>("ProtocolType")
                        .HasColumnName("protocol_type")
                        .HasDefaultValue("oidc")
                        .IsRequired()
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<int>("RefreshTokenExpiration")
                        .HasDefaultValue(1) // TokenExpiration.Absolute
                        .HasColumnName("refresh_token_expiration")
                        .HasColumnType("integer");

                    b.Property<int>("RefreshTokenUsage")
                        .HasDefaultValue(1) // TokenUsage.OneTimeOnly
                        .HasColumnName("refresh_token_usage")
                        .HasColumnType("integer");

                    b.Property<bool>("RequireClientSecret")
                        .HasDefaultValue(false)
                        .HasColumnName("require_client_secret")
                        .HasColumnType("boolean");

                    b.Property<bool>("RequireConsent")
                        .HasDefaultValue(false)
                        .HasColumnName("require_consent")
                        .HasColumnType("boolean");

                    b.Property<bool>("RequirePkce")
                        .HasDefaultValue(false)
                        .HasColumnName("require_pkce")
                        .HasColumnType("boolean");

                    b.Property<bool>("RequireRequestObject")
                        .HasDefaultValue(false)
                        .HasColumnName("require_request_object")
                        .HasColumnType("boolean");

                    b.Property<int>("SlidingRefreshTokenLifetime")
                        .HasDefaultValue(1296000)
                        .HasColumnName("sliding_refresh_token_lifetime")
                        .HasColumnType("integer");

                    b.Property<bool>("UpdateAccessTokenClaimsOnRefresh")
                        .HasDefaultValue(false)
                        .HasColumnName("update_access_token_claims_on_refresh")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("Updated")
                        .HasColumnName("updated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UserCodeType")
                        .HasColumnName("user_code_type")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<int?>("UserSsoLifetime")
                        .HasColumnName("user_sso_lifetime")
                        .HasColumnType("integer");

                    b.HasKey("Id").HasName("pk_client_id");

                    b.HasIndex("ClientId").HasName("ix_client_client_id")
                        .IsUnique();

                    b.ToTable("client");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientClaim", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ClientId")
                        .HasColumnName("client_id")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .HasColumnName("type")
                        .IsRequired()
                        .HasColumnType("character varying(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Value")
                        .HasColumnName("value")
                        .IsRequired()
                        .HasColumnType("character varying(250)")
                        .HasMaxLength(250);

                    b.HasKey("Id").HasName("pk_client_claim_id");

                    b.HasIndex("ClientId").HasName("ix_client_claim_client_id");

                    b.ToTable("client_claim");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientCorsOrigin", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ClientId")
                        .HasColumnName("client_id")
                        .HasColumnType("integer");

                    b.Property<string>("Origin")
                        .HasColumnName("origin")
                        .IsRequired()
                        .HasColumnType("character varying(150)")
                        .HasMaxLength(150);

                    b.HasKey("Id").HasName("pk_client_cors_origin_id");

                    b.HasIndex("ClientId").HasName("ix_client_cors_origin_client_id");

                    b.ToTable("client_cors_origin");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientGrantType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ClientId")
                        .HasColumnName("client_id")
                        .HasColumnType("integer");

                    b.Property<string>("GrantType")
                        .HasColumnName("grant_type")
                        .IsRequired()
                        .HasColumnType("character varying(250)")
                        .HasMaxLength(250);

                    b.HasKey("Id").HasName("pk_client_grant_type_id");

                    b.HasIndex("ClientId").HasName("ix_client_grant_type_client_id");

                    b.ToTable("client_grant_type");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientIdPRestriction", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ClientId")
                        .HasColumnName("client_id")
                        .HasColumnType("integer");

                    b.Property<string>("Provider")
                        .HasColumnName("provider")
                        .IsRequired()
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id").HasName("pk_client_idp_restriction_id");

                    b.HasIndex("ClientId").HasName("ix_client_idp_restriction_client_id");

                    b.ToTable("client_idp_restriction");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientPostLogoutRedirectUri", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ClientId")
                        .HasColumnName("client_id")
                        .HasColumnType("integer");

                    b.Property<string>("PostLogoutRedirectUri")
                        .HasColumnName("post_logout_redirect_uri")
                        .IsRequired()
                        .HasColumnType("character varying(2000)")
                        .HasMaxLength(2000);

                    b.HasKey("Id").HasName("pk_client_post_logout_redirect_uri_id");

                    b.HasIndex("ClientId").HasName("ix_client_post_logout_redirect_uri_client_id");

                    b.ToTable("client_post_logout_redirect_uri");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientProperty", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ClientId")
                        .HasColumnName("client_id")
                        .HasColumnType("integer");

                    b.Property<string>("Key")
                        .HasColumnName("key")
                        .IsRequired()
                        .HasColumnType("character varying(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Value")
                        .HasColumnName("value")
                        .IsRequired()
                        .HasColumnType("character varying(2000)")
                        .HasMaxLength(2000);

                    b.HasKey("Id").HasName("pk_client_property_id");

                    b.HasIndex("ClientId").HasName("ix_client_property_client_id");

                    b.ToTable("client_property");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientRedirectUri", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ClientId")
                        .HasColumnName("client_id")
                        .HasColumnType("integer");

                    b.Property<string>("RedirectUri")
                        .HasColumnName("redirect_uri")
                        .IsRequired()
                        .HasColumnType("character varying(2000)")
                        .HasMaxLength(2000);

                    b.HasKey("Id").HasName("pk_client_redirect_uri_id");

                    b.HasIndex("ClientId").HasName("ix_client_redirect_uri_client_id");

                    b.ToTable("client_redirect_uri");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientScope", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ClientId")
                        .HasColumnName("client_id")
                        .HasColumnType("integer");

                    b.Property<string>("Scope")
                        .HasColumnName("scope")
                        .IsRequired()
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id").HasName("pk_client_scope_id");

                    b.HasIndex("ClientId").HasName("ix_client_scope_client_id");

                    b.ToTable("client_scope");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientSecret", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ClientId")
                        .HasColumnName("client_id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Created")
                        .HasColumnName("created")
                        .HasDefaultValueSql("now()")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("character varying(2000)")
                        .HasMaxLength(2000);

                    b.Property<DateTime?>("Expiration")
                        .HasColumnName("expiration")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Type")
                        .HasColumnName("type")
                        .IsRequired()
                        .HasColumnType("character varying(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Value")
                        .HasColumnName("value")
                        .IsRequired()
                        .HasColumnType("character varying(4000)")
                        .HasMaxLength(4000);

                    b.HasKey("Id").HasName("pk_client_secret_id");

                    b.HasIndex("ClientId").HasName("ix_client_secret_client_id");

                    b.ToTable("client_secret");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.IdentityResource", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnName("created")
                        .HasDefaultValueSql("now()")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("character varying(1000)")
                        .HasMaxLength(1000);

                    b.Property<string>("DisplayName")
                        .HasColumnName("display_name")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<bool>("Emphasize")
                        .HasDefaultValue(false)
                        .HasColumnName("emphasize")
                        .HasColumnType("boolean");

                    b.Property<bool>("Enabled")
                        .HasDefaultValue(true)
                        .HasColumnName("enabled")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .IsRequired()
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<bool>("NonEditable")
                        .HasDefaultValue(false)
                        .HasColumnName("non_editable")
                        .HasColumnType("boolean");

                    b.Property<bool>("Required")
                        .HasDefaultValue(false)
                        .HasColumnName("required")
                        .HasColumnType("boolean");

                    b.Property<bool>("ShowInDiscoveryDocument")
                        .HasDefaultValue(false)
                        .HasColumnName("show_in_discovery_document")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("Updated")
                        .HasColumnName("updated")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id").HasName("pk_identity_resource_id");

                    b.HasIndex("Name").HasName("ix_identity_resource_name")
                        .IsUnique();

                    b.ToTable("identity_resource");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.IdentityResourceClaim", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("IdentityResourceId")
                        .HasColumnName("identity_resource_id")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .HasColumnName("type")
                        .IsRequired()
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id").HasName("pk_identity_resource_claim_id");

                    b.HasIndex("IdentityResourceId").HasName("ix_identity_resource_claim_identity_resource_id");

                    b.ToTable("identity_resource_claim");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.IdentityResourceProperty", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("IdentityResourceId")
                        .HasColumnName("identity_resource_id")
                        .HasColumnType("integer");

                    b.Property<string>("Key")
                        .HasColumnName("key")
                        .IsRequired()
                        .HasColumnType("character varying(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Value")
                        .HasColumnName("value")
                        .IsRequired()
                        .HasColumnType("character varying(2000)")
                        .HasMaxLength(2000);

                    b.HasKey("Id").HasName("pk_identity_resource_property_id");

                    b.HasIndex("IdentityResourceId").HasName("ix_identity_resource_property_identity_resource_id");

                    b.ToTable("identity_resource_property");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiResourceClaim", b =>
                {
                    b.HasOne("IdentityServer4.EntityFramework.Entities.ApiResource", "ApiResource")
                        .WithMany("UserClaims")
                        .HasForeignKey("ApiResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiResourceProperty", b =>
                {
                    b.HasOne("IdentityServer4.EntityFramework.Entities.ApiResource", "ApiResource")
                        .WithMany("Properties")
                        .HasForeignKey("ApiResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiResourceScope", b =>
                {
                    b.HasOne("IdentityServer4.EntityFramework.Entities.ApiResource", "ApiResource")
                        .WithMany("Scopes")
                        .HasForeignKey("ApiResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiResourceSecret", b =>
                {
                    b.HasOne("IdentityServer4.EntityFramework.Entities.ApiResource", "ApiResource")
                        .WithMany("Secrets")
                        .HasForeignKey("ApiResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiScopeClaim", b =>
                {
                    b.HasOne("IdentityServer4.EntityFramework.Entities.ApiScope", "Scope")
                        .WithMany("UserClaims")
                        .HasForeignKey("ScopeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ApiScopeProperty", b =>
                {
                    b.HasOne("IdentityServer4.EntityFramework.Entities.ApiScope", "Scope")
                        .WithMany("Properties")
                        .HasForeignKey("ScopeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientClaim", b =>
                {
                    b.HasOne("IdentityServer4.EntityFramework.Entities.Client", "Client")
                        .WithMany("Claims")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientCorsOrigin", b =>
                {
                    b.HasOne("IdentityServer4.EntityFramework.Entities.Client", "Client")
                        .WithMany("AllowedCorsOrigins")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientGrantType", b =>
                {
                    b.HasOne("IdentityServer4.EntityFramework.Entities.Client", "Client")
                        .WithMany("AllowedGrantTypes")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientIdPRestriction", b =>
                {
                    b.HasOne("IdentityServer4.EntityFramework.Entities.Client", "Client")
                        .WithMany("IdentityProviderRestrictions")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientPostLogoutRedirectUri", b =>
                {
                    b.HasOne("IdentityServer4.EntityFramework.Entities.Client", "Client")
                        .WithMany("PostLogoutRedirectUris")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientProperty", b =>
                {
                    b.HasOne("IdentityServer4.EntityFramework.Entities.Client", "Client")
                        .WithMany("Properties")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientRedirectUri", b =>
                {
                    b.HasOne("IdentityServer4.EntityFramework.Entities.Client", "Client")
                        .WithMany("RedirectUris")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientScope", b =>
                {
                    b.HasOne("IdentityServer4.EntityFramework.Entities.Client", "Client")
                        .WithMany("AllowedScopes")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.ClientSecret", b =>
                {
                    b.HasOne("IdentityServer4.EntityFramework.Entities.Client", "Client")
                        .WithMany("ClientSecrets")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.IdentityResourceClaim", b =>
                {
                    b.HasOne("IdentityServer4.EntityFramework.Entities.IdentityResource", "IdentityResource")
                        .WithMany("UserClaims")
                        .HasForeignKey("IdentityResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.IdentityResourceProperty", b =>
                {
                    b.HasOne("IdentityServer4.EntityFramework.Entities.IdentityResource", "IdentityResource")
                        .WithMany("Properties")
                        .HasForeignKey("IdentityResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                var createdDate = entity.AddProperty("CreatedDate", typeof(DateTime));
                createdDate.SetColumnName("created_date");
                createdDate.SetDefaultValueSql("now()");

                var modifiedDate = entity.AddProperty("ModifiedDate", typeof(DateTime));
                modifiedDate.SetColumnName("modified_date");
                modifiedDate.SetDefaultValueSql("now()");
            }
        }
    }
}
