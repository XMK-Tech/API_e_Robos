using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class RemoveDependenciesRequirement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Propriety_ProprietyCharacteristics_CharacteristicsId",
                table: "Propriety");

            migrationBuilder.DropForeignKey(
                name: "FK_Propriety_ProprietyContact_ContactId",
                table: "Propriety");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("086f7798-bfd3-40e8-903d-87095a4bdce3"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3cd155a9-2d69-4364-9c7b-daf7fb6da659"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("42e8461f-99f4-4ac0-b7ce-cf3e0017ee96"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("59a81721-c402-4dc0-abb7-2e915d8cb53e"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("73ff7ab8-5078-4f25-9e16-703db56cbaa3"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("7defdad7-fca1-488c-b85d-0535ac6369d4"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a2d06fe7-3345-415f-bd21-e2fafb145011"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b005041b-9e82-44a2-bad1-eb8381a5e046"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("cdcd9a6d-9189-4fd9-9b7b-5a203a260b3b"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ContactId",
                table: "Propriety",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "CharacteristicsId",
                table: "Propriety",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressId",
                table: "Propriety",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("56559283-6ca0-451a-bd18-591ec4e59fbf"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 7, 11, 18, 9, 14, 538, DateTimeKind.Local).AddTicks(8436), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("7fbc588d-25b9-4ccc-99f8-e7388d66fc34"), "[[person-document]]", "Document", "Id", new DateTime(2022, 7, 11, 18, 9, 14, 538, DateTimeKind.Local).AddTicks(8435), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("87f45c48-4511-47ff-a0b4-041ea97dfb5f"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 11, 18, 9, 14, 538, DateTimeKind.Local).AddTicks(8459), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("b3afb0d5-820e-4ad2-8922-7fa985044456"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 7, 11, 18, 9, 14, 538, DateTimeKind.Local).AddTicks(8432), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("ba7545dd-e0b6-4b74-8014-f8a6d2e67061"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 11, 18, 9, 14, 538, DateTimeKind.Local).AddTicks(8461), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("c9787d47-486e-429b-9801-97aae4bcfd93"), "[[description]]", null, null, new DateTime(2022, 7, 11, 18, 9, 14, 538, DateTimeKind.Local).AddTicks(8437), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("cb6f8991-5459-4f2a-860c-870a10f2991f"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 7, 11, 18, 9, 14, 538, DateTimeKind.Local).AddTicks(8407), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("d1e9a74b-2ffe-4122-aeb7-c0ca96eef635"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 7, 11, 18, 9, 14, 538, DateTimeKind.Local).AddTicks(8462), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("fe064e28-1cba-4dd4-8c5d-a9422bb361f0"), "[[person-name]]", "Name", "Id", new DateTime(2022, 7, 11, 18, 9, 14, 538, DateTimeKind.Local).AddTicks(8433), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Propriety_ProprietyCharacteristics_CharacteristicsId",
                table: "Propriety",
                column: "CharacteristicsId",
                principalTable: "ProprietyCharacteristics",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Propriety_ProprietyContact_ContactId",
                table: "Propriety",
                column: "ContactId",
                principalTable: "ProprietyContact",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Propriety_ProprietyCharacteristics_CharacteristicsId",
                table: "Propriety");

            migrationBuilder.DropForeignKey(
                name: "FK_Propriety_ProprietyContact_ContactId",
                table: "Propriety");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("56559283-6ca0-451a-bd18-591ec4e59fbf"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("7fbc588d-25b9-4ccc-99f8-e7388d66fc34"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("87f45c48-4511-47ff-a0b4-041ea97dfb5f"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b3afb0d5-820e-4ad2-8922-7fa985044456"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ba7545dd-e0b6-4b74-8014-f8a6d2e67061"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c9787d47-486e-429b-9801-97aae4bcfd93"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("cb6f8991-5459-4f2a-860c-870a10f2991f"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d1e9a74b-2ffe-4122-aeb7-c0ca96eef635"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("fe064e28-1cba-4dd4-8c5d-a9422bb361f0"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ContactId",
                table: "Propriety",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CharacteristicsId",
                table: "Propriety",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressId",
                table: "Propriety",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("086f7798-bfd3-40e8-903d-87095a4bdce3"), "[[person-document]]", "Document", "Id", new DateTime(2022, 7, 11, 17, 52, 19, 52, DateTimeKind.Local).AddTicks(6774), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("3cd155a9-2d69-4364-9c7b-daf7fb6da659"), "[[person-name]]", "Name", "Id", new DateTime(2022, 7, 11, 17, 52, 19, 52, DateTimeKind.Local).AddTicks(6772), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("42e8461f-99f4-4ac0-b7ce-cf3e0017ee96"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 7, 11, 17, 52, 19, 52, DateTimeKind.Local).AddTicks(6741), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("59a81721-c402-4dc0-abb7-2e915d8cb53e"), "[[description]]", null, null, new DateTime(2022, 7, 11, 17, 52, 19, 52, DateTimeKind.Local).AddTicks(6799), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("73ff7ab8-5078-4f25-9e16-703db56cbaa3"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 7, 11, 17, 52, 19, 52, DateTimeKind.Local).AddTicks(6777), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("7defdad7-fca1-488c-b85d-0535ac6369d4"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 11, 17, 52, 19, 52, DateTimeKind.Local).AddTicks(6804), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("a2d06fe7-3345-415f-bd21-e2fafb145011"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 7, 11, 17, 52, 19, 52, DateTimeKind.Local).AddTicks(6769), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("b005041b-9e82-44a2-bad1-eb8381a5e046"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 7, 11, 17, 52, 19, 52, DateTimeKind.Local).AddTicks(6802), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("cdcd9a6d-9189-4fd9-9b7b-5a203a260b3b"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 7, 11, 17, 52, 19, 52, DateTimeKind.Local).AddTicks(6806), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Propriety_ProprietyCharacteristics_CharacteristicsId",
                table: "Propriety",
                column: "CharacteristicsId",
                principalTable: "ProprietyCharacteristics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Propriety_ProprietyContact_ContactId",
                table: "Propriety",
                column: "ContactId",
                principalTable: "ProprietyContact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
