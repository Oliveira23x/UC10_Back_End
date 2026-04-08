using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleEstoque.API.Migrations
{
    /// <inheritdoc />
    public partial class segundaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensPedido_Pedidos_PedidoQuantidade",
                table: "ItensPedido");

            migrationBuilder.RenameColumn(
                name: "Quantidade",
                table: "Pedidos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PedidoQuantidade",
                table: "ItensPedido",
                newName: "PedidoId");

            migrationBuilder.RenameIndex(
                name: "IX_ItensPedido_PedidoQuantidade",
                table: "ItensPedido",
                newName: "IX_ItensPedido_PedidoId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataPedido",
                table: "Pedidos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_ItensPedido_Pedidos_PedidoId",
                table: "ItensPedido",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensPedido_Pedidos_PedidoId",
                table: "ItensPedido");

            migrationBuilder.DropColumn(
                name: "DataPedido",
                table: "Pedidos");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Pedidos",
                newName: "Quantidade");

            migrationBuilder.RenameColumn(
                name: "PedidoId",
                table: "ItensPedido",
                newName: "PedidoQuantidade");

            migrationBuilder.RenameIndex(
                name: "IX_ItensPedido_PedidoId",
                table: "ItensPedido",
                newName: "IX_ItensPedido_PedidoQuantidade");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensPedido_Pedidos_PedidoQuantidade",
                table: "ItensPedido",
                column: "PedidoQuantidade",
                principalTable: "Pedidos",
                principalColumn: "Quantidade");
        }
    }
}
