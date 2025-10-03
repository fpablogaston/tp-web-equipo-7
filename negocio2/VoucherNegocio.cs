using AccesoADatos;
using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class VoucherNegocio
    {


        public bool codigoValido(string codigo)
        {
            bool valido = false;

            AccesoADatos.AccesoDatos datos = new AccesoADatos.AccesoDatos();

            try {
                datos.setQuery("SELECT COUNT(1) FROM VOUCHERS WHERE CodigoVoucher = @Codigo AND FechaCanje IS NULL");
                datos.setearParametro("@Codigo", codigo);
                int a = datos.ejecutarScalar();

                if (a > 0) { 
                    valido = true;
                    datos.setQuery("UPDATE VOUCHERS SET FechaCanje = @Fecha WHERE CodigoVoucher = @Codigo");
                    datos.setearParametro("@Fecha", DateTime.Now);
                    datos.ejecutarAccion();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
          
            

            return valido;
        }

        public List<Voucher> listar()
        {
            List<Voucher> lista = new List<Voucher>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setQuery("SELECT IdCliente, CodigoVoucher, FechaCanje, IdArticulo FROM Vouchers");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Voucher aux = new Voucher();
                    aux.CodigoVoucher = (string)datos.Lector["CodigoVoucher"];
                    aux.IdCliente = (int)datos.Lector["IdCliente"];
                    aux.FechaCanje = (DateTime)datos.Lector["FechaCanje"];
                    aux.IdArticulo = (int)datos.Lector["IdArticulo"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
