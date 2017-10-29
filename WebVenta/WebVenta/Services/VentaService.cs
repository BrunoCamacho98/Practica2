using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebVenta.Models;
using WebVenta.Repository;

namespace WebVenta.Services
{
    public class VentaService : IVentaService
    {
        IVentaRepository ventrepos;
        public VentaService()
        {
            ventrepos = new VentaRepository();
        }
        public bool CreateVenta(Venta v)
        {
            v.MontoPagar = MontoPaga(v);
            return ventrepos.Create(v);
        }

        public decimal MontoPaga(Venta v)
        {
            decimal MontoPaga;
            MontoPaga = v.Precio * v.Cantidad;
            return MontoPaga;
        }

        public List<Venta> ReadVenta()
        {
            return ventrepos.Reader();
        }

        public (decimal ventmayor, decimal vnetmenor, Venta vmayor, Venta vmenor) Reporte()
        {
            decimal ventmayor = 0, ventmenor = 100;
            Venta vmayor = new Venta();
            Venta vmenor = new Venta();
            List<Venta> listventa = ReadVenta();

            foreach(var vnt in listventa)
            {
                
                if (vnt.MontoPagar < ventmenor)
                {
                    ventmenor = vnt.MontoPagar;
                    vmenor = vnt;
                }

                if (vnt.MontoPagar > ventmayor)
                {
                    ventmayor = vnt.MontoPagar;
                    vmayor = vnt;
                }

            }

            return (ventmayor, ventmenor, vmayor, vmenor);
        }
    }
}