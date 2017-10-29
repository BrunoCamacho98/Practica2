using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebVenta.Models;

namespace WebVenta.Repository
{
    interface Repository<T>
    {
        bool Create(T t);
        List<Venta> Reader();
    }
}
