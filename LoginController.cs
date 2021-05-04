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
    public class LoginController : ApiController
    {
        // GET: api/Login

        [HttpGet]
        [Route("login")]
        public List<LoginModel> hhi()

        {
            LoginModel enp = new LoginModel();
            List<LoginModel> listemp = new List<LoginModel>();
            SqlConnection con1 = null;
            try
            {
                con1 = new SqlConnection("data source=.;database=MovieReviewDb;integrated security=SSPI");
                con1.Open();
                SqlCommand cmd = new SqlCommand("select * from Registration", con1);
                SqlDataReader sdrd = cmd.ExecuteReader();
                while (sdrd.Read())
                {
                    enp = new LoginModel();
                    //enp.UserId = (int)sdrd["UserId"];
                    enp.UserName = (string)sdrd["UserName"];
                    enp.Password = (string)sdrd["Password"];
                   
                    //enp.LastName = (string)sdrd["LastName"];
                    //enp.Email = (string)sdrd["Email"];
                    listemp.Add(enp);
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine("ERROR", Ex);
            }
            return listemp;
        }


        //[Route("login1")]
        //[HttpPost]
        //public string Login(LoginModel obj)

        //{
        //    SqlConnection con1 = null;
        //    try
        //    {
        //        con1 = new SqlConnection("data source=.;database=MovieReviewDb;integrated security=SSPI");
        //        con1.Open();
        //        SqlCommand cmd = new SqlCommand("insert into Login values('" + obj.UserName + "','" + obj.Password + "')", con1);
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch (Exception Ex)
        //    {
        //        Console.WriteLine("ERROR", Ex);
        //    }
        //    return "inserted";
        //}
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Login/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Login
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Login/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Login/5
        //public void Delete(int id)
        //{
        //}
    }
}
