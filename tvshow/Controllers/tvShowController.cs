using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using tvshow.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace tvshow.Controllers
{
    [Route("api/[controller]")]
    public class tvShowController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<TvShow> Get()
        {
            using(TvShowContext context = new()){
                var tvShowData = context.TvShows;
                return tvShowData;
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public TvShow Get(int id)
        {
             using(TvShowContext context = new()){
                var tvShowData = context.TvShows.First(x => x.Id == id);
                return tvShowData;
            }
        }

        // GET api/values/Hercules
        [HttpGet("{name}")]
        public TvShow Get(string name)
        {
             using(TvShowContext context = new()){
                var tvShowData = context.TvShows.First(x => x.Name == name);
                return tvShowData;
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] List<TvShow> obj)
        {

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
            using(TvShowContext context = new()){
                var entidad = context.TvShows.Single(x => x.Id == id);
                context.TvShows.Remove(entidad);
            }
        }
    }
}

