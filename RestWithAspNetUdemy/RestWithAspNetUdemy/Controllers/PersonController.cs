using Microsoft.AspNetCore.Mvc;
using RestWithAspNetUdemy.Model;
using RestWithAspNetUdemy.Services;

namespace RestWithAspNetUdemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : Controller
    {
        private IPersonService personService;

        public PersonController(IPersonService personService)
        {
            this.personService = personService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(personService.FindAll());
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var person = personService.FindById(id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }

            return new ObjectResult(personService.Create(person));
        }

        [HttpPut]
        public IActionResult Put([FromBody]Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }

            return new ObjectResult(personService.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            personService.Delete(id);
            return NoContent();
        }
    }
}