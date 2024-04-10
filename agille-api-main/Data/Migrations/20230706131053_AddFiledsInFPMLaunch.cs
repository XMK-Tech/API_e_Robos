using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class AddFiledsInFPMLaunch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("2e67250a-7eff-4eda-94ca-dc3d5260cca2"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("4ad93323-d1f8-404f-b301-5e1d7c08a420"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("4fafa51c-48b8-4fe0-9a4d-a918ed84cbd9"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6882a2ea-73fd-4d48-abef-5bb97a6d035d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6f474e77-25f9-4e72-a6c8-bcfa9d639f55"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("7201ebc3-2194-4ccb-bc5e-14ea83629eee"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("8d05499d-9258-49b1-b283-a71bdb46d762"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a3bf9eaf-cece-4340-b3f5-eb970623d203"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e823bf02-c8cb-45d1-ace3-3d268585b38a"));

            migrationBuilder.AddColumn<DateTime>(
                name: "Competence",
                table: "FPMLaunches",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Reference",
                table: "FPMLaunches",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("14507a5a-4c4f-4069-b6c7-784a1dca6240"), "[[person-name]]", "Name", "Id", new DateTime(2023, 7, 6, 10, 10, 47, 613, DateTimeKind.Local).AddTicks(2754), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("4ae469de-da76-4faa-b818-883226062034"), "[[phone-number]]", "Number", "Id", new DateTime(2023, 7, 6, 10, 10, 47, 613, DateTimeKind.Local).AddTicks(2772), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("4cb3b38d-eca6-4b8e-8a17-7828a6a2dd52"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2023, 7, 6, 10, 10, 47, 613, DateTimeKind.Local).AddTicks(2730), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("6ef926f5-f989-4889-96f6-1d8c4177757a"), "[[description]]", null, null, new DateTime(2023, 7, 6, 10, 10, 47, 613, DateTimeKind.Local).AddTicks(2759), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("76d4044a-d460-46e9-86f8-4cb509b83629"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2023, 7, 6, 10, 10, 47, 613, DateTimeKind.Local).AddTicks(2752), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("98c6daa4-1522-4035-b119-0fdc973c9b1c"), "[[person-document]]", "Document", "Id", new DateTime(2023, 7, 6, 10, 10, 47, 613, DateTimeKind.Local).AddTicks(2755), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("a51219e3-6e9c-41ac-93af-b4100760c536"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 7, 6, 10, 10, 47, 613, DateTimeKind.Local).AddTicks(2771), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("b9d0eb3e-46f2-468f-ae30-091d68231118"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 7, 6, 10, 10, 47, 613, DateTimeKind.Local).AddTicks(2769), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("d7dc4df2-8e08-4cdf-99b4-3bff85ea30f4"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2023, 7, 6, 10, 10, 47, 613, DateTimeKind.Local).AddTicks(2757), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("14507a5a-4c4f-4069-b6c7-784a1dca6240"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("4ae469de-da76-4faa-b818-883226062034"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("4cb3b38d-eca6-4b8e-8a17-7828a6a2dd52"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6ef926f5-f989-4889-96f6-1d8c4177757a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("76d4044a-d460-46e9-86f8-4cb509b83629"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("98c6daa4-1522-4035-b119-0fdc973c9b1c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a51219e3-6e9c-41ac-93af-b4100760c536"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b9d0eb3e-46f2-468f-ae30-091d68231118"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d7dc4df2-8e08-4cdf-99b4-3bff85ea30f4"));

            migrationBuilder.DropColumn(
                name: "Competence",
                table: "FPMLaunches");

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "FPMLaunches");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("2e67250a-7eff-4eda-94ca-dc3d5260cca2"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2023, 6, 15, 8, 26, 33, 515, DateTimeKind.Local).AddTicks(1039), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("4ad93323-d1f8-404f-b301-5e1d7c08a420"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 6, 15, 8, 26, 33, 515, DateTimeKind.Local).AddTicks(1066), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("4fafa51c-48b8-4fe0-9a4d-a918ed84cbd9"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 6, 15, 8, 26, 33, 515, DateTimeKind.Local).AddTicks(1051), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("6882a2ea-73fd-4d48-abef-5bb97a6d035d"), "[[person-name]]", "Name", "Id", new DateTime(2023, 6, 15, 8, 26, 33, 515, DateTimeKind.Local).AddTicks(1041), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("6f474e77-25f9-4e72-a6c8-bcfa9d639f55"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2023, 6, 15, 8, 26, 33, 515, DateTimeKind.Local).AddTicks(1046), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("7201ebc3-2194-4ccb-bc5e-14ea83629eee"), "[[person-document]]", "Document", "Id", new DateTime(2023, 6, 15, 8, 26, 33, 515, DateTimeKind.Local).AddTicks(1044), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("8d05499d-9258-49b1-b283-a71bdb46d762"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2023, 6, 15, 8, 26, 33, 515, DateTimeKind.Local).AddTicks(1022), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("a3bf9eaf-cece-4340-b3f5-eb970623d203"), "[[description]]", null, null, new DateTime(2023, 6, 15, 8, 26, 33, 515, DateTimeKind.Local).AddTicks(1048), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("e823bf02-c8cb-45d1-ace3-3d268585b38a"), "[[phone-number]]", "Number", "Id", new DateTime(2023, 6, 15, 8, 26, 33, 515, DateTimeKind.Local).AddTicks(1069), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });
        }
    }
}
