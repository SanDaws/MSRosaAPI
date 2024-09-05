using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MSRosaAPI.Models
{
    [Table("productos")]
    public class Producto
    {
        [Key]
        public  int id{get;set;}
        public string NombreProducto{get;set;}
        public double PrecioUnitario{get;set;}
        public int unidades{get;set;}
    }
}