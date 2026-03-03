namespace TiendaApp.Models
{
    public class DetalleVenta
    {
        public int ArticuloId { get; set; }
        public string ArticuloNombre { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
    }
}