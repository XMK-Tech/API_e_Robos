using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgilleApi.Data.Migrations
{
    public partial class DataCrossingResponsible : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("1957446f-af11-48ef-88a7-f5fe278c744a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("1d0f0c12-ca88-4951-b6f9-f405e9499338"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("20a9a9f0-c885-48e9-abf3-ec1a3fedc089"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("56aefcd1-f550-4192-a5ab-798ee082c1c0"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6124d06a-b7f7-4609-b8e9-d670c64774f5"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("67699684-88d5-47d9-873a-cbc1112a874a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("89e36504-a3c5-4cd4-9291-aa57dc5243c5"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("90ef1f97-9a26-4cb3-afd9-9123c8afc0fb"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d3274747-4aff-4d1c-8294-e56c22ea0172"));

            migrationBuilder.AddColumn<Guid>(
                name: "ResponsibleId",
                table: "DataCrossing",
                nullable: true);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("2512d9bd-c9ca-4380-9c12-2dea77f00412"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 2, 18, 18, 15, 11, 617, DateTimeKind.Local).AddTicks(5867), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("5b522540-42a4-4434-9ab7-edcaba2cbab7"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 2, 18, 18, 15, 11, 618, DateTimeKind.Local).AddTicks(6516), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("4122dd41-adf2-49ae-8f8b-5add315b3682"), "[[person-name]]", "Name", "Id", new DateTime(2022, 2, 18, 18, 15, 11, 618, DateTimeKind.Local).AddTicks(6603), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("47a62261-4f43-4e28-bb5c-6e5cd7a7587b"), "[[person-document]]", "Document", "Id", new DateTime(2022, 2, 18, 18, 15, 11, 618, DateTimeKind.Local).AddTicks(6606), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("0e878d46-ac9a-4ffd-a22c-a387b128e9b0"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 2, 18, 18, 15, 11, 618, DateTimeKind.Local).AddTicks(6609), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("01fc4efc-d9cb-4bc8-878e-c49f7b5c1e60"), "[[description]]", null, null, new DateTime(2022, 2, 18, 18, 15, 11, 618, DateTimeKind.Local).AddTicks(6622), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("684f1a3d-e1af-4c6a-8b23-24f140b32eb7"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 18, 18, 15, 11, 618, DateTimeKind.Local).AddTicks(6624), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("a3537f57-19b6-4d5a-8b58-e5be7e5c31ee"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 18, 18, 15, 11, 618, DateTimeKind.Local).AddTicks(6626), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("a82c554e-ebe3-4033-bf6f-4c0784a4c85a"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 2, 18, 18, 15, 11, 618, DateTimeKind.Local).AddTicks(6629), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("01fc4efc-d9cb-4bc8-878e-c49f7b5c1e60"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("0e878d46-ac9a-4ffd-a22c-a387b128e9b0"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("2512d9bd-c9ca-4380-9c12-2dea77f00412"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("4122dd41-adf2-49ae-8f8b-5add315b3682"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("47a62261-4f43-4e28-bb5c-6e5cd7a7587b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("5b522540-42a4-4434-9ab7-edcaba2cbab7"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("684f1a3d-e1af-4c6a-8b23-24f140b32eb7"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a3537f57-19b6-4d5a-8b58-e5be7e5c31ee"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a82c554e-ebe3-4033-bf6f-4c0784a4c85a"));

            migrationBuilder.DropColumn(
                name: "ResponsibleId",
                table: "DataCrossing");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("20a9a9f0-c885-48e9-abf3-ec1a3fedc089"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 2, 18, 11, 26, 50, 528, DateTimeKind.Local).AddTicks(9725), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("1957446f-af11-48ef-88a7-f5fe278c744a"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 2, 18, 11, 26, 50, 530, DateTimeKind.Local).AddTicks(9543), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("89e36504-a3c5-4cd4-9291-aa57dc5243c5"), "[[person-name]]", "Name", "Id", new DateTime(2022, 2, 18, 11, 26, 50, 530, DateTimeKind.Local).AddTicks(9704), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("6124d06a-b7f7-4609-b8e9-d670c64774f5"), "[[person-document]]", "Document", "Id", new DateTime(2022, 2, 18, 11, 26, 50, 530, DateTimeKind.Local).AddTicks(9712), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("67699684-88d5-47d9-873a-cbc1112a874a"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 2, 18, 11, 26, 50, 530, DateTimeKind.Local).AddTicks(9716), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("90ef1f97-9a26-4cb3-afd9-9123c8afc0fb"), "[[description]]", null, null, new DateTime(2022, 2, 18, 11, 26, 50, 530, DateTimeKind.Local).AddTicks(9722), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("d3274747-4aff-4d1c-8294-e56c22ea0172"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 18, 11, 26, 50, 530, DateTimeKind.Local).AddTicks(9726), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("1d0f0c12-ca88-4951-b6f9-f405e9499338"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 2, 18, 11, 26, 50, 530, DateTimeKind.Local).AddTicks(9730), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("56aefcd1-f550-4192-a5ab-798ee082c1c0"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 2, 18, 11, 26, 50, 530, DateTimeKind.Local).AddTicks(9749), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });
        }
    }
}
