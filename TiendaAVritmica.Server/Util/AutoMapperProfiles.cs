using AutoMapper;
using TiendaAVritmica.BD.Data.Entity;
using TiendaAVritmica.Shared.DTO;

namespace TiendaAVritmica.Server.Util
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //CreateMap<CrearCategoriaDTO, Categoria>();

            //Carrito
            CreateMap<Carrito, CrearCarritoDTO>().ReverseMap();

            //CarritoProducto
            CreateMap<CarritoProducto, CrearCarritoProductoDTO>().ReverseMap();

            //Categoria
            CreateMap<Categoria, CrearCategoriaDTO>().ReverseMap();

            //Compra
            CreateMap<Compra, CrearCompraDTO>().ReverseMap();

            //CompraDetalle
            CreateMap<CompraDetalle, CrearCompraDetalleDTO>().ReverseMap();

            //Consulta
            CreateMap<Consulta, CrearConsultaDTO>().ReverseMap();

            //Pago
            CreateMap<Pago, CrearPagoDTO>().ReverseMap();

            //Producto
            CreateMap<Producto, CrearProductoDTO>().ReverseMap();

            //StockMovimiento
            CreateMap<StockMovimiento, CrearStockMovimientoDTO>().ReverseMap();

            //Usuario
            CreateMap<Usuario, CrearUsuarioDTO>().ReverseMap();
        }
    }
}
