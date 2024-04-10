using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgilleApi.Data.Migrations
{
    public partial class DataCrossingFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("14f27a7f-9dee-442f-8dc5-e69d7fae1215"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("4c257b36-79ab-4eda-8d58-f84d7d3d4c04"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("54872ec9-6c0e-4cd0-a3d1-a34e44e01c75"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("8057d53c-d625-4b9e-a0c3-bd767e4939eb"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("92ad0134-ac08-4f62-87aa-f924e439a3b5"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("948e2fc9-2de4-49d0-a672-38405ef85e8c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a6adfd44-d991-40aa-9470-e8952abc317c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ca5d1511-c7dc-46cc-8812-26aae89d967d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f00549c3-2160-49f5-b810-7f407467b5d2"));

            migrationBuilder.AddColumn<Guid>(
                name: "DataCrossingId",
                table: "TransactionEntry",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DataCrossingId",
                table: "InvoiceEntry",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DataCrossingId",
                table: "DivergencyEntry",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DataCrossing",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdateAt = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    StartingReference = table.Column<DateTime>(nullable: false),
                    EndingReference = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataCrossing", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("9ffacfaa-2022-41c5-aff8-64ff050ac66c"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 2, 17, 14, 5, 28, 364, DateTimeKind.Local).AddTicks(4744), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("6a7c9c8d-746b-4cad-8e08-8fb2a06e5cac"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 2, 17, 14, 5, 28, 365, DateTimeKind.Local).AddTicks(5665), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("1237dc6e-18e2-488f-8a86-740fc7bc8e87"), "[[person-name]]", "Name", "Id", new DateTime(2022, 2, 17, 14, 5, 28, 365, DateTimeKind.Local).AddTicks(5755), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("2909cdfb-77ff-464b-acfb-9a0b6d75a11d"), "[[person-document]]", "Document", "Id", new DateTime(2022, 2, 17, 14, 5, 28, 365, DateTimeKind.Local).AddTicks(5759), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("a406961f-23a9-46f7-b580-e515d888bc4f"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 2, 17, 14, 5, 28, 365, DateTimeKind.Local).AddTicks(5762), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("50ee6dde-310b-433d-8d44-10c407318973"), "[[description]]", null, null, new DateTime(2022, 2, 17, 14, 5, 28, 365, DateTimeKind.Local).AddTicks(5764), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("32d6fc98-fd56-40dd-a727-c2aeaae0e7f7"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 17, 14, 5, 28, 365, DateTimeKind.Local).AddTicks(5766), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("4a616d71-5899-4d27-a4d6-39d6a1ba9479"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 17, 14, 5, 28, 365, DateTimeKind.Local).AddTicks(5779), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("6b206313-ff7a-4598-971b-e159cdfb5897"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 2, 17, 14, 5, 28, 365, DateTimeKind.Local).AddTicks(5782), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionEntry_DataCrossingId",
                table: "TransactionEntry",
                column: "DataCrossingId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceEntry_DataCrossingId",
                table: "InvoiceEntry",
                column: "DataCrossingId");

            migrationBuilder.CreateIndex(
                name: "IX_DivergencyEntry_DataCrossingId",
                table: "DivergencyEntry",
                column: "DataCrossingId");

            migrationBuilder.AddForeignKey(
                name: "FK_DivergencyEntry_DataCrossing_DataCrossingId",
                table: "DivergencyEntry",
                column: "DataCrossingId",
                principalTable: "DataCrossing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceEntry_DataCrossing_DataCrossingId",
                table: "InvoiceEntry",
                column: "DataCrossingId",
                principalTable: "DataCrossing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionEntry_DataCrossing_DataCrossingId",
                table: "TransactionEntry",
                column: "DataCrossingId",
                principalTable: "DataCrossing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DivergencyEntry_DataCrossing_DataCrossingId",
                table: "DivergencyEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceEntry_DataCrossing_DataCrossingId",
                table: "InvoiceEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionEntry_DataCrossing_DataCrossingId",
                table: "TransactionEntry");

            migrationBuilder.DropTable(
                name: "DataCrossing");

            migrationBuilder.DropIndex(
                name: "IX_TransactionEntry_DataCrossingId",
                table: "TransactionEntry");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceEntry_DataCrossingId",
                table: "InvoiceEntry");

            migrationBuilder.DropIndex(
                name: "IX_DivergencyEntry_DataCrossingId",
                table: "DivergencyEntry");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("1237dc6e-18e2-488f-8a86-740fc7bc8e87"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("2909cdfb-77ff-464b-acfb-9a0b6d75a11d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("32d6fc98-fd56-40dd-a727-c2aeaae0e7f7"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("4a616d71-5899-4d27-a4d6-39d6a1ba9479"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("50ee6dde-310b-433d-8d44-10c407318973"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6a7c9c8d-746b-4cad-8e08-8fb2a06e5cac"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6b206313-ff7a-4598-971b-e159cdfb5897"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9ffacfaa-2022-41c5-aff8-64ff050ac66c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a406961f-23a9-46f7-b580-e515d888bc4f"));

            migrationBuilder.DropColumn(
                name: "DataCrossingId",
                table: "TransactionEntry");

            migrationBuilder.DropColumn(
                name: "DataCrossingId",
                table: "InvoiceEntry");

            migrationBuilder.DropColumn(
                name: "DataCrossingId",
                table: "DivergencyEntry");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("a6adfd44-d991-40aa-9470-e8952abc317c"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 2, 17, 12, 37, 4, 159, DateTimeKind.Local).AddTicks(8755), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("8057d53c-d625-4b9e-a0c3-bd767e4939eb"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 2, 17, 12, 37, 4, 160, DateTimeKind.Local).AddTicks(9653), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("f00549c3-2160-49f5-b810-7f407467b5d2"), "[[person-name]]", "Name", "Id", new DateTime(2022, 2, 17, 12, 37, 4, 160, DateTimeKind.Local).AddTicks(9749), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("4c257b36-79ab-4eda-8d58-f84d7d3d4c04"), "[[person-document]]", "Document", "Id", new DateTime(2022, 2, 17, 12, 37, 4, 160, DateTimeKind.Local).AddTicks(9753), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("54872ec9-6c0e-4cd0-a3d1-a34e44e01c75"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 2, 17, 12, 37, 4, 160, DateTimeKind.Local).AddTicks(9756), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("ca5d1511-c7dc-46cc-8812-26aae89d967d"), "[[description]]", null, null, new DateTime(2022, 2, 17, 12, 37, 4, 160, DateTimeKind.Local).AddTicks(9758), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("14f27a7f-9dee-442f-8dc5-e69d7fae1215"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 17, 12, 37, 4, 160, DateTimeKind.Local).AddTicks(9761), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("948e2fc9-2de4-49d0-a672-38405ef85e8c"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 17, 12, 37, 4, 160, DateTimeKind.Local).AddTicks(9763), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("92ad0134-ac08-4f62-87aa-f924e439a3b5"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 2, 17, 12, 37, 4, 160, DateTimeKind.Local).AddTicks(9773), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });
        }
    }
}
