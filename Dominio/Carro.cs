using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dominio
{
    public class Carro
    {
        public Carro()
        {
            Productos = new List<Articulo>();
            ContadorArticulo = 0;
            AcumuladorPrecio = 0;
        }
        public List<Articulo> Productos {get; set;}
        public int ContadorArticulo {get; set;}
        public decimal AcumuladorPrecio {get; set;}

    }
}
