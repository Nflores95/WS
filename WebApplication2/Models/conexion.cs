using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;
namespace WebApplication2.Models
{
    public class conexion
    {
        static SqlConnection cn = new SqlConnection();
        public static async Task AbrirConexionAsync()
        {
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["BD_DESARROLLO"].ConnectionString;
            await cn.OpenAsync();
        }
        public static void CerrarConexion()
        {
            cn.Close();
        }

        //static void Main(string[] args)
        //public async Task<List<string>> GetCuotas()
        public async Task<List<string>> GetCuotas(int IdCanal, int TipoAvance)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("SP_ObtenerMenuCuotas", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pIdCanal", IdCanal); //204
                    cmd.Parameters.AddWithValue("@pTipoAvance", TipoAvance); //101
                    //cmd.Parameters.Add(new SqlParameter("@pIdCanal",204));
                    //cmd.Parameters.Add(new SqlParameter("@pTipoAvance",101));
                    var response = new List<string>();
                    await AbrirConexionAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while(await reader.ReadAsync())
                        {
                            response.Add(reader["NumeroOpcion"].ToString()+") "+reader["NumeroCuotas"].ToString() );
                            Debug.WriteLine("nn"+ reader["NumeroOpcion"].ToString());
                        }
                    }
                    CerrarConexion();
                    return response;
                }

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}