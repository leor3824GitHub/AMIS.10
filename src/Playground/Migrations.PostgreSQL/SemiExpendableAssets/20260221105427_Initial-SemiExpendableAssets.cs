using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FSH.Playground.Migrations.PostgreSQL.SemiExpendableAssets
{
    /// <inheritdoc />
    public partial class InitialSemiExpendableAssets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "semi_expendable_assets");

            migrationBuilder.CreateTable(
                name: "asset_transactions",
                schema: "semi_expendable_assets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AssetId = table.Column<Guid>(type: "uuid", nullable: false),
                    TransactionType = table.Column<int>(type: "integer", nullable: false),
                    ReferenceNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    FromCustodianId = table.Column<Guid>(type: "uuid", nullable: true),
                    ToCustodianId = table.Column<Guid>(type: "uuid", nullable: true),
                    FromLocationId = table.Column<Guid>(type: "uuid", nullable: true),
                    ToLocationId = table.Column<Guid>(type: "uuid", nullable: true),
                    TransactionDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Remarks = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    TenantId = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    CreatedOnUtc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModifiedOnUtc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOnUtc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asset_transactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "inventory_custodian_slips",
                schema: "semi_expendable_assets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ICSNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ICSDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CustodianId = table.Column<Guid>(type: "uuid", nullable: false),
                    LocationId = table.Column<Guid>(type: "uuid", nullable: false),
                    Purpose = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Remarks = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    TenantId = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    CreatedOnUtc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModifiedOnUtc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOnUtc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventory_custodian_slips", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "receipts",
                schema: "semi_expendable_assets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ReceiptNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ReceiptType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ReceiptDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    SupplierId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeliveryReferenceNo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Remarks = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    TenantId = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    CreatedOnUtc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModifiedOnUtc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOnUtc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receipts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "return_documents",
                schema: "semi_expendable_assets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ReturnDocumentNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ReturnDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    FromCustodianId = table.Column<Guid>(type: "uuid", nullable: false),
                    ToLocationId = table.Column<Guid>(type: "uuid", nullable: false),
                    Reason = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Remarks = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    TenantId = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    CreatedOnUtc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModifiedOnUtc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOnUtc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_return_documents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "semi_expendable_assets",
                schema: "semi_expendable_assets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ICSNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Category = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    AcquisitionDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    AcquisitionCost = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    Condition = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CurrentCustodianId = table.Column<Guid>(type: "uuid", nullable: true),
                    CurrentLocationId = table.Column<Guid>(type: "uuid", nullable: true),
                    ReceiptReferenceId = table.Column<Guid>(type: "uuid", nullable: true),
                    TenantId = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    CreatedOnUtc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModifiedOnUtc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOnUtc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_semi_expendable_assets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "transfer_documents",
                schema: "semi_expendable_assets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TransferDocumentNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TransferDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    FromCustodianId = table.Column<Guid>(type: "uuid", nullable: false),
                    ToCustodianId = table.Column<Guid>(type: "uuid", nullable: true),
                    ToLocationId = table.Column<Guid>(type: "uuid", nullable: true),
                    TransferType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Reason = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Remarks = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    TenantId = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    CreatedOnUtc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModifiedOnUtc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOnUtc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transfer_documents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ics_items",
                schema: "semi_expendable_assets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ICSId = table.Column<Guid>(type: "uuid", nullable: false),
                    AssetId = table.Column<Guid>(type: "uuid", nullable: false),
                    Remarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    InventoryCustodianSlipId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ics_items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ics_items_inventory_custodian_slips_ICSId",
                        column: x => x.ICSId,
                        principalSchema: "semi_expendable_assets",
                        principalTable: "inventory_custodian_slips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ics_items_inventory_custodian_slips_InventoryCustodianSlipId",
                        column: x => x.InventoryCustodianSlipId,
                        principalSchema: "semi_expendable_assets",
                        principalTable: "inventory_custodian_slips",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "receipt_items",
                schema: "semi_expendable_assets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ReceiptId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Category = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    UnitCost = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    Condition = table.Column<int>(type: "integer", nullable: false),
                    ReceiptId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receipt_items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_receipt_items_receipts_ReceiptId",
                        column: x => x.ReceiptId,
                        principalSchema: "semi_expendable_assets",
                        principalTable: "receipts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_receipt_items_receipts_ReceiptId1",
                        column: x => x.ReceiptId1,
                        principalSchema: "semi_expendable_assets",
                        principalTable: "receipts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "return_items",
                schema: "semi_expendable_assets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ReturnDocumentId = table.Column<Guid>(type: "uuid", nullable: false),
                    AssetId = table.Column<Guid>(type: "uuid", nullable: false),
                    Remarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ReturnDocumentId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_return_items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_return_items_return_documents_ReturnDocumentId",
                        column: x => x.ReturnDocumentId,
                        principalSchema: "semi_expendable_assets",
                        principalTable: "return_documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_return_items_return_documents_ReturnDocumentId1",
                        column: x => x.ReturnDocumentId1,
                        principalSchema: "semi_expendable_assets",
                        principalTable: "return_documents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "transfer_items",
                schema: "semi_expendable_assets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TransferDocumentId = table.Column<Guid>(type: "uuid", nullable: false),
                    AssetId = table.Column<Guid>(type: "uuid", nullable: false),
                    Remarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    TransferDocumentId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transfer_items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_transfer_items_transfer_documents_TransferDocumentId",
                        column: x => x.TransferDocumentId,
                        principalSchema: "semi_expendable_assets",
                        principalTable: "transfer_documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transfer_items_transfer_documents_TransferDocumentId1",
                        column: x => x.TransferDocumentId1,
                        principalSchema: "semi_expendable_assets",
                        principalTable: "transfer_documents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_asset_transactions_AssetId",
                schema: "semi_expendable_assets",
                table: "asset_transactions",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_asset_transactions_TenantId",
                schema: "semi_expendable_assets",
                table: "asset_transactions",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_asset_transactions_TransactionDate",
                schema: "semi_expendable_assets",
                table: "asset_transactions",
                column: "TransactionDate");

            migrationBuilder.CreateIndex(
                name: "IX_ics_items_AssetId",
                schema: "semi_expendable_assets",
                table: "ics_items",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_ics_items_ICSId",
                schema: "semi_expendable_assets",
                table: "ics_items",
                column: "ICSId");

            migrationBuilder.CreateIndex(
                name: "IX_ics_items_InventoryCustodianSlipId",
                schema: "semi_expendable_assets",
                table: "ics_items",
                column: "InventoryCustodianSlipId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_custodian_slips_CustodianId",
                schema: "semi_expendable_assets",
                table: "inventory_custodian_slips",
                column: "CustodianId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_custodian_slips_ICSNumber",
                schema: "semi_expendable_assets",
                table: "inventory_custodian_slips",
                column: "ICSNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_inventory_custodian_slips_TenantId",
                schema: "semi_expendable_assets",
                table: "inventory_custodian_slips",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_receipt_items_ReceiptId",
                schema: "semi_expendable_assets",
                table: "receipt_items",
                column: "ReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_receipt_items_ReceiptId1",
                schema: "semi_expendable_assets",
                table: "receipt_items",
                column: "ReceiptId1");

            migrationBuilder.CreateIndex(
                name: "IX_receipts_ReceiptNumber",
                schema: "semi_expendable_assets",
                table: "receipts",
                column: "ReceiptNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_receipts_TenantId",
                schema: "semi_expendable_assets",
                table: "receipts",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_return_documents_ReturnDocumentNumber",
                schema: "semi_expendable_assets",
                table: "return_documents",
                column: "ReturnDocumentNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_return_documents_TenantId",
                schema: "semi_expendable_assets",
                table: "return_documents",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_return_items_AssetId",
                schema: "semi_expendable_assets",
                table: "return_items",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_return_items_ReturnDocumentId",
                schema: "semi_expendable_assets",
                table: "return_items",
                column: "ReturnDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_return_items_ReturnDocumentId1",
                schema: "semi_expendable_assets",
                table: "return_items",
                column: "ReturnDocumentId1");

            migrationBuilder.CreateIndex(
                name: "IX_semi_expendable_assets_Condition",
                schema: "semi_expendable_assets",
                table: "semi_expendable_assets",
                column: "Condition");

            migrationBuilder.CreateIndex(
                name: "IX_semi_expendable_assets_ICSNumber",
                schema: "semi_expendable_assets",
                table: "semi_expendable_assets",
                column: "ICSNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_semi_expendable_assets_Status",
                schema: "semi_expendable_assets",
                table: "semi_expendable_assets",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "ix_semiexpendableassets_custodian",
                schema: "semi_expendable_assets",
                table: "semi_expendable_assets",
                column: "CurrentCustodianId");

            migrationBuilder.CreateIndex(
                name: "ix_semiexpendableassets_location",
                schema: "semi_expendable_assets",
                table: "semi_expendable_assets",
                column: "CurrentLocationId");

            migrationBuilder.CreateIndex(
                name: "ix_semiexpendableassets_tenant_created",
                schema: "semi_expendable_assets",
                table: "semi_expendable_assets",
                columns: new[] { "TenantId", "CreatedOnUtc" },
                descending: new[] { false, true });

            migrationBuilder.CreateIndex(
                name: "ix_semiexpendableassets_tenant_deleted",
                schema: "semi_expendable_assets",
                table: "semi_expendable_assets",
                columns: new[] { "TenantId", "DeletedOnUtc" });

            migrationBuilder.CreateIndex(
                name: "ix_semiexpendableassets_tenant_status",
                schema: "semi_expendable_assets",
                table: "semi_expendable_assets",
                columns: new[] { "TenantId", "Status" });

            migrationBuilder.CreateIndex(
                name: "IX_transfer_documents_TenantId",
                schema: "semi_expendable_assets",
                table: "transfer_documents",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_transfer_documents_TransferDocumentNumber",
                schema: "semi_expendable_assets",
                table: "transfer_documents",
                column: "TransferDocumentNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_transfer_items_AssetId",
                schema: "semi_expendable_assets",
                table: "transfer_items",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_transfer_items_TransferDocumentId",
                schema: "semi_expendable_assets",
                table: "transfer_items",
                column: "TransferDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_transfer_items_TransferDocumentId1",
                schema: "semi_expendable_assets",
                table: "transfer_items",
                column: "TransferDocumentId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "asset_transactions",
                schema: "semi_expendable_assets");

            migrationBuilder.DropTable(
                name: "ics_items",
                schema: "semi_expendable_assets");

            migrationBuilder.DropTable(
                name: "receipt_items",
                schema: "semi_expendable_assets");

            migrationBuilder.DropTable(
                name: "return_items",
                schema: "semi_expendable_assets");

            migrationBuilder.DropTable(
                name: "semi_expendable_assets",
                schema: "semi_expendable_assets");

            migrationBuilder.DropTable(
                name: "transfer_items",
                schema: "semi_expendable_assets");

            migrationBuilder.DropTable(
                name: "inventory_custodian_slips",
                schema: "semi_expendable_assets");

            migrationBuilder.DropTable(
                name: "receipts",
                schema: "semi_expendable_assets");

            migrationBuilder.DropTable(
                name: "return_documents",
                schema: "semi_expendable_assets");

            migrationBuilder.DropTable(
                name: "transfer_documents",
                schema: "semi_expendable_assets");
        }
    }
}
