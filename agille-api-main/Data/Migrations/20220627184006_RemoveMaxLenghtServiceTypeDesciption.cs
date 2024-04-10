using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class RemoveMaxLenghtServiceTypeDesciption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("15bd800b-a1d5-45e9-a627-5eb75edeb1a3"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("289347a2-01a2-40e2-89e7-3550510933d5"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("4c448959-68cc-478a-b5b4-77a11ed7f8ba"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("661e8cf7-52f8-4c9d-bb5b-4833aa5f7d30"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("66c5719c-cf94-4620-97a2-b8b2715911a8"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("8e83e375-9d84-4322-bcb6-5fcf13e3a32a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("bd6c96d6-2e0b-463f-8321-0c3cdd6efa18"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ea2f4ced-4e31-4d27-8052-52d047c225b0"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f5aa6432-2208-4f6e-8341-6de38eb6994a"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ServiceTypeDescriptions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("0530ffeb-cb2b-4b66-a5cc-66e166a40744"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 6, 27, 15, 40, 4, 693, DateTimeKind.Local).AddTicks(4295), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("18121b3e-d16d-47a5-a319-0858ceb6b89e"), "[[description]]", null, null, new DateTime(2022, 6, 27, 15, 40, 4, 693, DateTimeKind.Local).AddTicks(4301), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("39874350-bc04-4d3e-bdc5-8a65a220121b"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 27, 15, 40, 4, 693, DateTimeKind.Local).AddTicks(4312), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("6dab3616-ba7e-4cff-b3d2-022864d37e26"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 6, 27, 15, 40, 4, 693, DateTimeKind.Local).AddTicks(4283), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("775609e1-4fde-4d54-aa03-afedfa8a7a68"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 6, 27, 15, 40, 4, 693, DateTimeKind.Local).AddTicks(4315), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("845adc3b-5b7d-4af6-9f32-229c59a1836e"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 27, 15, 40, 4, 693, DateTimeKind.Local).AddTicks(4313), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("8efece32-5d46-41ca-b400-1ab1e8271084"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 6, 27, 15, 40, 4, 693, DateTimeKind.Local).AddTicks(4299), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("e23e4dfb-5eae-476e-b1c0-86f5f1bcf47e"), "[[person-document]]", "Document", "Id", new DateTime(2022, 6, 27, 15, 40, 4, 693, DateTimeKind.Local).AddTicks(4298), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("e795e981-dbdc-47e7-a1e8-b17f82526387"), "[[person-name]]", "Name", "Id", new DateTime(2022, 6, 27, 15, 40, 4, 693, DateTimeKind.Local).AddTicks(4297), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("0530ffeb-cb2b-4b66-a5cc-66e166a40744"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("18121b3e-d16d-47a5-a319-0858ceb6b89e"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("39874350-bc04-4d3e-bdc5-8a65a220121b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6dab3616-ba7e-4cff-b3d2-022864d37e26"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("775609e1-4fde-4d54-aa03-afedfa8a7a68"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("845adc3b-5b7d-4af6-9f32-229c59a1836e"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("8efece32-5d46-41ca-b400-1ab1e8271084"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e23e4dfb-5eae-476e-b1c0-86f5f1bcf47e"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e795e981-dbdc-47e7-a1e8-b17f82526387"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ServiceTypeDescriptions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("15bd800b-a1d5-45e9-a627-5eb75edeb1a3"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 6, 20, 10, 49, 17, 80, DateTimeKind.Local).AddTicks(4797), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("289347a2-01a2-40e2-89e7-3550510933d5"), "[[person-document]]", "Document", "Id", new DateTime(2022, 6, 20, 10, 49, 17, 80, DateTimeKind.Local).AddTicks(4795), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("4c448959-68cc-478a-b5b4-77a11ed7f8ba"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 6, 20, 10, 49, 17, 80, DateTimeKind.Local).AddTicks(4769), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("661e8cf7-52f8-4c9d-bb5b-4833aa5f7d30"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 20, 10, 49, 17, 80, DateTimeKind.Local).AddTicks(4800), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("66c5719c-cf94-4620-97a2-b8b2715911a8"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 20, 10, 49, 17, 80, DateTimeKind.Local).AddTicks(4801), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("8e83e375-9d84-4322-bcb6-5fcf13e3a32a"), "[[person-name]]", "Name", "Id", new DateTime(2022, 6, 20, 10, 49, 17, 80, DateTimeKind.Local).AddTicks(4794), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("bd6c96d6-2e0b-463f-8321-0c3cdd6efa18"), "[[description]]", null, null, new DateTime(2022, 6, 20, 10, 49, 17, 80, DateTimeKind.Local).AddTicks(4798), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("ea2f4ced-4e31-4d27-8052-52d047c225b0"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 6, 20, 10, 49, 17, 80, DateTimeKind.Local).AddTicks(4802), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("f5aa6432-2208-4f6e-8341-6de38eb6994a"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 6, 20, 10, 49, 17, 80, DateTimeKind.Local).AddTicks(4783), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" }
                });
        }
    }
}
