using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiendaAVritmica.BD.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarCarritoCarritoProductoCompraDetalleConsultaPagoStockMovimientoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Usuario_UQ",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_StockMovimientos_ProductoId",
                table: "StockMovimientos");

            migrationBuilder.DropIndex(
                name: "StockMovimiento_UQ",
                table: "StockMovimientos");

            migrationBuilder.DropIndex(
                name: "IX_Pagos_CarritoId",
                table: "Pagos");

            migrationBuilder.DropIndex(
                name: "Pago_UQ",
                table: "Pagos");

            migrationBuilder.DropIndex(
                name: "Consulta_UQ",
                table: "Consultas");

            migrationBuilder.DropIndex(
                name: "IX_Consultas_UsuarioId",
                table: "Consultas");

            migrationBuilder.DropIndex(
                name: "Compra_UQ",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Compras_UsuarioId",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "CompraDetalle_UQ",
                table: "CompraDetalles");

            migrationBuilder.DropIndex(
                name: "IX_CompraDetalles_CompraId",
                table: "CompraDetalles");

            migrationBuilder.DropIndex(
                name: "Carrito_UQ",
                table: "Carritos");

            migrationBuilder.DropIndex(
                name: "IX_Carritos_UsuarioId",
                table: "Carritos");

            migrationBuilder.DropIndex(
                name: "CarritoProducto_UQ",
                table: "CarritoProductos");

            migrationBuilder.DropIndex(
                name: "IX_CarritoProductos_CarritoId",
                table: "CarritoProductos");

            migrationBuilder.AlterColumn<string>(
                name: "TipoUsuario",
                table: "Usuarios",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "Usuario_UQ",
                table: "Usuarios",
                columns: new[] { "Nombre", "Apellido" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "StockMovimiento_UQ",
                table: "StockMovimientos",
                columns: new[] { "ProductoId", "TipoMovimiento" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Pago_UQ",
                table: "Pagos",
                columns: new[] { "CarritoId", "FechaPago" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Consulta_UQ",
                table: "Consultas",
                columns: new[] { "UsuarioId", "Nombre" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Compra_UQ",
                table: "Compras",
                columns: new[] { "UsuarioId", "Fecha" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "CompraDetalle_UQ",
                table: "CompraDetalles",
                columns: new[] { "CompraId", "ProductoId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Compra_UQ",
                table: "Carritos",
                columns: new[] { "UsuarioId", "FechaCreacion" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "CarritoProducto_UQ",
                table: "CarritoProductos",
                columns: new[] { "CarritoId", "ProductoId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Usuario_UQ",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "StockMovimiento_UQ",
                table: "StockMovimientos");

            migrationBuilder.DropIndex(
                name: "Pago_UQ",
                table: "Pagos");

            migrationBuilder.DropIndex(
                name: "Consulta_UQ",
                table: "Consultas");

            migrationBuilder.DropIndex(
                name: "Compra_UQ",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "CompraDetalle_UQ",
                table: "CompraDetalles");

            migrationBuilder.DropIndex(
                name: "Compra_UQ",
                table: "Carritos");

            migrationBuilder.DropIndex(
                name: "CarritoProducto_UQ",
                table: "CarritoProductos");

            migrationBuilder.AlterColumn<string>(
                name: "TipoUsuario",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.CreateIndex(
                name: "Usuario_UQ",
                table: "Usuarios",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockMovimientos_ProductoId",
                table: "StockMovimientos",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "StockMovimiento_UQ",
                table: "StockMovimientos",
                column: "TipoMovimiento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_CarritoId",
                table: "Pagos",
                column: "CarritoId");

            migrationBuilder.CreateIndex(
                name: "Pago_UQ",
                table: "Pagos",
                column: "FechaPago",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Consulta_UQ",
                table: "Consultas",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_UsuarioId",
                table: "Consultas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "Compra_UQ",
                table: "Compras",
                column: "Fecha",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Compras_UsuarioId",
                table: "Compras",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "CompraDetalle_UQ",
                table: "CompraDetalles",
                column: "Cantidad",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompraDetalles_CompraId",
                table: "CompraDetalles",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "Carrito_UQ",
                table: "Carritos",
                column: "FechaCreacion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carritos_UsuarioId",
                table: "Carritos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "CarritoProducto_UQ",
                table: "CarritoProductos",
                column: "Cantidad",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarritoProductos_CarritoId",
                table: "CarritoProductos",
                column: "CarritoId");
        }
    }
}
