using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ScriptsBookmark.WebApi.Controllers
{
    public class ValuesController : ApiController
    {

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            //using (var ctx = new BookmarkContext())
            //{
            //    var y = await ctx.Bookmarks.FindAsync(id);
            //    Debug.Print(y.Title);
            //}
            //var x = await _context.Bookmarks.FindAsync(id);

            string constring = "Data source=(localdb)\\mssqllocaldb;Database=ScriptsBookmark;Trusted_Connection=True;MultipleActiveResultSets=true";

            //Check the database connection
            SqlConnection connection = new SqlConnection(constring);

            connection.Open();
            var x = connection.Database;

            if (connection.State == System.Data.ConnectionState.Open)
            {
                return "Success connection. Database name: " + x;
            }
            else
            {
                return "Fail";
            }


        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
