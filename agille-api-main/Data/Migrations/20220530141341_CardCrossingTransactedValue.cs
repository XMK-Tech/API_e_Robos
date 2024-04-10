using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgilleApi.Data.Migrations
{
    public partial class CardCrossingTransactedValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("3fb4be2b-1104-4e68-846e-84590a782a62"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("47981f05-b8eb-45f1-96e6-876f473475db"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("7df68cfe-7c34-4087-91a1-ccb249de99a9"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b08b146c-acde-42b4-8b35-6c422f309b98"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("b6afdc7d-2b76-45fa-b1c8-df8757232d7d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("cc17b435-a091-4b86-bdc8-409fb62cf72a"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("dd37779a-bcc2-4e9b-b718-eb892dc761a2"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("ec186830-ec7b-4df3-8446-2de09bae9d63"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("f618f4d2-b85e-41dd-bdde-c1e441ece5bc"));

            migrationBuilder.AlterColumn<decimal>(
                name: "DeclaredRate",
                table: "CardCrossing",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "AverageRate",
                table: "CardCrossing",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "AmountOnDeclaredRate",
                table: "CardCrossing",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "AmountOnAverageRate",
                table: "CardCrossing",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "CardCrossing",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<decimal>(
                name: "DeclaredTransactedValue",
                table: "CardCrossing",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("0c8e4c61-c4a8-450e-a079-ba5b48df3f89"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 5, 30, 11, 13, 40, 84, DateTimeKind.Local).AddTicks(3673), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("22a62d11-959e-4b3a-9091-dc690d363d1d"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 5, 30, 11, 13, 40, 84, DateTimeKind.Local).AddTicks(3674), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("5fa36da4-77e0-4a4e-985a-2232de4465cf"), "[[person-document]]", "Document", "Id", new DateTime(2022, 5, 30, 11, 13, 40, 84, DateTimeKind.Local).AddTicks(3654), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("63580f10-08af-43ec-ab75-d4908bf00309"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 5, 30, 11, 13, 40, 84, DateTimeKind.Local).AddTicks(3658), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("8debddbb-a755-43b1-a140-639da0b0ff57"), "[[description]]", null, null, new DateTime(2022, 5, 30, 11, 13, 40, 84, DateTimeKind.Local).AddTicks(3657), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("c04919e6-42c7-4b64-ac34-a3f038a1b6ab"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 5, 30, 11, 13, 40, 84, DateTimeKind.Local).AddTicks(3640), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("d53633de-e0f3-4b20-b515-8bd3c9414149"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 5, 30, 11, 13, 40, 84, DateTimeKind.Local).AddTicks(3655), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("e794f244-32db-43a2-af40-7d927cdbe8c5"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 5, 30, 11, 13, 40, 84, DateTimeKind.Local).AddTicks(3651), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("fe5dd84f-0d13-42c4-8247-3e5962ff87ca"), "[[person-name]]", "Name", "Id", new DateTime(2022, 5, 30, 11, 13, 40, 84, DateTimeKind.Local).AddTicks(3653), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("0c8e4c61-c4a8-450e-a079-ba5b48df3f89"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("22a62d11-959e-4b3a-9091-dc690d363d1d"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("5fa36da4-77e0-4a4e-985a-2232de4465cf"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("63580f10-08af-43ec-ab75-d4908bf00309"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("8debddbb-a755-43b1-a140-639da0b0ff57"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("c04919e6-42c7-4b64-ac34-a3f038a1b6ab"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("d53633de-e0f3-4b20-b515-8bd3c9414149"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("e794f244-32db-43a2-af40-7d927cdbe8c5"));

            migrationBuilder.DeleteData(
                table: "DynamicFieldOptions",
                keyColumn: "Id",
                keyValue: new Guid("fe5dd84f-0d13-42c4-8247-3e5962ff87ca"));

            migrationBuilder.DropColumn(
                name: "DeclaredTransactedValue",
                table: "CardCrossing");

            migrationBuilder.AlterColumn<double>(
                name: "DeclaredRate",
                table: "CardCrossing",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "AverageRate",
                table: "CardCrossing",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "AmountOnDeclaredRate",
                table: "CardCrossing",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "AmountOnAverageRate",
                table: "CardCrossing",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "CardCrossing",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.InsertData(
                table: "DynamicFieldOptions",
                columns: new[] { "Id", "Code", "Column", "ColumnKey", "CreatedAt", "DisplayColumn", "DisplayTable", "LastUpdateAt", "Schema", "Table" },
                values: new object[,]
                {
                    { new Guid("3fb4be2b-1104-4e68-846e-84590a782a62"), "[[person-display-name]]", "DisplayName", "Id", new DateTime(2022, 5, 25, 17, 30, 27, 923, DateTimeKind.Local).AddTicks(1064), "Nome de exibição", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("47981f05-b8eb-45f1-96e6-876f473475db"), "[[person-document]]", "Document", "Id", new DateTime(2022, 5, 25, 17, 30, 27, 923, DateTimeKind.Local).AddTicks(1062), "Document", "Person", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("7df68cfe-7c34-4087-91a1-ccb249de99a9"), "[[confirmation-token]]", "ConfirmationToken", "Id", new DateTime(2022, 5, 25, 17, 30, 27, 923, DateTimeKind.Local).AddTicks(1053), "ConfirmationToken", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" },
                    { new Guid("b08b146c-acde-42b4-8b35-6c422f309b98"), "[[description]]", null, null, new DateTime(2022, 5, 25, 17, 30, 27, 923, DateTimeKind.Local).AddTicks(1065), "Descrição do e-mail", "Others", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("b6afdc7d-2b76-45fa-b1c8-df8757232d7d"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 5, 25, 17, 30, 27, 923, DateTimeKind.Local).AddTicks(1069), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("cc17b435-a091-4b86-bdc8-409fb62cf72a"), "[[attachment-url]]", "Url", "Id", new DateTime(2022, 5, 25, 17, 30, 27, 923, DateTimeKind.Local).AddTicks(1067), "Url", "Attachment", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Attachment" },
                    { new Guid("dd37779a-bcc2-4e9b-b718-eb892dc761a2"), "[[person-name]]", "Name", "Id", new DateTime(2022, 5, 25, 17, 30, 27, 923, DateTimeKind.Local).AddTicks(1061), "Nome", "Pessoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Person" },
                    { new Guid("ec186830-ec7b-4df3-8446-2de09bae9d63"), "[[phone-number]]", "Number", "Id", new DateTime(2022, 5, 25, 17, 30, 27, 923, DateTimeKind.Local).AddTicks(1072), "Number", "Phone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "Phone" },
                    { new Guid("f618f4d2-b85e-41dd-bdde-c1e441ece5bc"), "[[user-token]]", "SetPasswordToken", "Id", new DateTime(2022, 5, 25, 17, 30, 27, 923, DateTimeKind.Local).AddTicks(1041), "Token", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "[dbo]", "User" }
                });
        }
    }
}
