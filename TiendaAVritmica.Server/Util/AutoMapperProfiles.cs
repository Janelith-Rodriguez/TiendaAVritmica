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
            //Categoria
            CreateMap<Categoria, CrearCategoriaDTO>().ReverseMap();

            //Producto
            CreateMap<Producto, CrearProductoDTO>().ReverseMap();

            //Usuario
            CreateMap<Usuario, CrearUsuarioDTO>().ReverseMap();

            //Compra
            CreateMap<Compra, CrearCompraDTO>().ReverseMap();

            //CompraDetalle
            CreateMap<CompraDetalle, CrearCompraDetalleDTO>().ReverseMap();
        }
    }
}
