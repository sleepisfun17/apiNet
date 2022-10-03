using System.Data;
using System.Data.SqlClient;

namespace apiNet.Models
{
    // source: https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/populating-a-dataset-from-a-dataadapter
    public static class CRUD
    {
        #region Get configuration from appsettings.json (butuh di register di Program.cs)
        private static string conString = "";

        public static void GetConfiguration(IConfiguration configuration)
        {
            conString = configuration["ConnectionStrings:Default"];
        }
        #endregion

        #region ExecuteQuery
        /// <summary>
        /// ExecuteQuery untuk menjalankan query yang return banyak data
        /// </summary>
        public static DataTable ExecuteQuery(string query, SqlParameter[] sqlParams = null)
        {
            DataTable result = new DataTable();

            // begin connection
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();

                #region query process to database
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (sqlParams != null) cmd.Parameters.AddRange(sqlParams);

                    // mengisi dengan SqlDataAdapter
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(result);
                }
                #endregion

                // close connection
                con.Close();
            }

            return result;
        }
        #endregion

        #region ExecuteScalar
        /// <summary>
        /// ExecuteScalar untuk menjalankan query yang hanya return tepat 1 data
        /// </summary>
        public static object ExecuteScalar(string query, SqlParameter[] sqlParams = null)
        {
            object result = null;

            // begin connection
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();

                #region query process to database
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (sqlParams != null) cmd.Parameters.AddRange(sqlParams);
                    result = cmd.ExecuteScalar(); // ExecuteScalar untuk query yang return tepat 1 data saja
                }
                #endregion

                // close connection
                con.Close();
            }

            return result;
        }
        #endregion

        #region ExecuteNonQuery
        /// <summary>
        /// ExecuteNonQuery untuk menjalankan query yang tidak return apa-apa
        /// </summary>
        public static int ExecuteNonQuery(string query, SqlParameter[] sqlParams = null)
        {
            int result = 0;

            // begin connection
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();

                #region query process to database
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (sqlParams != null) cmd.Parameters.AddRange(sqlParams);
                    result = cmd.ExecuteNonQuery(); // ExecuteNonQuery untuk query yang tidak return apa-apa
                }
                #endregion

                // close connection
                con.Close();
            }

            return result;
        }
        #endregion
    }
}
