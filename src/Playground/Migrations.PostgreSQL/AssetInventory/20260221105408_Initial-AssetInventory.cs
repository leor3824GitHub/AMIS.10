using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FSH.Playground.Migrations.PostgreSQL.AssetInventory
{
    /// <inheritdoc />
    public partial class InitialAssetInventory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "assetinventory");

            migrationBuilder.CreateTable(
                name: "pars",
                schema: "assetinventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ReceiptNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ReceiptDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenantId = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    CreatedOnUtc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    LastModifiedOnUtc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOnUtc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "physical_assets",
                schema: "assetinventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PropertyNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Category = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    AcquisitionDate = table.Column<DateOnly>(type: "date", nullable: false),
                    AcquisitionCost = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    UsefulLifeDays = table.Column<int>(type: "integer", nullable: false),
                    ResidualValue = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    Condition = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CurrentCustodianId = table.Column<Guid>(type: "uuid", nullable: true),
                    CurrentLocationId = table.Column<Guid>(type: "uuid", nullable: true),
                    SupplierId = table.Column<Guid>(type: "uuid", nullable: true),
                    TenantId = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    CreatedOnUtc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    LastModifiedOnUtc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOnUtc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_physical_assets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ppeirs",
                schema: "assetinventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ReferenceNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TransactionType = table.Column<int>(type: "integer", nullable: false),
                    TransactionDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    FromEmployeeId = table.Column<Guid>(type: "uuid", nullable: true),
                    ToEmployeeId = table.Column<Guid>(type: "uuid", nullable: true),
                    FromLocationId = table.Column<Guid>(type: "uuid", nullable: true),
                    ToLocationId = table.Column<Guid>(type: "uuid", nullable: true),
                    TenantId = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    CreatedOnUtc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    LastModifiedOnUtc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOnUtc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ppeirs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pperrs",
                schema: "assetinventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ReceiptNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ReceiptDate = table.Column<DateOnly>(type: "date", nullable: false),
                    SupplierId = table.Column<Guid>(type: "uuid", nullable: true),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenantId = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    CreatedOnUtc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    LastModifiedOnUtc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOnUtc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pperrs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "rrps",
                schema: "assetinventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ReceiptNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ReceiptDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TenantId = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    CreatedOnUtc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    LastModifiedOnUtc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOnUtc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rrps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "asset_transactions",
                schema: "assetinventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AssetId = table.Column<Guid>(type: "uuid", nullable: false),
                    TransactionType = table.Column<int>(type: "integer", nullable: false),
                    ReferenceNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    TransactionDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Remarks = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    FromCustodianId = table.Column<Guid>(type: "uuid", nullable: true),
                    ToCustodianId = table.Column<Guid>(type: "uuid", nullable: true),
                    FromLocationId = table.Column<Guid>(type: "uuid", nullable: true),
                    ToLocationId = table.Column<Guid>(type: "uuid", nullable: true),
                    TenantId = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    CreatedOnUtc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    LastModifiedOnUtc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOnUtc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asset_transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_asset_transactions_physical_assets_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "assetinventory",
                        principalTable: "physical_assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "par_items",
                schema: "assetinventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PARId = table.Column<Guid>(type: "uuid", nullable: false),
                    AssetId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_par_items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_par_items_pars_PARId",
                        column: x => x.PARId,
                        principalSchema: "assetinventory",
                        principalTable: "pars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_par_items_physical_assets_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "assetinventory",
                        principalTable: "physical_assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ppeir_items",
                schema: "assetinventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PPEIRId = table.Column<Guid>(type: "uuid", nullable: false),
                    AssetId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ppeir_items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ppeir_items_physical_assets_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "assetinventory",
                        principalTable: "physical_assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ppeir_items_ppeirs_PPEIRId",
                        column: x => x.PPEIRId,
                        principalSchema: "assetinventory",
                        principalTable: "ppeirs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pperr_items",
                schema: "assetinventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PPERRId = table.Column<Guid>(type: "uuid", nullable: false),
                    AssetId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pperr_items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pperr_items_physical_assets_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "assetinventory",
                        principalTable: "physical_assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pperr_items_pperrs_PPERRId",
                        column: x => x.PPERRId,
                        principalSchema: "assetinventory",
                        principalTable: "pperrs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rrp_items",
                schema: "assetinventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RRPId = table.Column<Guid>(type: "uuid", nullable: false),
                    AssetId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rrp_items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rrp_items_physical_assets_AssetId",
                        column: x => x.AssetId,
                        principalSchema: "assetinventory",
                        principalTable: "physical_assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_rrp_items_rrps_RRPId",
                        column: x => x.RRPId,
                        principalSchema: "assetinventory",
                        principalTable: "rrps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_asset_transactions_AssetId",
                schema: "assetinventory",
                table: "asset_transactions",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_asset_transactions_IsDeleted",
                schema: "assetinventory",
                table: "asset_transactions",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_asset_transactions_TenantId",
                schema: "assetinventory",
                table: "asset_transactions",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_asset_transactions_TransactionDate",
                schema: "assetinventory",
                table: "asset_transactions",
                column: "TransactionDate");

            migrationBuilder.CreateIndex(
                name: "IX_par_items_AssetId",
                schema: "assetinventory",
                table: "par_items",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_par_items_PARId",
                schema: "assetinventory",
                table: "par_items",
                column: "PARId");

            migrationBuilder.CreateIndex(
                name: "IX_pars_IsDeleted",
                schema: "assetinventory",
                table: "pars",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_pars_ReceiptNumber_TenantId",
                schema: "assetinventory",
                table: "pars",
                columns: new[] { "ReceiptNumber", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pars_TenantId",
                schema: "assetinventory",
                table: "pars",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_physical_assets_IsDeleted",
                schema: "assetinventory",
                table: "physical_assets",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_physical_assets_PropertyNumber_TenantId",
                schema: "assetinventory",
                table: "physical_assets",
                columns: new[] { "PropertyNumber", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_physicalassets_custodian",
                schema: "assetinventory",
                table: "physical_assets",
                column: "CurrentCustodianId");

            migrationBuilder.CreateIndex(
                name: "ix_physicalassets_location",
                schema: "assetinventory",
                table: "physical_assets",
                column: "CurrentLocationId");

            migrationBuilder.CreateIndex(
                name: "ix_physicalassets_supplier",
                schema: "assetinventory",
                table: "physical_assets",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "ix_physicalassets_tenant_created",
                schema: "assetinventory",
                table: "physical_assets",
                columns: new[] { "TenantId", "CreatedOnUtc" },
                descending: new[] { false, true });

            migrationBuilder.CreateIndex(
                name: "ix_physicalassets_tenant_isdeleted",
                schema: "assetinventory",
                table: "physical_assets",
                columns: new[] { "TenantId", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "ix_physicalassets_tenant_status",
                schema: "assetinventory",
                table: "physical_assets",
                columns: new[] { "TenantId", "Status" });

            migrationBuilder.CreateIndex(
                name: "IX_ppeir_items_AssetId",
                schema: "assetinventory",
                table: "ppeir_items",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_ppeir_items_PPEIRId",
                schema: "assetinventory",
                table: "ppeir_items",
                column: "PPEIRId");

            migrationBuilder.CreateIndex(
                name: "IX_ppeirs_IsDeleted",
                schema: "assetinventory",
                table: "ppeirs",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ppeirs_ReferenceNumber_TenantId",
                schema: "assetinventory",
                table: "ppeirs",
                columns: new[] { "ReferenceNumber", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ppeirs_TenantId",
                schema: "assetinventory",
                table: "ppeirs",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_pperr_items_AssetId",
                schema: "assetinventory",
                table: "pperr_items",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_pperr_items_PPERRId",
                schema: "assetinventory",
                table: "pperr_items",
                column: "PPERRId");

            migrationBuilder.CreateIndex(
                name: "IX_pperrs_IsDeleted",
                schema: "assetinventory",
                table: "pperrs",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_pperrs_ReceiptNumber_TenantId",
                schema: "assetinventory",
                table: "pperrs",
                columns: new[] { "ReceiptNumber", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pperrs_TenantId",
                schema: "assetinventory",
                table: "pperrs",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_rrp_items_AssetId",
                schema: "assetinventory",
                table: "rrp_items",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_rrp_items_RRPId",
                schema: "assetinventory",
                table: "rrp_items",
                column: "RRPId");

            migrationBuilder.CreateIndex(
                name: "IX_rrps_IsDeleted",
                schema: "assetinventory",
                table: "rrps",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_rrps_ReceiptNumber_TenantId",
                schema: "assetinventory",
                table: "rrps",
                columns: new[] { "ReceiptNumber", "TenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_rrps_TenantId",
                schema: "assetinventory",
                table: "rrps",
                column: "TenantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "asset_transactions",
                schema: "assetinventory");

            migrationBuilder.DropTable(
                name: "par_items",
                schema: "assetinventory");

            migrationBuilder.DropTable(
                name: "ppeir_items",
                schema: "assetinventory");

            migrationBuilder.DropTable(
                name: "pperr_items",
                schema: "assetinventory");

            migrationBuilder.DropTable(
                name: "rrp_items",
                schema: "assetinventory");

            migrationBuilder.DropTable(
                name: "pars",
                schema: "assetinventory");

            migrationBuilder.DropTable(
                name: "ppeirs",
                schema: "assetinventory");

            migrationBuilder.DropTable(
                name: "pperrs",
                schema: "assetinventory");

            migrationBuilder.DropTable(
                name: "physical_assets",
                schema: "assetinventory");

            migrationBuilder.DropTable(
                name: "rrps",
                schema: "assetinventory");
        }
    }
}
