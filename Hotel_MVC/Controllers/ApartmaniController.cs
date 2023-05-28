using Hotel_MVC.Models;
using Hotel_MVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel_MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmaniController : ControllerBase
    {
        private readonly IApartmanService apartmanService;

        public ApartmaniController(IApartmanService apartmanService)
        {
            this.apartmanService = apartmanService;
        }
        // GET: api/<ApartmaniController>
        [HttpGet]
        [Route("api/Apartmani")]
        public IActionResult Get()
        {
            //var apartmani = apartmanService.Get();
            //return View("Index", apartmani);
            return Ok();
        }

        // GET api/<ApartmaniController>/5
        [HttpGet("{id}")]
        public ActionResult<Apartman> Get(string id)
        {
            var apartman = apartmanService.Get(id);

            if (apartman == null)
            {
                return NotFound($"Apartman sa Id = {id} nije pronadjen");
            }
            return apartman;
        }

        // POST api/<ApartmaniController>
        [HttpPost]
        public ActionResult<Apartman> Post([FromBody] Apartman apartman)
        {
            apartmanService.Create(apartman);

            return CreatedAtAction(nameof(Get), new { id = apartman.Id }, apartman);
        }

        // PUT api/<ApartmaniController>/5
        [HttpPut("{id}")]
        public ActionResult<Apartman> Put(string id, [FromBody] Apartman apartman)
        {
            var existingApartman = apartmanService.Get(id);

            if (existingApartman == null)
            {
                return NotFound($"Apartman sa Id = {id} nije pronadjen");
            }

            apartmanService.Update(id, apartman);

            return NoContent();
        }

        // DELETE api/<ApartmaniController>/5
        [HttpDelete("{id}")]
        public ActionResult<Apartman> Delete(string id)
        {
            var apartman = apartmanService.Get(id);

            if (apartman == null)
            {
                return NotFound($"Apartman sa Id = {id} nije pronadjen");
            }

            apartmanService.Remove(apartman.Id);

            return Ok($"Apartman sa Id = {id} obrisan");
        }
    }
}
