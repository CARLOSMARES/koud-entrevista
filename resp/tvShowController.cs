using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace tvshow.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class tvShowController : ControllerBase
    {
        private readonly TvShowContext _context;

        public tvShowController(TvShowContext context)
        {
            _context = context;
        }

        // GET: api/tvshow
        [HttpGet]
        public ActionResult<IEnumerable<TvShow>> Get()
        {
            var tvShowData = _context.TvShows;
            return Ok(tvShowData);
        }

        // GET api/tvshow/5
        [HttpGet("{id:int}")]
        public ActionResult<TvShow> Get(int id)
        {
            var tvShowData = _context.TvShows.FirstOrDefault(x => x.Id == id);
            if (tvShowData == null)
            {
                return NotFound();
            }
            return Ok(tvShowData);
        }

        // GET api/tvshow/name/Hercules
        [HttpGet("name/{name}")]
        public ActionResult<TvShow> Get(string name)
        {
            var tvShowData = _context.TvShows.FirstOrDefault(x => x.Name == name);
            if (tvShowData == null)
            {
                return NotFound();
            }
            return Ok(tvShowData);
        }

        // POST api/tvshow
        [HttpPost]
        public ActionResult Post([FromBody] List<TvShow> obj)
        {
            _context.TvShows.AddRange(obj);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { }, obj);
        }

        // PUT api/tvshow/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TvShow updatedTvShow)
        {
            var tvShowData = _context.TvShows.FirstOrDefault(x => x.Id == id);
            if (tvShowData == null)
            {
                return NotFound();
            }
            tvShowData.Name = updatedTvShow.Name;
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE api/tvshow/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var entidad = _context.TvShows.FirstOrDefault(x => x.Id == id);
            if (entidad == null)
            {
                return NotFound();
            }
            _context.TvShows.Remove(entidad);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
