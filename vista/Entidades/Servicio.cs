namespace Entidades
{
    public class Servicio
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public decimal cantidad { get; set; }
        public decimal total { get; set; }

        public Servicio()
        {
        }

        public Servicio(string codigo, string descripcion, decimal precio, decimal cantidad, decimal total)
        {
            Codigo = codigo;
            Descripcion = descripcion;
            Precio = precio;
            this.cantidad = cantidad;
            this.total = total;
        }
    }
}
