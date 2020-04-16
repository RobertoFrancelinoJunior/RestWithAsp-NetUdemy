using Microsoft.AspNetCore.Mvc;
using RestWithAspNetUdemy.Model;
using RestWithAspNetUdemy.Services;

namespace RestWithAspNetUdemy.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(bookService.FindAll());
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var person = bookService.FindById(id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            return new ObjectResult(bookService.Create(book));
        }

        [HttpPut]
        public IActionResult Put([FromBody]Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            return new ObjectResult(bookService.Update(book));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bookService.Delete(id);
            return NoContent();
        }
    }
}