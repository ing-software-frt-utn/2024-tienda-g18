﻿using AutoMapper;
using SistemaVenta.AplicacionWeb.Models.ViewModels;
using SistemaVenta.Entity;
using System.Globalization;

namespace SistemaVenta.AplicacionWeb.Utilidades.Automapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            #region Rol
            CreateMap<Rol, VMRol>().ReverseMap();
            #endregion Rol

            #region Usuario
            CreateMap<Usuario, VMUsuario>()
                .ForMember(destino =>
                destino.EsActivo,
                opt => opt.MapFrom(origen => origen.EsActivo == true ? 1 : 0)
                )
                .ForMember(destino =>
                destino.NombreRol,
                opt => opt.MapFrom(origen => origen.IdRolNavigation.Descripcion)
                );

            CreateMap<VMUsuario, Usuario>()
                .ForMember(destino =>
                destino.EsActivo,
                opt => opt.MapFrom(origen => origen.EsActivo == 1 ? true : false)
                )
                .ForMember(destino =>
                destino.IdRolNavigation,
                opt => opt.Ignore()
                );
            #endregion Usuario

            #region Sucursal
            CreateMap<Sucursal, VMSucursal>()
                .ForMember(destino =>
                destino.NombreCondicionTributaria,
                opt => opt.MapFrom(origen => origen.IdCondicionTributariaNavigation.Nombre)
                );

            CreateMap<VMSucursal, Sucursal>()
                .ForMember(destino =>
                destino.IdCondicionTributariaNavigation,
                opt => opt.Ignore()
                );
            #endregion Sucursal

            #region Categoria
            CreateMap<Categoria, VMCategoria>()
                .ForMember(destino =>
                destino.esActivo,
                opt => opt.MapFrom(origen => origen.EsActivo == true ? 1 : 0)
                );

            CreateMap<VMCategoria, Categoria>()
                .ForMember(destino =>
                destino.EsActivo,
                opt => opt.MapFrom(origen => origen.esActivo == 1 ? true : false)
                );
            #endregion Categoria

            #region Marca
            CreateMap<Marca, VMMarca>()
                .ForMember(destino =>
                destino.esActivo,
                opt => opt.MapFrom(origen => origen.EsActivo == true ? 1 : 0)
                );

            CreateMap<VMMarca, Marca>()
                .ForMember(destino =>
                destino.EsActivo,
                opt => opt.MapFrom(origen => origen.esActivo == 1 ? true : false)
                );
            #endregion Marca

            #region Color
            CreateMap<Color, VMColor>()
                .ForMember(destino =>
                destino.esActivo,
                opt => opt.MapFrom(origen => origen.EsActivo == true ? 1 : 0)
                );

            CreateMap<VMColor, Color>()
                .ForMember(destino =>
                destino.EsActivo,
                opt => opt.MapFrom(origen => origen.esActivo == 1 ? true : false)
                );
            #endregion Color

            #region CondicionTributaria
            CreateMap<CondicionTributaria, VMCondicionTributaria>()
                .ForMember(destino =>
                destino.esActivo,
                opt => opt.MapFrom(origen => origen.EsActivo == true ? 1 : 0)
                );

            CreateMap<VMCondicionTributaria, CondicionTributaria>()
                .ForMember(destino =>
                destino.EsActivo,
                opt => opt.MapFrom(origen => origen.esActivo == 1 ? true : false)
                )
                ;
            #endregion CondicionTributaria

            #region TipoTalle
            CreateMap<TipoTalle, VMTipoTalle>()
                .ForMember(destino =>
                destino.esActivo,
                opt => opt.MapFrom(origen => origen.EsActivo == true ? 1 : 0)
                );

            CreateMap<VMTipoTalle, TipoTalle>()
                .ForMember(destino =>
                destino.EsActivo,
                opt => opt.MapFrom(origen => origen.esActivo == 1 ? true : false)
                );
            #endregion TipoTalle

            #region Talle
            CreateMap<Talle, VMTalle>()
                .ForMember(destino =>
                destino.esActivo,
                opt => opt.MapFrom(origen => origen.EsActivo == true ? 1 : 0)
                )
                .ForMember(destino =>
                destino.NombreTipoTalle,
                opt => opt.MapFrom(origen => origen.IdTipoTalleNavigation.Descripcion)
                );

            CreateMap<VMTalle, Talle>()
                .ForMember(destino =>
                destino.EsActivo,
                opt => opt.MapFrom(origen => origen.esActivo == 1 ? true : false)
                )
                .ForMember(destino =>
                destino.IdTipoTalleNavigation,
                opt => opt.Ignore()
                );

            #endregion Talle

            #region Articulo

            CreateMap<Articulo, VMArticulo>()
                .ForMember(destino =>
                destino.EsActivo,
                opt => opt.MapFrom(origen => origen.EsActivo == true ? 1 : 0)
                )
                .ForMember(destino =>
                destino.NombreCategoria,
                opt => opt.MapFrom(origen => origen.IdCategoriaNavigation.Descripcion)
                )
                .ForMember(destino =>
                destino.NombreMarca,
                opt => opt.MapFrom(origen => origen.IdMarcaNavigation.Descripcion)
                )
                .ForMember(destino =>
                destino.NombreTipoTalle,
                opt => opt.MapFrom(origen => origen.IdTipoTalleNavigation.Descripcion)
                )
                .ForMember(destino =>
                destino.Costo,
                opt => opt.MapFrom(origen => Convert.ToString(origen.Costo.Value, new CultureInfo("es-AR")))
                )
                .ForMember(destino =>
                destino.Iva,
                opt => opt.MapFrom(origen => Convert.ToString(origen.Iva.Value, new CultureInfo("es-AR")))
                )
                .ForMember(destino =>
                destino.MargenGanancia,
                opt => opt.MapFrom(origen => Convert.ToString(origen.MargenGanancia.Value, new CultureInfo("es-AR")))
                );

            CreateMap<VMArticulo, Articulo>()
                .ForMember(destino =>
                destino.EsActivo,
                opt => opt.MapFrom(origen => origen.EsActivo == 1 ? true : false)
                )
                .ForMember(destino =>
                destino.IdCategoriaNavigation,
                opt => opt.Ignore()
                )
                .ForMember(destino =>
                destino.IdMarcaNavigation,
                opt => opt.Ignore()
                )
                .ForMember(destino =>
                destino.IdTipoTalleNavigation,
                opt => opt.Ignore()
                )
                .ForMember(destino =>
                destino.Costo,
                opt => opt.MapFrom(origen => Convert.ToDecimal(origen.Costo, new CultureInfo("es-AR")))
                )
                .ForMember(destino =>
                destino.Iva,
                opt => opt.MapFrom(origen => Convert.ToDecimal(origen.Iva, new CultureInfo("es-AR")))
                )
                .ForMember(destino =>
                destino.MargenGanancia,
                opt => opt.MapFrom(origen => Convert.ToDecimal(origen.MargenGanancia, new CultureInfo("es-AR")))
                );
            #endregion Articulo

            #region Inventario
            CreateMap<Inventario, VMInventario>()
                .ForMember(destino =>
                destino.EsActivo,
                opt => opt.MapFrom(origen => origen.EsActivo == true ? 1 : 0)
                )
                .ForMember(destino =>
                destino.NombreArticulo,
                opt => opt.MapFrom(origen => origen.IdArticuloNavigation.Descripcion)
                )
                .ForMember(destino =>
                destino.NombreColor,
                opt => opt.MapFrom(origen => origen.IdColorNavigation.Descripcion)
                )
                .ForMember(destino =>
                destino.NombreTalle,
                opt => opt.MapFrom(origen => origen.IdTalleNavigation.Descripcion)
                )
                .ForMember(destino =>
                destino.Cantidad,
                opt => opt.MapFrom(origen => Convert.ToString(origen.Cantidad.Value, new CultureInfo("es-AR")))
                )
                .ForMember(destino =>
                destino.CostoArticulo,
                opt => opt.MapFrom(origen => Convert.ToString(origen.IdArticuloNavigation.Costo.Value, new CultureInfo("es-AR")))
                )
                .ForMember(destino =>
                destino.IvaArticulo,
                opt => opt.MapFrom(origen => Convert.ToString(origen.IdArticuloNavigation.Iva.Value, new CultureInfo("es-AR")))
                )
                .ForMember(destino =>
                destino.MargenGananciaArticulo,
                opt => opt.MapFrom(origen => Convert.ToString(origen.IdArticuloNavigation.MargenGanancia.Value, new CultureInfo("es-AR")))
                );

            CreateMap<VMInventario, Inventario>()
                .ForMember(destino =>
                destino.EsActivo,
                opt => opt.MapFrom(origen => origen.EsActivo == 1 ? true : false)
                )
                .ForMember(destino =>
                destino.IdArticuloNavigation,
                opt => opt.Ignore()
                )
                .ForMember(destino =>
                destino.IdColorNavigation,
                opt => opt.Ignore()
                )
                .ForMember(destino =>
                destino.IdTalleNavigation,
                opt => opt.Ignore()
                )
                .ForMember(destino =>
                destino.Cantidad,
                opt => opt.MapFrom(origen => Convert.ToInt32(origen.Cantidad, new CultureInfo("es-AR")))
                );
            #endregion Inventario

            #region Cliente

            CreateMap<Cliente, VMCliente>()
                .ForMember(destino =>
                destino.EsActivo,
                opt => opt.MapFrom(origen => origen.EsActivo == true ? 1 : 0)
                )
                .ForMember(destino =>
                destino.NombreCondicionTributaria,
                opt => opt.MapFrom(origen => origen.IdCondicionTributariaNavigation.Nombre)
                )
                .ForMember(destino =>
                destino.CodigoCondicionTributaria,
                opt => opt.MapFrom(origen => origen.IdCondicionTributariaNavigation.Codigo)
                );

            CreateMap<VMCliente, Cliente>()
                .ForMember(destino =>
                destino.EsActivo,
                opt => opt.MapFrom(origen => origen.EsActivo == 1 ? true : false)
                )
                .ForMember(destino =>
                destino.IdCondicionTributariaNavigation,
                opt => opt.Ignore()
                );
            #endregion Cliente

            #region TipoComprobante
            CreateMap<TipoComprobante, VMTipoComprobante>().ReverseMap();
            #endregion TipoComprobante

            #region TipoPago
            CreateMap<TipoPago, VMTipoPago>().ReverseMap();
            #endregion TipoPago

            #region Pago
            CreateMap<Pago, VMPago>()
                .ForMember(destino =>
                destino.esActivo,
                opt => opt.MapFrom(origen => origen.EsActivo == true ? 1 : 0)
                )
                .ForMember(destino =>
                destino.Monto,
                opt => opt.MapFrom(origen => Convert.ToString(origen.Monto.Value, new CultureInfo("es-AR")))
                );

            CreateMap<VMPago, Pago>()
                .ForMember(destino =>
                destino.EsActivo,
                opt => opt.MapFrom(origen => origen.esActivo == 1 ? true : false)
                )
                .ForMember(destino =>
                destino.Monto,
                opt => opt.MapFrom(origen => Convert.ToDecimal(origen.Monto, new CultureInfo("es-AR")))
                );

            #endregion Pago

            #region Tarjeta
            CreateMap<Tarjeta, VMTarjeta>().ReverseMap();
            #endregion Tarjeta

            #region AFIP
            CreateMap<AFIP, VMAFIP>().ReverseMap();
            #endregion AFIP

            #region Venta
            CreateMap<Venta, VMVenta>()
            .ForMember(destino =>
            destino.TipoComprobante,
            opt => opt.MapFrom(origen => origen.IdTipoComprobanteNavigation.Descripcion)
            )
            .ForMember(destino =>
            destino.TipoDocumentoCliente,
            opt => opt.MapFrom(origen => origen.IdClienteNavigation.IdCondicionTributariaNavigation.Codigo)
            )
            .ForMember(destino =>
            destino.Usuario,
            opt => opt.MapFrom(origen => origen.IdUsuarioNavigation.Nombre)
            )
            .ForMember(destino =>
            destino.NetoGravado,
            opt => opt.MapFrom(origen => Convert.ToString(origen.NetoGravado.Value, new CultureInfo("es-AR")))
            )
            .ForMember(destino =>
            destino.ImporteIva,
            opt => opt.MapFrom(origen => Convert.ToString(origen.ImporteIva.Value, new CultureInfo("es-AR")))
            )
            .ForMember(destino =>
            destino.NombreCliente,
            opt => opt.MapFrom(origen => origen.IdClienteNavigation.Nombres)
            )
            .ForMember(destino =>
            destino.DocumentoCliente,
            opt => opt.MapFrom(origen => origen.IdClienteNavigation.NumeroDocumento)
            )
            .ForMember(destino =>
            destino.Monto,
            opt => opt.MapFrom(origen => Convert.ToString(origen.Monto.Value, new CultureInfo("es-AR")))
            )
            .ForMember(destino =>
            destino.IdPuntoVenta,
            opt => opt.MapFrom(origen => origen.IdPuntoVentaNavigation.IdPuntoVenta)
            )
            .ForMember(destino =>
            destino.FechaRegistro,
            opt => opt.MapFrom(origen => origen.FechaRegistro.Value.ToString("dd/MM/yyyy"))
            );

            CreateMap<VMVenta, Venta>()
            .ForMember(destino =>
            destino.NetoGravado,
            opt => opt.MapFrom(origen => Convert.ToDecimal(origen.NetoGravado, new CultureInfo("es-AR")))
            )
            .ForMember(destino =>
            destino.ImporteIva,
            opt => opt.MapFrom(origen => Convert.ToDecimal(origen.ImporteIva, new CultureInfo("es-AR")))
            )
            .ForMember(destino =>
            destino.Monto,
            opt => opt.MapFrom(origen => Convert.ToDecimal(origen.Monto, new CultureInfo("es-AR")))
            );
            #endregion Venta

            #region DetalleVenta
            CreateMap<DetalleVenta, VMDetalleVenta>()
            .ForMember(destino =>
            destino.Iva,
            opt => opt.MapFrom(origen => Convert.ToString(origen.Iva.Value, new CultureInfo("es-AR")))
            )
            .ForMember(destino =>
            destino.NetoGravado,
            opt => opt.MapFrom(origen => Convert.ToString(origen.NetoGravado.Value, new CultureInfo("es-AR")))
            )
            .ForMember(destino =>
            destino.MargenGanancia,
            opt => opt.MapFrom(origen => Convert.ToString(origen.MargenGanancia.Value, new CultureInfo("es-AR")))
            );

            CreateMap<VMDetalleVenta, DetalleVenta>()
            .ForMember(destino =>
            destino.Iva,
            opt => opt.MapFrom(origen => Convert.ToDecimal(origen.Iva, new CultureInfo("es-AR")))
            )
            .ForMember(destino =>
            destino.NetoGravado,
            opt => opt.MapFrom(origen => Convert.ToDecimal(origen.NetoGravado, new CultureInfo("es-AR")))
            )
            .ForMember(destino =>
            destino.MargenGanancia,
            opt => opt.MapFrom(origen => Convert.ToDecimal(origen.MargenGanancia, new CultureInfo("es-AR")))
            );

            CreateMap<DetalleVenta, VMReporteVenta>()
            .ForMember(destino =>
            destino.FechaRegistro,
            opt => opt.MapFrom(origen => origen.IdVentaNavigation.FechaRegistro.Value.ToString("dd/MM/yyyy"))
            )
            .ForMember(destino =>
            destino.NumeroComprobante,
            opt => opt.MapFrom(origen => origen.IdVentaNavigation.NumeroComprobante)
            )
            .ForMember(destino =>
            destino.NetoGravado,
            opt => opt.MapFrom(origen => Convert.ToString(origen.IdVentaNavigation.NetoGravado.Value, new CultureInfo("es-AR")))
            )
            .ForMember(destino =>
            destino.ImporteIva,
            opt => opt.MapFrom(origen => Convert.ToString(origen.IdVentaNavigation.ImporteIva.Value, new CultureInfo("es-AR")))
            )
            .ForMember(destino =>
            destino.TipoComprobante,
            opt => opt.MapFrom(origen => origen.IdVentaNavigation.IdTipoComprobanteNavigation.Descripcion)
            )
            .ForMember(destino =>
            destino.DocumentoCliente,
            opt => opt.MapFrom(origen => origen.IdVentaNavigation.IdClienteNavigation.NumeroDocumento)
            )
            .ForMember(destino =>
            destino.NombreCliente,
            opt => opt.MapFrom(origen => origen.IdVentaNavigation.IdClienteNavigation.Nombres)
            )
            .ForMember(destino =>
            destino.Total,
            opt => opt.MapFrom(origen => Convert.ToString(origen.IdVentaNavigation.Monto.Value, new CultureInfo("es-AR")))
            )
            .ForMember(destino =>
            destino.Iva,
            opt => opt.MapFrom(origen => Convert.ToString(origen.Iva.Value, new CultureInfo("es-AR")))
            )
            .ForMember(destino =>
            destino.NombreArticulo,
            opt => opt.MapFrom(origen => origen.NombreArticulo)
            )
            ;

            #endregion DetalleVenta

            #region Menu
            CreateMap<Menu, VMMenu>()
            .ForMember(destino =>
            destino.SubMenus,
            opt => opt.MapFrom(origen => origen.InverseIdMenuPadreNavigation)
            );
            #endregion Menu

            #region InventariosSemana
            CreateMap<Inventario, VMInventariosSemana>()
                .ForMember(destino =>
                destino.NombreArticulo,
                opt => opt.MapFrom(origen => origen.IdArticuloNavigation.Descripcion));


            #endregion
        }
    }
}
