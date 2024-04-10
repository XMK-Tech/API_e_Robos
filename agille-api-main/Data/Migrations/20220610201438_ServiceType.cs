using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class ServiceType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("05d17917-172b-4155-ad27-a57a38d2f76a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("31498287-218d-4c93-b038-63123e3007d6"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3cb63277-131f-410e-aa03-03e42ae00dfe"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("64c57a08-46e8-483a-a8d7-7157dd5d6792"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("9c817d01-e6c1-491b-a2ff-a29c77b0df84"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("a2e6f962-9610-451a-b29e-25df9290bfb4"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("adf854c6-3e6f-487b-b730-e2dfa565ce10"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b6994bf8-4b19-4425-ab66-8e8e7c3b7483"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c108e28f-52db-462f-bca3-c78ad572e510"));

            migrationBuilder.CreateTable(
                name: "ServiceTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTypeDescriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ISSRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ISSAnnualValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ServiceTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypeDescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceTypeDescriptions_ServiceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceTypes",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTypeDescriptions_ServiceTypeId",
                table: "ServiceTypeDescriptions",
                column: "ServiceTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceTypeDescriptions");

            migrationBuilder.DropTable(
                name: "ServiceTypes");

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

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("05d17917-172b-4155-ad27-a57a38d2f76a"), "[[person-name]]", "Name", "Id", new DateTime(2022, 6, 7, 18, 19, 22, 608, DateTimeKind.Local).AddTicks(1948), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("31498287-218d-4c93-b038-63123e3007d6"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 6, 7, 18, 19, 22, 608, DateTimeKind.Local).AddTicks(1972), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("3cb63277-131f-410e-aa03-03e42ae00dfe"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 6, 7, 18, 19, 22, 608, DateTimeKind.Local).AddTicks(1934), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("64c57a08-46e8-483a-a8d7-7157dd5d6792"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 6, 7, 18, 19, 22, 608, DateTimeKind.Local).AddTicks(1946), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("9c817d01-e6c1-491b-a2ff-a29c77b0df84"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 7, 18, 19, 22, 608, DateTimeKind.Local).AddTicks(1969), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("a2e6f962-9610-451a-b29e-25df9290bfb4"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 6, 7, 18, 19, 22, 608, DateTimeKind.Local).AddTicks(1966), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("adf854c6-3e6f-487b-b730-e2dfa565ce10"), "[[person-document]]", "Document", "Id", new DateTime(2022, 6, 7, 18, 19, 22, 608, DateTimeKind.Local).AddTicks(1949), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("b6994bf8-4b19-4425-ab66-8e8e7c3b7483"), "[[description]]", null, null, new DateTime(2022, 6, 7, 18, 19, 22, 608, DateTimeKind.Local).AddTicks(1968), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("c108e28f-52db-462f-bca3-c78ad572e510"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 6, 7, 18, 19, 22, 608, DateTimeKind.Local).AddTicks(1970), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" }
                });
        }
    }
}
