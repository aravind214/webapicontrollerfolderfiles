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
    public class MovieReviewController : ApiController
    {
        // GET: api/MovieReview
        [Route("MoviesReview")]
        [HttpPost]
        public string MoviesReview(MoviesReview obj)

        {
            SqlConnection con2 = null;
            try
            {
                con2 = new SqlConnection("data source=.;database=MovieReviewDb;integrated security=SSPI");
                con2.Open();
                SqlCommand cmd2 = new SqlCommand("insert into MoviesReview values('" + obj.MoviewReviewName + "'," + obj.MovieId + "," + obj.MovieRating + ", " + obj.MoviewImageId + ",'" + obj.Feedback + "','" + obj.Username + "')", con2);
                cmd2.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Console.WriteLine("ERROR", Ex);
            }
            return "inserted";
        }

        [HttpGet]
        [Route("Review1")]
        public List<MoviesReview> hhi()

        {
            MoviesReview enp = new MoviesReview();
            List<MoviesReview> listemp = new List<MoviesReview>();
            SqlConnection con1 = null;
            try
            {
                con1 = new SqlConnection("data source=.;database=MovieReviewDb;integrated security=SSPI");
                con1.Open();
                SqlCommand cmd2 = new SqlCommand("select * from MoviesReview", con1);
                SqlDataReader sdrd = cmd2.ExecuteReader();
                while (sdrd.Read())
                {
                    enp = new MoviesReview();
                    //enp.UserId = (int)sdrd["UserId"];
                    enp.Username = (string)sdrd["Username"];
                    enp.MoviewReviewName = (string)sdrd["MoviewReviewName"];
                    enp.MovieId = (int)sdrd["MovieId"];
                    enp.MovieRating = (int)sdrd["MovieRating"];
                    //enp.MoviewImageId = (string)sdrd["Password"];
                    enp.Feedback = (string)sdrd["Feedback"];

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

        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/MovieReview/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/MovieReview
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/MovieReview/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/MovieReview/5
        //public void Delete(int id)
        //{
        //}
    }
}
