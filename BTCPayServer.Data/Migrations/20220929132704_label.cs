// <auto-generated />
using System;
using BTCPayServer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BTCPayServer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220929132704_label")]
    public partial class label : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            int? maxlength = migrationBuilder.IsMySql() ? 255 : null;

            migrationBuilder.CreateTable(
                name: "WalletObjects",
                columns: table => new
                {
                    WalletId = table.Column<string>(nullable: false, maxLength: maxlength),
                    Type = table.Column<string>(nullable: false, maxLength: maxlength),
                    Id = table.Column<string>(nullable: false, maxLength: maxlength),
                    Data = table.Column<string>(type: migrationBuilder.IsNpgsql() ? "JSONB" : "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletObjects", x => new { x.WalletId, x.Type, x.Id });
                });
            migrationBuilder.CreateIndex(
                name: "IX_WalletObjects_Type_Id",
                table: "WalletObjects",
                columns: new[] { "Type", "Id" });


            maxlength = migrationBuilder.IsMySql() ? 100 : null;
            migrationBuilder.CreateTable(
                name: "WalletObjectLinks",
                columns: table => new
                {
                    WalletId = table.Column<string>(nullable: false, maxLength: maxlength),
                    AType = table.Column<string>(nullable: false, maxLength: maxlength),
                    AId = table.Column<string>(nullable: false, maxLength: maxlength),
                    BType = table.Column<string>(nullable: false, maxLength: maxlength),
                    BId = table.Column<string>(nullable: false, maxLength: maxlength),
                    Data = table.Column<string>(type: migrationBuilder.IsNpgsql() ? "JSONB" : "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletObjectLinks", x => new { x.WalletId, x.AType, x.AId, x.BType, x.BId });
                    table.ForeignKey(
                        name: "FK_WalletObjectLinks_WalletObjects_WalletId_BType_BId",
                        columns: x => new { x.WalletId, x.BType, x.BId },
                        principalTable: "WalletObjects",
                        principalColumns: new[] { "WalletId", "Type", "Id" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WalletObjectLinks_WalletObjects_WalletId_AType_AId",
                        columns: x => new { x.WalletId, x.AType, x.AId },
                        principalTable: "WalletObjects",
                        principalColumns: new[] { "WalletId", "Type", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WalletObjectLinks_WalletId_BType_BId",
                table: "WalletObjectLinks",
                columns: new[] { "WalletId", "BType", "BId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WalletObjectLinks");

            migrationBuilder.DropTable(
                name: "WalletObjects");
        }
    }
}