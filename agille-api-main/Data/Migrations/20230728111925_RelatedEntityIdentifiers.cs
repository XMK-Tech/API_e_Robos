using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class RelatedEntityIdentifiers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("0d9f85f3-42b6-4424-a396-9031d95cd6a8"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("20db6234-fb6d-4594-8023-dc8a4624cdda"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("2645eaf2-a5b0-41af-b486-74a5e75c65f2"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("39471a10-041c-45dc-b7f9-cee6bab79759"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("4d47284d-ef51-46ec-8f19-39cb1df1a735"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("514acc24-c235-4e81-83ad-343aba9a25d4"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("55952d31-f1e4-45b9-affc-21a743d67612"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("97d454a9-432d-4641-9e03-fcf378f29438"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b7859d0e-6b76-4a81-97be-8ca5c21577fd"));

            migrationBuilder.AddColumn<bool>(
                name: "IsFromMainEntity",
                table: "Revenues",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "RelatedEntityId",
                table: "Revenues",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFromMainEntity",
                table: "Expenses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "RelatedEntityId",
                table: "Expenses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFromMainEntity",
                table: "Collections",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "RelatedEntityId",
                table: "Collections",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("38d3559b-219c-4246-847e-e1f5baaf0a0d"), "[[person-name]]", "Name", "Id", new DateTime(2023, 7, 28, 8, 19, 20, 491, DateTimeKind.Local).AddTicks(9784), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("3e7fe08c-ace7-4e31-b5ae-04a88c0bfc13"), "[[phone-number]]", "Number", "Id", new DateTime(2023, 7, 28, 8, 19, 20, 491, DateTimeKind.Local).AddTicks(9813), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("556e724b-4cda-4ad5-8559-6d639f83e366"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2023, 7, 28, 8, 19, 20, 491, DateTimeKind.Local).AddTicks(9782), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("5b00c4cc-524e-4ffe-b07e-85f730dea354"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2023, 7, 28, 8, 19, 20, 491, DateTimeKind.Local).AddTicks(9789), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("9c57b3cb-5bd3-448c-bc85-36b3a9a668c8"), "[[description]]", null, null, new DateTime(2023, 7, 28, 8, 19, 20, 491, DateTimeKind.Local).AddTicks(9805), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("a4d799ce-6325-4be8-85ba-85a1476d2536"), "[[person-document]]", "Document", "Id", new DateTime(2023, 7, 28, 8, 19, 20, 491, DateTimeKind.Local).AddTicks(9786), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("ec3fb199-f681-4c60-8e09-2c829aa0623b"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2023, 7, 28, 8, 19, 20, 491, DateTimeKind.Local).AddTicks(9766), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("fa8cd34f-be22-4ad3-9fc3-38e536c11fdc"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 7, 28, 8, 19, 20, 491, DateTimeKind.Local).AddTicks(9807), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("ffa40514-e117-4dcb-a6bf-e1f35466ea6f"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 7, 28, 8, 19, 20, 491, DateTimeKind.Local).AddTicks(9809), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Revenues_RelatedEntityId",
                table: "Revenues",
                column: "RelatedEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_RelatedEntityId",
                table: "Expenses",
                column: "RelatedEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_RelatedEntityId",
                table: "Collections",
                column: "RelatedEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_RelatedEntities_RelatedEntityId",
                table: "Collections",
                column: "RelatedEntityId",
                principalTable: "RelatedEntities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_RelatedEntities_RelatedEntityId",
                table: "Expenses",
                column: "RelatedEntityId",
                principalTable: "RelatedEntities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Revenues_RelatedEntities_RelatedEntityId",
                table: "Revenues",
                column: "RelatedEntityId",
                principalTable: "RelatedEntities",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_RelatedEntities_RelatedEntityId",
                table: "Collections");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_RelatedEntities_RelatedEntityId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Revenues_RelatedEntities_RelatedEntityId",
                table: "Revenues");

            migrationBuilder.DropIndex(
                name: "IX_Revenues_RelatedEntityId",
                table: "Revenues");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_RelatedEntityId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Collections_RelatedEntityId",
                table: "Collections");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("38d3559b-219c-4246-847e-e1f5baaf0a0d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3e7fe08c-ace7-4e31-b5ae-04a88c0bfc13"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("556e724b-4cda-4ad5-8559-6d639f83e366"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("5b00c4cc-524e-4ffe-b07e-85f730dea354"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9c57b3cb-5bd3-448c-bc85-36b3a9a668c8"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a4d799ce-6325-4be8-85ba-85a1476d2536"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ec3fb199-f681-4c60-8e09-2c829aa0623b"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("fa8cd34f-be22-4ad3-9fc3-38e536c11fdc"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ffa40514-e117-4dcb-a6bf-e1f35466ea6f"));

            migrationBuilder.DropColumn(
                name: "IsFromMainEntity",
                table: "Revenues");

            migrationBuilder.DropColumn(
                name: "RelatedEntityId",
                table: "Revenues");

            migrationBuilder.DropColumn(
                name: "IsFromMainEntity",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "RelatedEntityId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "IsFromMainEntity",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "RelatedEntityId",
                table: "Collections");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("0d9f85f3-42b6-4424-a396-9031d95cd6a8"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 7, 18, 20, 58, 48, 134, DateTimeKind.Local).AddTicks(3435), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("20db6234-fb6d-4594-8023-dc8a4624cdda"), "[[phone-number]]", "Number", "Id", new DateTime(2023, 7, 18, 20, 58, 48, 134, DateTimeKind.Local).AddTicks(3438), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("2645eaf2-a5b0-41af-b486-74a5e75c65f2"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2023, 7, 18, 20, 58, 48, 134, DateTimeKind.Local).AddTicks(3432), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("39471a10-041c-45dc-b7f9-cee6bab79759"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2023, 7, 18, 20, 58, 48, 134, DateTimeKind.Local).AddTicks(3412), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("4d47284d-ef51-46ec-8f19-39cb1df1a735"), "[[person-name]]", "Name", "Id", new DateTime(2023, 7, 18, 20, 58, 48, 134, DateTimeKind.Local).AddTicks(3414), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("514acc24-c235-4e81-83ad-343aba9a25d4"), "[[person-document]]", "Document", "Id", new DateTime(2023, 7, 18, 20, 58, 48, 134, DateTimeKind.Local).AddTicks(3415), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("55952d31-f1e4-45b9-affc-21a743d67612"), "[[description]]", null, null, new DateTime(2023, 7, 18, 20, 58, 48, 134, DateTimeKind.Local).AddTicks(3434), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("97d454a9-432d-4641-9e03-fcf378f29438"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2023, 7, 18, 20, 58, 48, 134, DateTimeKind.Local).AddTicks(3397), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("b7859d0e-6b76-4a81-97be-8ca5c21577fd"), "[[attachment-url]]", "Url", "Id", new DateTime(2023, 7, 18, 20, 58, 48, 134, DateTimeKind.Local).AddTicks(3436), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" }
                });
        }
    }
}
