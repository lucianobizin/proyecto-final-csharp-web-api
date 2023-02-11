using System.Data.SqlClient;

namespace proyecto_final_csharp_web_api.Repositories
{
    public static class ConnectionHandler
    {
        public static SqlConnection ConnectToDb()
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-HF9696H\\SQLEXPRESS;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                return conn;

            }

            catch (Exception ex)
            {
                Console.WriteLine("" + ex.Message);
                SqlConnection returncode = new SqlConnection();
                return returncode;
            }
        }
    }
}
