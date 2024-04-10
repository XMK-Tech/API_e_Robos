using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class PersonProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("2c1df0e0-6f1b-4292-a17c-132bfa91e7e6"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3581e975-eea2-4a61-8c19-405c111af825"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("8b711da9-046b-40aa-a3e9-c2097046a3df"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9df7ccce-0090-4832-aff5-eb086c3b181c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a24e763a-8780-4350-a430-35c5b6f636b7"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a4c8d4e3-07c4-464f-adfd-0e0fc7dc586c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a5a868af-f6b0-43fd-8b42-3a0fbe55bc3f"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c760a0a7-b5d6-4ae4-b333-818972e373f4"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d8dc664e-c20a-44b3-a9d1-d7ad25219896"));

            migrationBuilder.AlterColumn<string>(
                name: "ImmunityYears",
                table: "Person",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InventoryPerson",
                table: "Person",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InventoryPersonDocument",
                table: "Person",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalRepresentative",
                table: "Person",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalRepresentativeDocument",
                table: "Person",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReasonForImmunity",
                table: "Person",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: true);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("02ed19f0-7b45-4185-94eb-2c92849695e6"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 12, 19, 29, 53, 881, DateTimeKind.Local).AddTicks(5533), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("21c8fe5b-c67f-4058-ab6f-546f5fd01433"), "[[person-name]]", "Name", "Id", new DateTime(2022, 7, 12, 19, 29, 53, 881, DateTimeKind.Local).AddTicks(5524), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("3cddb23c-56bb-4ba3-a3e7-d8f6020c5e50"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 7, 12, 19, 29, 53, 881, DateTimeKind.Local).AddTicks(5477), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("42a2f4f7-c23e-40c7-a52f-3f30b8b68ff9"), "[[description]]", null, null, new DateTime(2022, 7, 12, 19, 29, 53, 881, DateTimeKind.Local).AddTicks(5530), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("6fe21599-ab79-43f7-bfb1-c37c8b6761fd"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 7, 12, 19, 29, 53, 881, DateTimeKind.Local).AddTicks(5534), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("778a2a78-ec7d-42d5-a778-882ac63d1940"), "[[person-document]]", "Document", "Id", new DateTime(2022, 7, 12, 19, 29, 53, 881, DateTimeKind.Local).AddTicks(5526), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("ab740a0f-c98f-4d48-9190-932bdb674231"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 7, 12, 19, 29, 53, 881, DateTimeKind.Local).AddTicks(5521), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("d82a352a-7b75-47ac-a1d2-8b596df22906"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 12, 19, 29, 53, 881, DateTimeKind.Local).AddTicks(5531), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("ec8e58c7-0c9c-45ec-a48d-46a210e9895b"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 7, 12, 19, 29, 53, 881, DateTimeKind.Local).AddTicks(5528), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("02ed19f0-7b45-4185-94eb-2c92849695e6"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("21c8fe5b-c67f-4058-ab6f-546f5fd01433"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3cddb23c-56bb-4ba3-a3e7-d8f6020c5e50"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("42a2f4f7-c23e-40c7-a52f-3f30b8b68ff9"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6fe21599-ab79-43f7-bfb1-c37c8b6761fd"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("778a2a78-ec7d-42d5-a778-882ac63d1940"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ab740a0f-c98f-4d48-9190-932bdb674231"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d82a352a-7b75-47ac-a1d2-8b596df22906"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ec8e58c7-0c9c-45ec-a48d-46a210e9895b"));

            migrationBuilder.DropColumn(
                name: "InventoryPerson",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "InventoryPersonDocument",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "LegalRepresentative",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "LegalRepresentativeDocument",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "ReasonForImmunity",
                table: "Person");

            migrationBuilder.AlterColumn<string>(
                name: "ImmunityYears",
                table: "Person",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("2c1df0e0-6f1b-4292-a17c-132bfa91e7e6"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 7, 12, 16, 43, 21, 116, DateTimeKind.Local).AddTicks(2605), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("3581e975-eea2-4a61-8c19-405c111af825"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 12, 16, 43, 21, 116, DateTimeKind.Local).AddTicks(2634), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("8b711da9-046b-40aa-a3e9-c2097046a3df"), "[[description]]", null, null, new DateTime(2022, 7, 12, 16, 43, 21, 116, DateTimeKind.Local).AddTicks(2624), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("9df7ccce-0090-4832-aff5-eb086c3b181c"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 7, 12, 16, 43, 21, 116, DateTimeKind.Local).AddTicks(2623), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("a24e763a-8780-4350-a430-35c5b6f636b7"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 7, 12, 16, 43, 21, 116, DateTimeKind.Local).AddTicks(2618), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("a4c8d4e3-07c4-464f-adfd-0e0fc7dc586c"), "[[person-name]]", "Name", "Id", new DateTime(2022, 7, 12, 16, 43, 21, 116, DateTimeKind.Local).AddTicks(2620), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("a5a868af-f6b0-43fd-8b42-3a0fbe55bc3f"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 7, 12, 16, 43, 21, 116, DateTimeKind.Local).AddTicks(2636), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("c760a0a7-b5d6-4ae4-b333-818972e373f4"), "[[person-document]]", "Document", "Id", new DateTime(2022, 7, 12, 16, 43, 21, 116, DateTimeKind.Local).AddTicks(2621), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("d8dc664e-c20a-44b3-a9d1-d7ad25219896"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 12, 16, 43, 21, 116, DateTimeKind.Local).AddTicks(2633), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" }
                });
        }
    }
}
