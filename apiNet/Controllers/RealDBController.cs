//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//using System.Data;
//using System.Data.SqlClient;

//namespace apiNet.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class RealDBController : ControllerBase
//    {
//        private string conString = "Server=SLEEPISFUN17\\MIFSERVER; Database=FSBatch3; User Id=sa; Password=miruku173;";

//        #region SqlDataReader
//        [HttpGet]
//        [Route("GetProductReader")]
//        public ActionResult GetProductReader()
//        {
//            // begin connection
//            SqlConnection con = new SqlConnection(conString);
//            con.Open();

//            // query process to database
//            SqlCommand cmd = new SqlCommand();
//            cmd.Connection = con;
//            cmd.CommandText = "SELECT * FROM Product";

//            List<object> result = new List<object>(); // initialisasi array kosong
//            SqlDataReader reader = cmd.ExecuteReader(); // query dengan SqlDataReader
//            while (reader.Read())
//            {
//                object tempData = new
//                {
//                    pk_product_id = reader["pk_product_id"],
//                    product_name = reader["product_name"],
//                };

//                result.Add(tempData);
//            }
//            reader.Close();

//            cmd.Dispose();

//            con.Close();
//            con.Dispose();

//            return Ok(result);
//        }
//        #endregion

//        #region SqlDataAdapter
//        [HttpGet]
//        [Route("GetProductAdapter")]
//        public ActionResult GetProductAdapter()
//        {
//            List<object> result = new List<object>(); // initialisasi array kosong
//            // begin connection
//            using (SqlConnection con = new SqlConnection(conString))
//            {
//                con.Open();
//                string query = "SELECT * FROM Product";

//                // query process to database
//                using(SqlCommand cmd = new SqlCommand(query, con))
//                {
//                    DataTable dataTable = new DataTable();
//                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
//                    adapter.Fill(dataTable);

//                    foreach(DataRow row in dataTable.Rows)
//                    {
//                        object tempData = new
//                        {
//                            pk_product_id = row["pk_product_id"],
//                            product_name = row["product_name"],
//                        };

//                        result.Add(tempData);
//                    }
//                }
                
//                con.Close();
//            }
               

//            return Ok(result);
//        }
//        #endregion
//    }
//}
