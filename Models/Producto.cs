using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSRosaAPI.Models
{
    public class Producto
    {
        public  int id{get;set;}
        public string NombreProducto{get;set;}
        public double PrecioUnitario{get;set;}
        public int unidades{get;set;}
    }
}