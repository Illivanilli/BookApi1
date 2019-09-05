using CS321_W3D1_BookAPI.Models;
using CS321_W3D1_BookAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CS321_W3D1_BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        // Constructor
        public BooksController(/* Done: inject IBookService */IBookService bookService)
        {
            // Done: keep a reference to the service so we can use below
            _bookService = bookService;
        }

        // Done: get all books
        // GET api/books
        [HttpGet]
        public IActionResult Get()
        {
            // return OK 200 status and list of books
            return Ok(_bookService.GetAll());
        }

        //Done  get specific book by id
        // GET api/books/:id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            // looks up by using .Get(id)
            var book = _bookService.Get(id);
            // return 404 NotFound  if not found.
            if (book == null) return NotFound();
           
            return Ok(book);
        }

        // create a new book
        // POST api/books
        [HttpPost]
        public IActionResult Post([FromBody] Book newBook)
        {
            try
            {
                // add the new book
                _bookService.Add(newBook);
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("Add", ex.Message);
                return BadRequest(ModelState);
            }

            // return a 201 Created status. This will also add a "location" header
            // with the URI of the new book. E.g., /api/books/99, if the new is 99
            return CreatedAtAction("Get", new { Id = newBook.Id }, newBook);
        }

        // Done: update an existing book
        // PUT api/books/:id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Book updatedBook)
        {
            var book = _bookService.Update(updatedBook);
            if (book == null) return NotFound();
            return Ok(book);
        }

        // Done: delete an existing book
        // DELETE api/books/:id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _bookService.Get(id);
            if (book == null) return NotFound();
            _bookService.Remove(book);
            return NoContent();
        }
    }
}
