namespace SistemaVenta.AplicacionWeb.Models.ViewModels
{
    public class VMReporteVenta
    {
        public string? FechaRegistro { get; set; }
        public string? NumeroComprobante { get; set; }
        public string? TipoComprobante { get; set; }
        public string? DocumentoCliente { get; set; }
        public string? NombreCliente { get; set; }
        public string? NetoGravado { get; set; }
        public string? ImporteIva { get; set; }
        public string? Total { get; set; }
        public string? NombreArticulo { get; set; }
        public string? Cantidad { get; set; }
        public string? Iva { get; set; }
    }
}
