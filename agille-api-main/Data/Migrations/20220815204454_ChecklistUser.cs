using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class ChecklistUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("03d77956-4cfd-41e1-8f02-9901ad78faef"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("2932c19f-54a1-477b-b03f-ab65a5080cdd"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("36101509-66da-4ad0-a046-1a500eebe72c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("58d779e1-6fcd-4653-838f-56810a02bd0a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("76dd079d-dc1f-426c-a3a3-4b71a53f834c"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("968b0358-c863-40b0-ad46-0e4e96dff995"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b1b7f7ea-e4f4-4287-8509-c3b083218af3"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("deb417be-81b1-47c8-8da5-5de9394cc154"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e244633e-687e-4e8c-9087-50068a03a43f"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Checklists",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("21007289-6a0e-49d8-bd3c-608affdea9eb"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 8, 15, 17, 44, 52, 982, DateTimeKind.Local).AddTicks(1089), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("24ac716f-4efb-4fe2-a247-e2b1f5ca08f6"), "[[person-document]]", "Document", "Id", new DateTime(2022, 8, 15, 17, 44, 52, 982, DateTimeKind.Local).AddTicks(1092), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("6fe29ce4-ef84-472f-bc6d-56b9b3918050"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 8, 15, 17, 44, 52, 982, DateTimeKind.Local).AddTicks(1111), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("a7febb48-afaa-4ab6-b560-2bc62a943048"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 8, 15, 17, 44, 52, 982, DateTimeKind.Local).AddTicks(1094), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("b60070c2-8a3a-4a5d-a83c-88bca76c314d"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 8, 15, 17, 44, 52, 982, DateTimeKind.Local).AddTicks(1112), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("c0ebae45-9c31-411c-b450-d37bb72fd758"), "[[person-name]]", "Name", "Id", new DateTime(2022, 8, 15, 17, 44, 52, 982, DateTimeKind.Local).AddTicks(1091), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("d307caf9-2145-4003-a59d-46a994b55f01"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 8, 15, 17, 44, 52, 982, DateTimeKind.Local).AddTicks(1109), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("e2f4b53a-7052-48e7-bfdd-f18ef4629cb5"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 8, 15, 17, 44, 52, 982, DateTimeKind.Local).AddTicks(1073), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("f1542c1a-2736-4278-a13e-fd282474bb71"), "[[description]]", null, null, new DateTime(2022, 8, 15, 17, 44, 52, 982, DateTimeKind.Local).AddTicks(1095), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("21007289-6a0e-49d8-bd3c-608affdea9eb"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("24ac716f-4efb-4fe2-a247-e2b1f5ca08f6"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6fe29ce4-ef84-472f-bc6d-56b9b3918050"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a7febb48-afaa-4ab6-b560-2bc62a943048"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b60070c2-8a3a-4a5d-a83c-88bca76c314d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c0ebae45-9c31-411c-b450-d37bb72fd758"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d307caf9-2145-4003-a59d-46a994b55f01"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e2f4b53a-7052-48e7-bfdd-f18ef4629cb5"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f1542c1a-2736-4278-a13e-fd282474bb71"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Checklists");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("03d77956-4cfd-41e1-8f02-9901ad78faef"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 8, 15, 17, 5, 40, 544, DateTimeKind.Local).AddTicks(902), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("2932c19f-54a1-477b-b03f-ab65a5080cdd"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 8, 15, 17, 5, 40, 544, DateTimeKind.Local).AddTicks(856), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("36101509-66da-4ad0-a046-1a500eebe72c"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 8, 15, 17, 5, 40, 544, DateTimeKind.Local).AddTicks(904), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("58d779e1-6fcd-4653-838f-56810a02bd0a"), "[[person-document]]", "Document", "Id", new DateTime(2022, 8, 15, 17, 5, 40, 544, DateTimeKind.Local).AddTicks(854), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("76dd079d-dc1f-426c-a3a3-4b71a53f834c"), "[[person-name]]", "Name", "Id", new DateTime(2022, 8, 15, 17, 5, 40, 544, DateTimeKind.Local).AddTicks(853), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("968b0358-c863-40b0-ad46-0e4e96dff995"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 8, 15, 17, 5, 40, 544, DateTimeKind.Local).AddTicks(841), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("b1b7f7ea-e4f4-4287-8509-c3b083218af3"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 8, 15, 17, 5, 40, 544, DateTimeKind.Local).AddTicks(905), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("deb417be-81b1-47c8-8da5-5de9394cc154"), "[[description]]", null, null, new DateTime(2022, 8, 15, 17, 5, 40, 544, DateTimeKind.Local).AddTicks(900), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("e244633e-687e-4e8c-9087-50068a03a43f"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 8, 15, 17, 5, 40, 544, DateTimeKind.Local).AddTicks(825), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" }
                });
        }
    }
}
