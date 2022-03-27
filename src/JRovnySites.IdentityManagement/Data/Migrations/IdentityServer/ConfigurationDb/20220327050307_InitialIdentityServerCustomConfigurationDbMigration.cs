using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace JRovnySites.IdentityManagement.Data.Migrations.IdentityServer.ConfigurationDb
{
    public partial class InitialIdentityServerCustomConfigurationDbMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "api_resource",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    display_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    allowed_access_token_signing_algorithms = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    show_in_discovery_document = table.Column<bool>(type: "boolean", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    last_accessed = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    non_editable = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()"),
                    modified_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_api_resource_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "api_scope",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    display_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    required = table.Column<bool>(type: "boolean", nullable: false),
                    emphasize = table.Column<bool>(type: "boolean", nullable: false),
                    show_in_discovery_document = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()"),
                    modified_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_api_scope_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "client",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    client_id = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    protocol_type = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    require_client_secret = table.Column<bool>(type: "boolean", nullable: false),
                    client_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    client_uri = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    logo_uri = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    require_consent = table.Column<bool>(type: "boolean", nullable: false),
                    allow_remember_consent = table.Column<bool>(type: "boolean", nullable: false),
                    always_include_user_claims_in_id_token = table.Column<bool>(type: "boolean", nullable: false),
                    require_pkce = table.Column<bool>(type: "boolean", nullable: false),
                    allow_plain_text_pkce = table.Column<bool>(type: "boolean", nullable: false),
                    require_request_object = table.Column<bool>(type: "boolean", nullable: false),
                    allow_access_tokens_via_browser = table.Column<bool>(type: "boolean", nullable: false),
                    front_channel_logout_uri = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    front_channel_logout_session_required = table.Column<bool>(type: "boolean", nullable: false),
                    back_channel_logout_uri = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    back_channel_logout_session_required = table.Column<bool>(type: "boolean", nullable: false),
                    allow_offline_access = table.Column<bool>(type: "boolean", nullable: false),
                    identity_token_lifetime = table.Column<int>(type: "integer", nullable: false),
                    allowed_identity_token_signing_algorithms = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    access_token_lifetime = table.Column<int>(type: "integer", nullable: false),
                    authorization_code_lifetime = table.Column<int>(type: "integer", nullable: false),
                    consent_lifetime = table.Column<int>(type: "integer", nullable: true),
                    absolute_refresh_token_lifetime = table.Column<int>(type: "integer", nullable: false),
                    sliding_refresh_token_lifetime = table.Column<int>(type: "integer", nullable: false),
                    refresh_token_usage = table.Column<int>(type: "integer", nullable: false),
                    update_access_token_claims_on_refresh = table.Column<bool>(type: "boolean", nullable: false),
                    refresh_token_expiration = table.Column<int>(type: "integer", nullable: false),
                    access_token_type = table.Column<int>(type: "integer", nullable: false),
                    enable_local_login = table.Column<bool>(type: "boolean", nullable: false),
                    include_jwt_id = table.Column<bool>(type: "boolean", nullable: false),
                    always_send_client_claims = table.Column<bool>(type: "boolean", nullable: false),
                    client_claims_prefix = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    pair_wise_subject_salt = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    last_accessed = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    user_sso_lifetime = table.Column<int>(type: "integer", nullable: true),
                    user_code_type = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    device_code_lifetime = table.Column<int>(type: "integer", nullable: false),
                    non_editable = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()"),
                    modified_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "identity_resource",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    display_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    required = table.Column<bool>(type: "boolean", nullable: false),
                    emphasize = table.Column<bool>(type: "boolean", nullable: false),
                    show_in_discovery_document = table.Column<bool>(type: "boolean", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    non_editable = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()"),
                    modified_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identity_resource_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "api_resource_claim",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    api_resource_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()"),
                    modified_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_api_resource_claim_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_api_resource_claim_api_resource_api_resource_id",
                        column: x => x.api_resource_id,
                        principalTable: "api_resource",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "api_resource_property",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    key = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    value = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    api_resource_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()"),
                    modified_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_api_resource_property_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_api_resource_property_api_resource_api_resource_id",
                        column: x => x.api_resource_id,
                        principalTable: "api_resource",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "api_resource_scope",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    scope = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    api_resource_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()"),
                    modified_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_api_resource_scope_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_api_resource_scope_api_resource_api_resource_id",
                        column: x => x.api_resource_id,
                        principalTable: "api_resource",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "api_resource_secret",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    value = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: false),
                    expiration = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    type = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    api_resource_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()"),
                    modified_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_api_resource_secret_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_api_resource_secret_api_resource_api_resource_id",
                        column: x => x.api_resource_id,
                        principalTable: "api_resource",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "api_scope_claim",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    scope_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()"),
                    modified_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_api_scope_claim_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_api_scope_claim_api_scope_scope_id",
                        column: x => x.scope_id,
                        principalTable: "api_scope",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "api_scope_property",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    key = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    value = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    scope_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()"),
                    modified_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_api_scope_property_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_api_scope_property_api_scope_scope_id",
                        column: x => x.scope_id,
                        principalTable: "api_scope",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "client_claim",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    value = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    client_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()"),
                    modified_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_claim_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_client_claim_client_client_id",
                        column: x => x.client_id,
                        principalTable: "client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "client_cors_origin",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    origin = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    client_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()"),
                    modified_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_cors_origin_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_client_cors_origin_client_client_id",
                        column: x => x.client_id,
                        principalTable: "client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "client_grant_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    grant_type = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    client_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()"),
                    modified_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_grant_type_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_client_grant_type_client_client_id",
                        column: x => x.client_id,
                        principalTable: "client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "client_idp_restriction",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    provider = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    client_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()"),
                    modified_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_idp_restriction_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_client_idp_restriction_client_client_id",
                        column: x => x.client_id,
                        principalTable: "client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "client_post_logout_redirect_uri",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    post_logout_redirect_uri = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    client_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()"),
                    modified_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_post_logout_redirect_uri_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_client_post_logout_redirect_uri_client_client_id",
                        column: x => x.client_id,
                        principalTable: "client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "client_property",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    key = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    value = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    client_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()"),
                    modified_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_property_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_client_property_client_client_id",
                        column: x => x.client_id,
                        principalTable: "client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "client_redirect_uri",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    redirect_uri = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    client_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()"),
                    modified_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_redirect_uri_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_client_redirect_uri_client_client_id",
                        column: x => x.client_id,
                        principalTable: "client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "client_scope",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    scope = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    client_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()"),
                    modified_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_scope_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_client_scope_client_client_id",
                        column: x => x.client_id,
                        principalTable: "client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "client_secret",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    value = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: false),
                    expiration = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    type = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    client_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()"),
                    modified_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_secret_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_client_secret_client_client_id",
                        column: x => x.client_id,
                        principalTable: "client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "identity_resource_claim",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    identity_resource_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()"),
                    modified_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identity_resource_claim_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_identity_resource_claim_identity_resource_identity_resource~",
                        column: x => x.identity_resource_id,
                        principalTable: "identity_resource",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "identity_resource_property",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    key = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    value = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    identity_resource_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()"),
                    modified_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identity_resource_property_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_identity_resource_property_identity_resource_identity_resou~",
                        column: x => x.identity_resource_id,
                        principalTable: "identity_resource",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_api_resource_name",
                table: "api_resource",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_api_resource_claim_api_resource_id",
                table: "api_resource_claim",
                column: "api_resource_id");

            migrationBuilder.CreateIndex(
                name: "ix_api_resource_property_api_resource_id",
                table: "api_resource_property",
                column: "api_resource_id");

            migrationBuilder.CreateIndex(
                name: "ix_api_resource_scope_api_resource_id",
                table: "api_resource_scope",
                column: "api_resource_id");

            migrationBuilder.CreateIndex(
                name: "ix_api_resource_secret_api_resource_id",
                table: "api_resource_secret",
                column: "api_resource_id");

            migrationBuilder.CreateIndex(
                name: "ix_api_scope_name",
                table: "api_scope",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_api_scope_claim_scope_id",
                table: "api_scope_claim",
                column: "scope_id");

            migrationBuilder.CreateIndex(
                name: "ix_api_scope_property_scope_id",
                table: "api_scope_property",
                column: "scope_id");

            migrationBuilder.CreateIndex(
                name: "ix_client_client_id",
                table: "client",
                column: "client_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_client_claim_client_id",
                table: "client_claim",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "ix_client_cors_origin_client_id",
                table: "client_cors_origin",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "ix_client_grant_type_client_id",
                table: "client_grant_type",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "ix_client_idp_restriction_client_id",
                table: "client_idp_restriction",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "ix_client_post_logout_redirect_uri_client_id",
                table: "client_post_logout_redirect_uri",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "ix_client_property_client_id",
                table: "client_property",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "ix_client_redirect_uri_client_id",
                table: "client_redirect_uri",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "ix_client_scope_client_id",
                table: "client_scope",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "ix_client_secret_client_id",
                table: "client_secret",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "ix_identity_resource_name",
                table: "identity_resource",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_identity_resource_claim_identity_resource_id",
                table: "identity_resource_claim",
                column: "identity_resource_id");

            migrationBuilder.CreateIndex(
                name: "ix_identity_resource_property_identity_resource_id",
                table: "identity_resource_property",
                column: "identity_resource_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "api_resource_claim");

            migrationBuilder.DropTable(
                name: "api_resource_property");

            migrationBuilder.DropTable(
                name: "api_resource_scope");

            migrationBuilder.DropTable(
                name: "api_resource_secret");

            migrationBuilder.DropTable(
                name: "api_scope_claim");

            migrationBuilder.DropTable(
                name: "api_scope_property");

            migrationBuilder.DropTable(
                name: "client_claim");

            migrationBuilder.DropTable(
                name: "client_cors_origin");

            migrationBuilder.DropTable(
                name: "client_grant_type");

            migrationBuilder.DropTable(
                name: "client_idp_restriction");

            migrationBuilder.DropTable(
                name: "client_post_logout_redirect_uri");

            migrationBuilder.DropTable(
                name: "client_property");

            migrationBuilder.DropTable(
                name: "client_redirect_uri");

            migrationBuilder.DropTable(
                name: "client_scope");

            migrationBuilder.DropTable(
                name: "client_secret");

            migrationBuilder.DropTable(
                name: "identity_resource_claim");

            migrationBuilder.DropTable(
                name: "identity_resource_property");

            migrationBuilder.DropTable(
                name: "api_resource");

            migrationBuilder.DropTable(
                name: "api_scope");

            migrationBuilder.DropTable(
                name: "client");

            migrationBuilder.DropTable(
                name: "identity_resource");
        }
    }
}
