using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI1.Models;

namespace WebAPI1.Controllers
{
    public class RegistrationController : ApiController
    {
        // GET: api/Registration
        [HttpGet]
        [Route("Registration1")]
        public List<RegistrationModel> hhi()

        {
            RegistrationModel enp = new RegistrationModel();
            List<RegistrationModel> listemp = new List<RegistrationModel>();
            SqlConnection con1 = null;
            try
            {
                con1 = new SqlConnection("data source=.;database=MovieReviewDb;integrated security=SSPI");
                con1.Open();
                SqlCommand cmd = new SqlCommand("select * from Registration", con1);
                SqlDataReader sdrd = cmd.ExecuteReader();
                while (sdrd.Read())
                {
                    enp = new RegistrationModel();
                    enp.UserId = (int)sdrd["UserId"];
                    enp.UserName = (string)sdrd["UserName"];
                    enp.Password = (string)sdrd["Password"];
                    enp.ConfirmPassword = (string)sdrd["ConfirmPassword"];
                    enp.FirstName = (string)sdrd["FirstName"];
                    enp.LastName = (string)sdrd["LastName"];
                    enp.Email = (string)sdrd["Email"];
                    listemp.Add(enp);
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine("ERROR", Ex);
            }
            return listemp;
        }

        [Route("Registration")]
        [HttpPost]
        public string Registration(RegistrationModel obj)

        {
            SqlConnection con1 = null;
            try
            {
                con1 = new SqlConnection("data source=.;database=MovieReviewDb;integrated security=SSPI");
                con1.Open();
                SqlCommand cmd = new SqlCommand("insert into Registration values('" + obj.UserName + "','" + obj.Password + "','" + obj.ConfirmPassword + "','" + obj.FirstName + "','" + obj.LastName + "','" + obj.Email + "')", con1);
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Console.WriteLine("ERROR", Ex);
            }
            return "inserted";
        }
        //[Route("Registration")]
        //[HttpPost]
        //public SqlConnection conn = new SqlConnection();
        ////POST: /api/RegistrationModel
        //public HttpResponseMessage PostRegistrationModel([FromBody] RegistrationModel item)
        //{
        //    conn.ConnectionString = @"database connection string";
        //    string sqlText = "Insert into Registration values(@UserId,@UserName,@Password,@ConfirmPassword,@FirstName,@LastName,@Email,)";
        //    SqlCommand sqlCmd = new SqlCommand(sqlText, conn);
        //    sqlCmd.Parameters.AddWithValue("@UserId", item.UserId);
        //    sqlCmd.Parameters.AddWithValue("@UserName", item.UserName);
        //    sqlCmd.Parameters.AddWithValue("@Password", item.Password);
        //    sqlCmd.Parameters.AddWithValue("@ConfirmPassword", item.ConfirmPassword);
        //    sqlCmd.Parameters.AddWithValue("@FirstName", item.FirstName);
        //    sqlCmd.Parameters.AddWithValue("@LastName", item.LastName);
        //    sqlCmd.Parameters.AddWithValue("@Email", item.Email);
        //    conn.Open();
        //    int i = sqlCmd.ExecuteNonQuery();
        //    conn.Close();
        //    var response = Request.CreateResponse<RegistrationModel>(HttpStatusCode.Created, item);
        //    string uri = Url.Link("DefaultApi", new { id = item.UserId });
        //    response.Headers.Location = new Uri(uri);
        //    return response;
        //}

        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Registration/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Registration
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Registration/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Registration/5
        //public void Delete(int id)
        //{
        //}
    }
}
