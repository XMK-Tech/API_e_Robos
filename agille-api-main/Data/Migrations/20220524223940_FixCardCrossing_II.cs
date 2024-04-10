using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class FixCardCrossing_II : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("1524c1c2-74f8-4250-ab86-9401b61ef907"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("35c3a1ee-9e54-47a1-bfee-9b31a714c245"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("36d03afd-fb41-4df1-93af-25a26bb00575"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("457cd224-b3c1-440f-824c-7a24c71862f1"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("5a43eb82-ef3d-447b-9a7f-41a608a29ea6"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("906c9f0d-bc7e-4d83-87c2-c1e3bc869453"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("cf6c5cde-bf02-4a8b-b4ff-077c75402fca"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d2cf11c8-22c4-4006-8d73-83dc3b60dc98"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d2d3d17d-bed6-4c5d-ba4e-91dd1a458fa9"));

            migrationBuilder.DropColumn(
                name: "EndingReference",
                table: "CardCrossing");

            migrationBuilder.DropColumn(
                name: "StartingReference",
                table: "CardCrossing");
            migrationBuilder.DropColumn(
                name: "RequestingUserId",
                table: "CardCrossing");

            migrationBuilder.AddColumn<double>(
                name: "ReportId",
                table: "CardCrossing",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AmountOnAverageRate",
                table: "CardCrossing",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "AmountOnDeclaredRate",
                table: "CardCrossing",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "AverageRate",
                table: "CardCrossing",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "DeclaredRate",
                table: "CardCrossing",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "CardCrossingReport",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartingReference = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndingReference = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardCrossingReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardCrossingReport_User_RequestedById",
                        column: x => x.RequestedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("10c1cd0e-9024-4ad3-a2cf-313bc9b8d570"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 5, 24, 19, 39, 40, 257, DateTimeKind.Local).AddTicks(6494), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("236677ac-a1f2-4d7f-8435-bce7158f59ad"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 5, 24, 19, 39, 40, 257, DateTimeKind.Local).AddTicks(6477), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("42a17c66-40e9-48dd-8d64-5a1304b87b6b"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 5, 24, 19, 39, 40, 257, DateTimeKind.Local).AddTicks(6508), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("45cbe9e2-6b5f-4f1f-9a09-8579e38d110b"), "[[person-document]]", "Document", "Id", new DateTime(2022, 5, 24, 19, 39, 40, 257, DateTimeKind.Local).AddTicks(6492), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("52e529f5-2c93-4e94-9bdc-c923c94e3e20"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 5, 24, 19, 39, 40, 257, DateTimeKind.Local).AddTicks(6507), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("89a1ab2f-859b-4606-b4d7-bf46d9ab7305"), "[[description]]", null, null, new DateTime(2022, 5, 24, 19, 39, 40, 257, DateTimeKind.Local).AddTicks(6505), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("aada6e77-e43a-4652-973e-318cf39bc4b3"), "[[person-name]]", "Name", "Id", new DateTime(2022, 5, 24, 19, 39, 40, 257, DateTimeKind.Local).AddTicks(6490), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("d74eb1e3-5106-4970-9bc3-ca0b1685d14e"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 5, 24, 19, 39, 40, 257, DateTimeKind.Local).AddTicks(6488), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("ebb6455b-e064-4019-befa-5b25afa9a642"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 5, 24, 19, 39, 40, 257, DateTimeKind.Local).AddTicks(6510), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardCrossing_ReportId",
                table: "CardCrossing",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_CardCrossingReport_RequestedById",
                table: "CardCrossingReport",
                column: "RequestedById");

            migrationBuilder.AddForeignKey(
                name: "FK_CardCrossing_CardCrossingReport_ReportId",
                table: "CardCrossing",
                column: "ReportId",
                principalTable: "CardCrossingReport",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardCrossing_CardCrossingReport_ReportId",
                table: "CardCrossing");

            migrationBuilder.DropTable(
                name: "CardCrossingReport");

            migrationBuilder.DropIndex(
                name: "IX_CardCrossing_ReportId",
                table: "CardCrossing");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("10c1cd0e-9024-4ad3-a2cf-313bc9b8d570"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("236677ac-a1f2-4d7f-8435-bce7158f59ad"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("42a17c66-40e9-48dd-8d64-5a1304b87b6b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("45cbe9e2-6b5f-4f1f-9a09-8579e38d110b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("52e529f5-2c93-4e94-9bdc-c923c94e3e20"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("89a1ab2f-859b-4606-b4d7-bf46d9ab7305"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("aada6e77-e43a-4652-973e-318cf39bc4b3"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d74eb1e3-5106-4970-9bc3-ca0b1685d14e"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ebb6455b-e064-4019-befa-5b25afa9a642"));

            migrationBuilder.DropColumn(
                name: "AmountOnAverageRate",
                table: "CardCrossing");

            migrationBuilder.DropColumn(
                name: "AmountOnDeclaredRate",
                table: "CardCrossing");

            migrationBuilder.DropColumn(
                name: "AverageRate",
                table: "CardCrossing");

            migrationBuilder.DropColumn(
                name: "DeclaredRate",
                table: "CardCrossing");

            migrationBuilder.RenameColumn(
                name: "ReportId",
                table: "CardCrossing",
                newName: "RequestingUserId");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndingReference",
                table: "CardCrossing",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartingReference",
                table: "CardCrossing",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("1524c1c2-74f8-4250-ab86-9401b61ef907"), "[[description]]", null, null, new DateTime(2022, 5, 23, 16, 23, 21, 20, DateTimeKind.Local).AddTicks(8778), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("35c3a1ee-9e54-47a1-bfee-9b31a714c245"), "[[person-name]]", "Name", "Id", new DateTime(2022, 5, 23, 16, 23, 21, 20, DateTimeKind.Local).AddTicks(8765), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("36d03afd-fb41-4df1-93af-25a26bb00575"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 5, 23, 16, 23, 21, 20, DateTimeKind.Local).AddTicks(8767), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("457cd224-b3c1-440f-824c-7a24c71862f1"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 5, 23, 16, 23, 21, 20, DateTimeKind.Local).AddTicks(8763), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("5a43eb82-ef3d-447b-9a7f-41a608a29ea6"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 5, 23, 16, 23, 21, 20, DateTimeKind.Local).AddTicks(8779), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("906c9f0d-bc7e-4d83-87c2-c1e3bc869453"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 5, 23, 16, 23, 21, 20, DateTimeKind.Local).AddTicks(8749), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("cf6c5cde-bf02-4a8b-b4ff-077c75402fca"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 5, 23, 16, 23, 21, 20, DateTimeKind.Local).AddTicks(8782), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("d2cf11c8-22c4-4006-8d73-83dc3b60dc98"), "[[person-document]]", "Document", "Id", new DateTime(2022, 5, 23, 16, 23, 21, 20, DateTimeKind.Local).AddTicks(8766), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("d2d3d17d-bed6-4c5d-ba4e-91dd1a458fa9"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 5, 23, 16, 23, 21, 20, DateTimeKind.Local).AddTicks(8780), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" }
                });
        }
    }
}
