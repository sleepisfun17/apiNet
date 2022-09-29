//using System.Data;
//using System.Data.SqlClient;

//using apiNet.Models;

//namespace apiNet.Logics
//{
//    public static class RealDBLogic
//    {
//        private static string conString = " SERver =NDS-LPT-0164\\SQL2019; Database=Batch3; User Id=sa; Password=nawadata;";

//        public static List<object> GetProductReader()
//        {
//            List<object> result = new List<object>(); // initialisasi array kosong

//            // begin connection
//            using (SqlConnection con = new SqlConnection(conString))
//            {
//                con.Open();

//                #region query process to database
//                using (SqlCommand cmd = new SqlCommand())
//                {
//                    cmd.Connection = con;
//                    cmd.CommandText = "SELECT * FROM Products";

//                    SqlDataReader reader = cmd.ExecuteReader(); // query dengan SqlDataReader
//                    while (reader.Read())
//                    {
//                        object tempData = new
//                        {
//                            pk_product_id = reader["pk_product_id"],
//                            product_name = reader["product_name"],
//                        };

//                        result.Add(tempData);
//                    }
//                    reader.Close();
//                }
//                #endregion

//                // close connection
//                con.Close();
//            }

//            return result;
//        }

//        public static List<Product> GetProductAdapter()
//        {
//            List<Product> result = new List<Product>(); // initialisasi array kosong

//            #region query process to database
//            string query = "SELECT * FROM Product";
//            DataTable dataTable = CRUD.ExecuteQuery(query);

//            foreach (DataRow row in dataTable.Rows)
//            {
//                Product tempData = new Product
//                {
//                    pk_product_id = (int)row["pk_product_id"],
//                    product_name = (string)row["product_name"],
//                };

//                result.Add(tempData);
//            }
//            #endregion

//            return result;
//        }

//        public static void InsertProduct(Product product)
//        {
//            string query = "INSERT INTO Product(product_name) VALUES ('" + product.product_name + "')";
//            CRUD.ExecuteNonQuery(query); // ExecuteNonQuery untuk query yang tidak return apa-apa
//        }

//        public static int ContohScalar()
//        {
//            int result = (int)CRUD.ExecuteScalar("SELECT 1"); // ExecuteScalar untuk query yang return tepat 1 data saja
//            return result;
//        }

//        public static void InsertName(Users name)
//        {

//        }
//    }
//}
