using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class JuridicalPersonServiceType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("4050a0b4-f238-4b79-9a88-5a9bea9f30e2"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("5f9de0d8-31c7-4db7-ade0-9352433da151"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("68062a64-aaa8-4448-b277-e2cf7b173099"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6bc8211a-b241-41e7-b814-6c90170ea0ce"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("7820358a-23ac-46d6-831c-92399390cecf"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("8be1e047-a5b6-4c9f-b1f6-4ef65c8837c8"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("97a763fe-db3d-4a4f-9699-a7baedf5c516"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e6d071e4-343f-4e3d-85c4-57b610e81968"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f57df8db-8634-44ed-83fb-24d07b4f16e3"));

            migrationBuilder.CreateTable(
                name: "JuridicalPersonServiceTypeDescriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceTypeDescriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JuridicalPersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JuridicalPersonServiceTypeDescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JuridicalPersonServiceTypeDescriptions_JuridicalPerson_JuridicalPersonId",
                        column: x => x.JuridicalPersonId,
                        principalTable: "JuridicalPerson",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JuridicalPersonServiceTypeDescriptions_ServiceTypeDescriptions_ServiceTypeDescriptionId",
                        column: x => x.ServiceTypeDescriptionId,
                        principalTable: "ServiceTypeDescriptions",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("229a444c-ff4b-475e-a398-a9b9dc18e792"), "[[person-document]]", "Document", "Id", new DateTime(2022, 6, 10, 19, 47, 13, 135, DateTimeKind.Local).AddTicks(8743), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("36a9a977-1495-435c-97f1-661458aea733"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 6, 10, 19, 47, 13, 135, DateTimeKind.Local).AddTicks(8740), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("48660ec5-d0fc-4ff4-9cdb-e8ad995399c0"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 10, 19, 47, 13, 135, DateTimeKind.Local).AddTicks(8749), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("648c61dd-f62d-454f-93d9-04f6f6af4e6f"), "[[description]]", null, null, new DateTime(2022, 6, 10, 19, 47, 13, 135, DateTimeKind.Local).AddTicks(8746), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("6b356fbb-7ba8-428a-8b86-6175fe6df4f8"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 6, 10, 19, 47, 13, 135, DateTimeKind.Local).AddTicks(8753), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("bb668874-f69d-41d8-8e60-1a43da424d09"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 6, 10, 19, 47, 13, 135, DateTimeKind.Local).AddTicks(8726), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("c13df26b-7565-4ddd-a612-b8af050433fa"), "[[person-name]]", "Name", "Id", new DateTime(2022, 6, 10, 19, 47, 13, 135, DateTimeKind.Local).AddTicks(8742), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("cc5f4960-722d-498b-9e0f-a06582dcd554"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 10, 19, 47, 13, 135, DateTimeKind.Local).AddTicks(8748), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("f2f0f4bc-a67b-4c7c-bccb-1a5755f58959"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 6, 10, 19, 47, 13, 135, DateTimeKind.Local).AddTicks(8745), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_JuridicalPersonServiceTypeDescriptions_JuridicalPersonId",
                table: "JuridicalPersonServiceTypeDescriptions",
                column: "JuridicalPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_JuridicalPersonServiceTypeDescriptions_ServiceTypeDescriptionId",
                table: "JuridicalPersonServiceTypeDescriptions",
                column: "ServiceTypeDescriptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JuridicalPersonServiceTypeDescriptions");

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("229a444c-ff4b-475e-a398-a9b9dc18e792"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("36a9a977-1495-435c-97f1-661458aea733"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("48660ec5-d0fc-4ff4-9cdb-e8ad995399c0"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("648c61dd-f62d-454f-93d9-04f6f6af4e6f"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("6b356fbb-7ba8-428a-8b86-6175fe6df4f8"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("bb668874-f69d-41d8-8e60-1a43da424d09"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c13df26b-7565-4ddd-a612-b8af050433fa"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("cc5f4960-722d-498b-9e0f-a06582dcd554"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f2f0f4bc-a67b-4c7c-bccb-1a5755f58959"));

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("4050a0b4-f238-4b79-9a88-5a9bea9f30e2"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 6, 10, 17, 14, 37, 773, DateTimeKind.Local).AddTicks(8411), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("5f9de0d8-31c7-4db7-ade0-9352433da151"), "[[person-document]]", "Document", "Id", new DateTime(2022, 6, 10, 17, 14, 37, 773, DateTimeKind.Local).AddTicks(8409), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("68062a64-aaa8-4448-b277-e2cf7b173099"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 10, 17, 14, 37, 773, DateTimeKind.Local).AddTicks(8423), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("6bc8211a-b241-41e7-b814-6c90170ea0ce"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 6, 10, 17, 14, 37, 773, DateTimeKind.Local).AddTicks(8425), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("7820358a-23ac-46d6-831c-92399390cecf"), "[[person-name]]", "Name", "Id", new DateTime(2022, 6, 10, 17, 14, 37, 773, DateTimeKind.Local).AddTicks(8408), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("8be1e047-a5b6-4c9f-b1f6-4ef65c8837c8"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 10, 17, 14, 37, 773, DateTimeKind.Local).AddTicks(8422), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("97a763fe-db3d-4a4f-9699-a7baedf5c516"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 6, 10, 17, 14, 37, 773, DateTimeKind.Local).AddTicks(8406), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("e6d071e4-343f-4e3d-85c4-57b610e81968"), "[[description]]", null, null, new DateTime(2022, 6, 10, 17, 14, 37, 773, DateTimeKind.Local).AddTicks(8412), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("f57df8db-8634-44ed-83fb-24d07b4f16e3"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 6, 10, 17, 14, 37, 773, DateTimeKind.Local).AddTicks(8396), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" }
                });
        }
    }
}
