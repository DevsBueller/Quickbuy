using Microsoft.EntityFrameworkCore.Migrations;

namespace QuickBuy.Repositorio.Migrations
{
    public partial class CargaFormaPagamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Paymentform",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Forma de Pagamento Boleto", "Boleto" });

            migrationBuilder.InsertData(
                table: "Paymentform",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, "Cartão de Crédito", "Cartão de Crédito" });

            migrationBuilder.InsertData(
                table: "Paymentform",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 3, "Forma de Depósito", "Depósito" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Paymentform",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Paymentform",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Paymentform",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
