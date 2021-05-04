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
    public class MoviesController : ApiController
    {
        // GET: api/Movies
        //[HttpGet]
        //[Route("investigation")]
        //public string createinvestigation()
        //{
        //    SqlConnection con = null;
        //    try
        //    {
        //        con = new SqlConnection("data source=.; database=EmployeeDB; integrated security=SSPI");
        //        con.Open();
        //        SqlCommand com = new SqlCommand("create table tblinvestigationdetails1 (sno int,investigationdate date," +
        //        "department varchar(50),nameofinvestigation varchar(50), cost int) ", con);
        //        com.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("something error", ex);
        //    }
        //    return "created";
        //}
        [HttpGet]
        [Route("Movies")]
        public List<MoviesModel> hhi()

        {
            MoviesModel enp = new MoviesModel();
            List<MoviesModel> listemp = new List<MoviesModel>();
            SqlConnection con1 = null;
            try
            {
                con1 = new SqlConnection("data source=.;database=MovieReviewDb;integrated security=SSPI");
                con1.Open();
                SqlCommand cmd = new SqlCommand("select * from Movies", con1);
                SqlDataReader sdrd = cmd.ExecuteReader();
                while (sdrd.Read())
                {
                    enp = new MoviesModel();
                    //enp.MovieId = (int)sdrd["MovieId"];
                    enp.MovieName = (string)sdrd["MovieName"];
                    enp.DirectorName = (string)sdrd["DirectorName"];
                    enp.MoviewImageId = (int)sdrd["MoviewImageId"];
                    enp.ReleasedDate = (DateTime)sdrd["ReleasedDate"];
                    enp.Feedback = (string)sdrd["Feedback"];
                    enp.Images = (string)sdrd["Images"];
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
        [Route("Movies1")]
        [HttpPost]
        public string Movies(MoviesModel obj)

        {
            SqlConnection con1 = null;
            try
            {
                con1 = new SqlConnection("data source=.;database=MovieReviewDb;integrated security=SSPI");
                con1.Open();
                SqlCommand cmd = new SqlCommand("insert into Movies values('" + obj.MovieName + "','" + obj.DirectorName + "'," + obj.MoviewImageId + ",'" + obj.ReleasedDate + "','" + obj.Feedback + "','" + obj.Images + "')", con1);
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Console.WriteLine("ERROR", Ex);
            }
            return "inserted";
        }
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Movies/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Movies
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Movies/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Movies/5
        //public void Delete(int id)
        //{
        //}
    }
}
