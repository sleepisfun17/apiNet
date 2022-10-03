using apiNet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Data;
using System.Data.SqlClient;


namespace apiNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private string conString = "Server=SLEEPISFUN17\\MIFSERVER; Database=FSBatch3; User Id=sa; Password=miruku173;";

        [HttpPost]
        [Route("InsertName")]

        public ActionResult InsertName(Users user)
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO Users([name]) VALUES (@paramName)";
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@paramName", SqlDbType = SqlDbType.VarChar, Value = user.name??"" });
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                con.Close();
                con.Dispose();
                return Ok("Success");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetName")]

        public ActionResult GetName()
        {

            try
            {
                List<Users> result = new List<Users>();
                SqlConnection con = new SqlConnection(conString);
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Users";
                cmd.Connection = con;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    Users tempUsers = new Users()
                    {
                         name = dr["name"] == DBNull.Value ? "" : (String)dr["name"],
                         pk_user_id = dr["pk_user_id"] == DBNull.Value ? 0 : (int)dr["pk_user_id"],
                    };
                    result.Add(tempUsers);

                }

                cmd.Dispose();

                con.Close();
                con.Dispose();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        //[HttpPost]
        //[Route("/tasks/AddUserWithTask")]

        //public ActionResult AddUserWithTask([FromBody] UsersWithTaks user)
        //{
        //    using (SqlConnection con = new SqlConnection(conString))
        //    {
        //        con.Open();

        //        using (SqlCommand cmd = new SqlCommand())
        //        {
        //            cmd.Connection = con;
        //            cmd.Transaction = con.BeginTransaction();

        //            try
        //            {
        //                cmd.CommandText = "INSERT INTO Users([name]) VALUES (@name); SELECT SCOPE_IDENTITY();";
        //                cmd.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar) { Value = user.name ?? "" });

        //                decimal pk_user_id = (decimal)cmd.ExecuteScalar(); // SCOPE_IDENTITY() type is decimal
        //                cmd.Parameters.Clear();

        //                foreach (Tasks task in user.tasks)
        //                {
        //                    cmd.CommandText = "INSERT INTO Tasks(task_detail, fk_user_id) VALUES (@task_detail, @fk_user_id)";
        //                    cmd.Parameters.Add(new SqlParameter("@task_detail", SqlDbType.VarChar) { Value = task.task_detail ?? "" });
        //                    cmd.Parameters.Add(new SqlParameter("@fk_user_id", SqlDbType.Int) { Value = pk_user_id });

        //                    cmd.ExecuteNonQuery();
        //                    cmd.Parameters.Clear();
        //                }

        //                cmd.Transaction.Commit();
        //                con.Close();
        //                return "Success";
        //            }
        //            catch
        //            {
        //                cmd.Transaction.Rollback();
        //                con.Close();
        //                throw;
        //            }

        //        } // end SqlCommand

        //    } // end SqlConnection

        //    //try
        //    //{
        //    //    using (SqlConnection con = new SqlConnection(conString))
        //    //    {
        //    //        con.Open();

        //    //        using (SqlCommand cmd = new SqlCommand())
        //    //        {
        //    //            cmd.Connection = con;
        //    //            cmd.Transaction = con.BeginTransaction();

        //    //            cmd.CommandText = "INSERT INTO Users([name]) VALUES ('" + body.name + "'); SELECT SCOPE_IDENTITY();";
        //    //            int pk_user_id = (int)cmd.ExecuteScalar();



        //    //            foreach (Task task in body.tasks)
        //    //            {
        //    //                cmd.CommandText = "INSERT INTO Tasks(task_detail, fk_user_id VALUES ('" + task.task_detail + "'," + pk_user_id + "); SELECT SCOPE_IDENTITY();";
        //    //            }

        //    //        }

        //    //        con.Close();
        //    //    }
        //    //    return Ok("Success!!");
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    return BadRequest(ex.Message);
        //    //}
        //}
    }
}
