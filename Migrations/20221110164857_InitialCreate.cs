using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace smgerp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    tenantid = table.Column<int>(name: "tenant_id", type: "INTEGER", nullable: false),
                    personid = table.Column<int>(name: "person_id", type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "TEXT", unicode: false, maxLength: 200, nullable: true),
                    datecreated = table.Column<DateTime>(name: "date_created", type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    discorduserid = table.Column<long>(name: "discord_user_id", type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => new { x.tenantid, x.personid });
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    tenantid = table.Column<int>(name: "tenant_id", type: "INTEGER", nullable: false),
                    producttypeid = table.Column<int>(name: "product_type_id", type: "INTEGER", nullable: false),
                    description = table.Column<string>(type: "TEXT", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => new { x.tenantid, x.producttypeid });
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    tenantid = table.Column<int>(name: "tenant_id", type: "INTEGER", nullable: false),
                    profileid = table.Column<int>(name: "profile_id", type: "INTEGER", nullable: false),
                    profilename = table.Column<string>(name: "profile_name", type: "TEXT", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => new { x.tenantid, x.profileid });
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    tenantid = table.Column<int>(name: "tenant_id", type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "TEXT", unicode: false, maxLength: 100, nullable: true),
                    datecreated = table.Column<DateTime>(name: "date_created", type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.tenantid);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    tenantid = table.Column<int>(name: "tenant_id", type: "INTEGER", nullable: false),
                    userid = table.Column<int>(name: "user_id", type: "INTEGER", nullable: false),
                    firstname = table.Column<string>(name: "first_name", type: "TEXT", unicode: false, maxLength: 100, nullable: true),
                    lastname = table.Column<string>(name: "last_name", type: "TEXT", unicode: false, maxLength: 100, nullable: true),
                    nickname = table.Column<string>(type: "TEXT", unicode: false, maxLength: 100, nullable: true),
                    email = table.Column<string>(type: "TEXT", unicode: false, maxLength: 100, nullable: true),
                    hash = table.Column<byte[]>(type: "BLOB", fixedLength: true, maxLength: 1, nullable: true),
                    salt = table.Column<string>(type: "TEXT", unicode: false, maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => new { x.tenantid, x.userid });
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    tenantid = table.Column<int>(name: "tenant_id", type: "INTEGER", nullable: false),
                    orderid = table.Column<int>(name: "order_id", type: "INTEGER", nullable: false),
                    personid = table.Column<int>(name: "person_id", type: "INTEGER", nullable: false),
                    datecreated = table.Column<DateTime>(name: "date_created", type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    isclosed = table.Column<bool>(name: "is_closed", type: "INTEGER", nullable: true, defaultValueSql: "((0))"),
                    dateclosed = table.Column<DateTime>(name: "date_closed", type: "datetime", nullable: true),
                    iscanceled = table.Column<bool>(name: "is_canceled", type: "INTEGER", nullable: true, defaultValueSql: "((0))"),
                    datecanceled = table.Column<DateTime>(name: "date_canceled", type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => new { x.tenantid, x.orderid });
                    table.ForeignKey(
                        name: "FK_Orders_People",
                        columns: x => new { x.tenantid, x.personid },
                        principalTable: "People",
                        principalColumns: new[] { "tenant_id", "person_id" });
                });

            migrationBuilder.CreateTable(
                name: "PersonDocuments",
                columns: table => new
                {
                    tenantid = table.Column<int>(name: "tenant_id", type: "INTEGER", nullable: false),
                    personid = table.Column<int>(name: "person_id", type: "INTEGER", nullable: false),
                    documentid = table.Column<int>(name: "document_id", type: "INTEGER", nullable: false),
                    description = table.Column<string>(type: "TEXT", unicode: false, maxLength: 200, nullable: true),
                    url = table.Column<string>(type: "TEXT", unicode: false, maxLength: 200, nullable: true),
                    datecreated = table.Column<DateTime>(name: "date_created", type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonDocuments", x => new { x.tenantid, x.personid, x.documentid });
                    table.ForeignKey(
                        name: "FK_PersonDocuments_People",
                        columns: x => new { x.tenantid, x.personid },
                        principalTable: "People",
                        principalColumns: new[] { "tenant_id", "person_id" });
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    tenantid = table.Column<int>(name: "tenant_id", type: "INTEGER", nullable: false),
                    productid = table.Column<int>(name: "product_id", type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "TEXT", unicode: false, maxLength: 100, nullable: true),
                    description = table.Column<string>(type: "TEXT", unicode: false, maxLength: 1000, nullable: true),
                    price = table.Column<decimal>(type: "decimal(19, 4)", nullable: true),
                    producttypeid = table.Column<int>(name: "product_type_id", type: "INTEGER", nullable: true),
                    active = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => new { x.tenantid, x.productid });
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes",
                        columns: x => new { x.tenantid, x.producttypeid },
                        principalTable: "ProductTypes",
                        principalColumns: new[] { "tenant_id", "product_type_id" });
                });

            migrationBuilder.CreateTable(
                name: "TenantSecrect",
                columns: table => new
                {
                    tenantid = table.Column<int>(name: "tenant_id", type: "INTEGER", nullable: false),
                    secrect = table.Column<string>(type: "TEXT", unicode: false, maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantSecrect", x => x.tenantid);
                    table.ForeignKey(
                        name: "FK_TenantSecrect_Tenants",
                        column: x => x.tenantid,
                        principalTable: "Tenants",
                        principalColumn: "tenant_id");
                });

            migrationBuilder.CreateTable(
                name: "Tokens",
                columns: table => new
                {
                    tenantid = table.Column<int>(name: "tenant_id", type: "INTEGER", nullable: false),
                    userid = table.Column<int>(name: "user_id", type: "INTEGER", nullable: false),
                    tokenid = table.Column<int>(name: "token_id", type: "INTEGER", nullable: false),
                    token = table.Column<string>(type: "TEXT", unicode: false, maxLength: 500, nullable: false),
                    logindate = table.Column<DateTime>(name: "login_date", type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    expiredate = table.Column<DateTime>(name: "expire_date", type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokens", x => new { x.tenantid, x.userid, x.tokenid });
                    table.ForeignKey(
                        name: "FK_Tokens_Users",
                        columns: x => new { x.tenantid, x.userid },
                        principalTable: "Users",
                        principalColumns: new[] { "tenant_id", "user_id" });
                });

            migrationBuilder.CreateTable(
                name: "UserProfile",
                columns: table => new
                {
                    tenantid = table.Column<int>(name: "tenant_id", type: "INTEGER", nullable: false),
                    profileid = table.Column<int>(name: "profile_id", type: "INTEGER", nullable: false),
                    userid = table.Column<int>(name: "user_id", type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfile", x => new { x.tenantid, x.profileid, x.userid });
                    table.ForeignKey(
                        name: "FK_UserProfile_Profiles",
                        columns: x => new { x.tenantid, x.profileid },
                        principalTable: "Profiles",
                        principalColumns: new[] { "tenant_id", "profile_id" });
                    table.ForeignKey(
                        name: "FK_UserProfile_Users",
                        columns: x => new { x.tenantid, x.userid },
                        principalTable: "Users",
                        principalColumns: new[] { "tenant_id", "user_id" });
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    tenantid = table.Column<int>(name: "tenant_id", type: "INTEGER", nullable: false),
                    orderid = table.Column<int>(name: "order_id", type: "INTEGER", nullable: false),
                    itemid = table.Column<int>(name: "item_id", type: "INTEGER", nullable: false),
                    productid = table.Column<int>(name: "product_id", type: "INTEGER", nullable: false),
                    price = table.Column<decimal>(type: "decimal(19, 4)", nullable: true),
                    datecreated = table.Column<DateTime>(name: "date_created", type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => new { x.tenantid, x.orderid, x.itemid });
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders",
                        columns: x => new { x.tenantid, x.orderid },
                        principalTable: "Orders",
                        principalColumns: new[] { "tenant_id", "order_id" });
                });

            migrationBuilder.CreateTable(
                name: "ProductMedia",
                columns: table => new
                {
                    tenantid = table.Column<int>(name: "tenant_id", type: "INTEGER", nullable: false),
                    productid = table.Column<int>(name: "product_id", type: "INTEGER", nullable: false),
                    mediaid = table.Column<int>(name: "media_id", type: "INTEGER", nullable: false),
                    type = table.Column<string>(type: "TEXT", unicode: false, maxLength: 50, nullable: true),
                    url = table.Column<string>(type: "TEXT", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMedia", x => new { x.tenantid, x.productid, x.mediaid });
                    table.ForeignKey(
                        name: "FK_ProductMedia_Products",
                        columns: x => new { x.tenantid, x.productid },
                        principalTable: "Products",
                        principalColumns: new[] { "tenant_id", "product_id" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_tenant_id_person_id",
                table: "Orders",
                columns: new[] { "tenant_id", "person_id" });

            migrationBuilder.CreateIndex(
                name: "Index_People_discord_user_id",
                table: "People",
                column: "discord_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_tenant_id_product_type_id",
                table: "Products",
                columns: new[] { "tenant_id", "product_type_id" });

            migrationBuilder.CreateIndex(
                name: "Index_Tokens_token",
                table: "Tokens",
                column: "token");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_tenant_id_user_id",
                table: "UserProfile",
                columns: new[] { "tenant_id", "user_id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "PersonDocuments");

            migrationBuilder.DropTable(
                name: "ProductMedia");

            migrationBuilder.DropTable(
                name: "TenantSecrect");

            migrationBuilder.DropTable(
                name: "Tokens");

            migrationBuilder.DropTable(
                name: "UserProfile");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "ProductTypes");
        }
    }
}
