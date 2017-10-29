using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebVenta.Models;

namespace WebVenta.Services
{
    interface IVentaService
    {
        bool CreateVenta(Venta v);
        List<Venta> ReadVenta();
        decimal MontoPaga(Venta v);
        (decimal ventmayor, decimal vnetmenor, Venta vmayor, Venta vmenor) Reporte();
    }
}
