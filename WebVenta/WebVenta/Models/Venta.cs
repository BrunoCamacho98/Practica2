using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebVenta.Models
{
    public class Venta
    {
        [Required(ErrorMessage ="El Produto es necesario")]
        public String Producto { get; set; }
        [Required(ErrorMessage = "El Precio es necesario")]
        public decimal Precio { get; set; }
        [Required(ErrorMessage = "La cantidad es necesario")]
        public int Cantidad { get; set; }
        public decimal MontoPagar { get; set; }
    }
}