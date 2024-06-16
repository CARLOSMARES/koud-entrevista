using Microsoft.AspNetCore.Mvc;
//using tvshow.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace tvshow.Controllers
{
    [Route("api/[controller]")]
    public class tvShowController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Hola Mundo!!!!" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Object obj)
        {
            string sentencia = "insert into tvShow (id, name, favorite) value (";
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            string setencia = "delete * from tvShow where id = " + id;
        }
    }
}

