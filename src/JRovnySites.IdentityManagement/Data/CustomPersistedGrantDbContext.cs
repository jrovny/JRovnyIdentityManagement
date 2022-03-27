using System;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace JRovnySites.IdentityManagement.Data
{
    public class CustomPersistedGrantDbContext : PersistedGrantDbContext<CustomPersistedGrantDbContext>
    {
        public CustomPersistedGrantDbContext(DbContextOptions options, OperationalStoreOptions storeOptions)
            : base(options, storeOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.DeviceFlowCodes", b =>
                {
                    b.Property<string>("UserCode")
                        .HasColumnName("user_code")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<string>("ClientId")
                        .HasColumnName("client_id")
                        .IsRequired()
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnName("creation_time")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Data")
                        .HasColumnName("data")
                        .IsRequired()
                        .HasColumnType("character varying(50000)")
                        .HasMaxLength(50000);

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<string>("DeviceCode")
                        .HasColumnName("device_code")
                        .IsRequired()
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("Expiration")
                        .HasColumnName("expiration")
                        .IsRequired()
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("SessionId")
                        .HasColumnName("session_id")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("SubjectId")
                        .HasColumnName("subject_id")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.HasKey("UserCode").HasName("pk_user_code");

                    b.HasIndex("DeviceCode").HasName("ix_device_code")
                        .IsUnique();

                    b.HasIndex("Expiration").HasName("ix_expiration");

                    b.ToTable("device_code");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.PersistedGrant", b =>
                {
                    b.Property<string>("Key")
                        .HasColumnName("key")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<string>("ClientId")
                        .HasColumnName("client_id")
                        .IsRequired()
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("ConsumedTime")
                        .HasColumnName("consumed_time")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnName("creation_time")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Data")
                        .HasColumnName("data")
                        .IsRequired()
                        .HasColumnType("character varying(50000)")
                        .HasMaxLength(50000);

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("Expiration")
                        .HasColumnName("expiration")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("SessionId")
                        .HasColumnName("session_id")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("SubjectId")
                        .HasColumnName("subject_id")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Type")
                        .HasColumnName("type")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.HasKey("Key").HasName("pk_key");

                    b.HasIndex("Expiration").HasName("ix_expiration");

                    b.HasIndex("SubjectId", "ClientId", "Type").HasName("ix_subject_id_client_id_type");

                    b.HasIndex("SubjectId", "SessionId", "Type").HasName("ix_subject_id_session_id_type");

                    b.ToTable("persisted_grant");
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
