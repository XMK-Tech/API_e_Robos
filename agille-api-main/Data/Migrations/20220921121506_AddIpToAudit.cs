using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class AddIpToAudit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("169048b3-c4de-42c0-9571-8d0aa697a224"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("2b283bfa-79b6-458f-98e8-f7565aa147b6"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("46a43d5a-855f-4fed-b607-b79454a6c39b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("5aef41a4-511a-4ec5-96ba-bb96b76b40b5"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c9d4b53a-11e9-43df-b66d-0cae8223c83f"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("cfaa196a-7034-4eda-9460-69218ac4a428"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("dbd9e70b-335b-4d8f-ad60-934fa2a1fd87"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e5b683fc-580d-4b84-812d-fb1a41ed9667"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ef63922f-c698-47e8-b3f4-7b31b78fe664"));

            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                table: "Audits",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("099d6db2-d6da-4dab-948e-b2224d805671"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 9, 21, 9, 15, 2, 894, DateTimeKind.Local).AddTicks(1690), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("2f3b58c2-1f74-4027-98fe-9db9dd3aa0ca"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 9, 21, 9, 15, 2, 894, DateTimeKind.Local).AddTicks(1769), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("342225f3-cf42-43c0-8239-18400cfc9132"), "[[person-document]]", "Document", "Id", new DateTime(2022, 9, 21, 9, 15, 2, 894, DateTimeKind.Local).AddTicks(1762), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("441b73cb-ac51-4aa8-9c6a-aa71966b8380"), "[[person-name]]", "Name", "Id", new DateTime(2022, 9, 21, 9, 15, 2, 894, DateTimeKind.Local).AddTicks(1715), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("5e3ffb47-3d53-4bb3-ac2f-c77b6bf10b9e"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 9, 21, 9, 15, 2, 894, DateTimeKind.Local).AddTicks(1713), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("726bb1d2-4990-47e8-b7c2-ab075dc1f993"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 9, 21, 9, 15, 2, 894, DateTimeKind.Local).AddTicks(1764), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("97a7a016-a5ca-4a9a-bb81-d2119dd9f9dd"), "[[description]]", null, null, new DateTime(2022, 9, 21, 9, 15, 2, 894, DateTimeKind.Local).AddTicks(1765), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("c1c3f4ae-9634-4c51-9d18-17c33ae97d25"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 9, 21, 9, 15, 2, 894, DateTimeKind.Local).AddTicks(1768), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("feaea179-37e4-40fe-9789-c78b80591537"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 9, 21, 9, 15, 2, 894, DateTimeKind.Local).AddTicks(1767), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("099d6db2-d6da-4dab-948e-b2224d805671"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("2f3b58c2-1f74-4027-98fe-9db9dd3aa0ca"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("342225f3-cf42-43c0-8239-18400cfc9132"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("441b73cb-ac51-4aa8-9c6a-aa71966b8380"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("5e3ffb47-3d53-4bb3-ac2f-c77b6bf10b9e"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("726bb1d2-4990-47e8-b7c2-ab075dc1f993"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("97a7a016-a5ca-4a9a-bb81-d2119dd9f9dd"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c1c3f4ae-9634-4c51-9d18-17c33ae97d25"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("feaea179-37e4-40fe-9789-c78b80591537"));

            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "Audits");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("169048b3-c4de-42c0-9571-8d0aa697a224"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 9, 19, 11, 22, 58, 280, DateTimeKind.Local).AddTicks(7486), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("2b283bfa-79b6-458f-98e8-f7565aa147b6"), "[[person-document]]", "Document", "Id", new DateTime(2022, 9, 19, 11, 22, 58, 280, DateTimeKind.Local).AddTicks(7484), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("46a43d5a-855f-4fed-b607-b79454a6c39b"), "[[description]]", null, null, new DateTime(2022, 9, 19, 11, 22, 58, 280, DateTimeKind.Local).AddTicks(7487), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("5aef41a4-511a-4ec5-96ba-bb96b76b40b5"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 9, 19, 11, 22, 58, 280, DateTimeKind.Local).AddTicks(7438), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("c9d4b53a-11e9-43df-b66d-0cae8223c83f"), "[[person-name]]", "Name", "Id", new DateTime(2022, 9, 19, 11, 22, 58, 280, DateTimeKind.Local).AddTicks(7463), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("cfaa196a-7034-4eda-9460-69218ac4a428"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 9, 19, 11, 22, 58, 280, DateTimeKind.Local).AddTicks(7490), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("dbd9e70b-335b-4d8f-ad60-934fa2a1fd87"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 9, 19, 11, 22, 58, 280, DateTimeKind.Local).AddTicks(7461), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("e5b683fc-580d-4b84-812d-fb1a41ed9667"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 9, 19, 11, 22, 58, 280, DateTimeKind.Local).AddTicks(7489), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("ef63922f-c698-47e8-b3f4-7b31b78fe664"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 9, 19, 11, 22, 58, 280, DateTimeKind.Local).AddTicks(7491), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" }
                });
        }
    }
}
