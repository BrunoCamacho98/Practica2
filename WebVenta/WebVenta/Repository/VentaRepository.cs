using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebVenta.Models;

namespace WebVenta.Repository
{
    public class VentaRepository : IVentaRepository
    {
        SqlConnection cn;
        Conexion con = new Conexion();
        public bool Create(Venta t)
        {
            cn = con.getConexion();
            SqlCommand cmd = new SqlCommand("AddNewVenta", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Producto", t.Producto);
            cmd.Parameters.AddWithValue("@Precio", t.Precio);
            cmd.Parameters.AddWithValue("@Cantidad", t.Cantidad);
            cmd.Parameters.AddWithValue("@TotalPagar", t.MontoPagar);
            cn.Open();
            int i = cmd.ExecuteNonQuery();
            cn.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<Venta> Reader()
        {
            cn = con.getConexion();
            List<Venta> listventa = new List<Venta>();
            SqlCommand cmd = new SqlCommand("GetVenta", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            cn.Open();
            sd.Fill(dt);
            cn.Close();

            foreach(DataRow dr in dt.Rows)
            {
                listventa.Add(new Venta
                {
                    Producto = Convert.ToString(dr["Producto"]),
                    Precio = Convert.ToDecimal(dr["Precio"]),
                    Cantidad = Convert.ToInt32(dr["Cantidad"]),
                    MontoPagar = Convert.ToDecimal(dr["TotalPagar"])
                });
            }
            return listventa;
        }
    }
}