using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class ProprietyOwners : Migration
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

            migrationBuilder.CreateTable(
                name: "ProprietyOwners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProprietyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProprietyOwners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProprietyOwners_Person_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Person",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProprietyOwners_Propriety_ProprietyId",
                        column: x => x.ProprietyId,
                        principalTable: "Propriety",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("078fe48e-d131-4818-926d-1c97d33e643a"), "[[description]]", null, null, new DateTime(2022, 6, 27, 18, 26, 18, 398, DateTimeKind.Local).AddTicks(4995), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("369bbbf6-5f29-4eda-9cd1-e3ceec1506b8"), "[[person-name]]", "Name", "Id", new DateTime(2022, 6, 27, 18, 26, 18, 398, DateTimeKind.Local).AddTicks(4985), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("4240c5f3-9763-472a-9819-bdca3b3435d3"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 6, 27, 18, 26, 18, 398, DateTimeKind.Local).AddTicks(4962), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("610ac9b2-a0a6-4041-877a-31cde8397ffa"), "[[person-document]]", "Document", "Id", new DateTime(2022, 6, 27, 18, 26, 18, 398, DateTimeKind.Local).AddTicks(4986), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("62b0b154-dff3-46b6-9c7d-7cfccbb99f12"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 27, 18, 26, 18, 398, DateTimeKind.Local).AddTicks(4998), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("8a03d284-5d94-4473-8cd2-12491fc72e89"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 27, 18, 26, 18, 398, DateTimeKind.Local).AddTicks(4996), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("9a66d7e4-e005-4e6d-9b8e-91b1104405cc"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 6, 27, 18, 26, 18, 398, DateTimeKind.Local).AddTicks(4973), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("c325f8c8-08b9-48c4-ba7e-f0e50da419d9"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 6, 27, 18, 26, 18, 398, DateTimeKind.Local).AddTicks(4999), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("e0527ddd-2157-48f1-9154-fdeaeb63c7bb"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 6, 27, 18, 26, 18, 398, DateTimeKind.Local).AddTicks(4994), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProprietyOwners_OwnerId",
                table: "ProprietyOwners",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProprietyOwners_ProprietyId",
                table: "ProprietyOwners",
                column: "ProprietyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProprietyOwners");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("078fe48e-d131-4818-926d-1c97d33e643a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("369bbbf6-5f29-4eda-9cd1-e3ceec1506b8"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("4240c5f3-9763-472a-9819-bdca3b3435d3"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("610ac9b2-a0a6-4041-877a-31cde8397ffa"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("62b0b154-dff3-46b6-9c7d-7cfccbb99f12"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("8a03d284-5d94-4473-8cd2-12491fc72e89"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9a66d7e4-e005-4e6d-9b8e-91b1104405cc"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c325f8c8-08b9-48c4-ba7e-f0e50da419d9"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e0527ddd-2157-48f1-9154-fdeaeb63c7bb"));

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
