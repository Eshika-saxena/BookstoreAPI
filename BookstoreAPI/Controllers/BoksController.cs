using BookstoreAPI.Model;
using BookstoreAPI.Models;
using BookstoreAPI.Repository;
using BookstoreAPI.Repositry;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;

        }
        [HttpGet("")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBookAsync();

            return Ok(books);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute] int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);

            return Ok(book);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddNewBook([FromBody]BookModel bookModel)
        {
            var id= await _bookRepository.AddBookAsync(bookModel);
            return CreatedAtAction(nameof(GetBookById), new {id = id, controller ="books"}, id);



        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromBody] BookModel bookModel, [FromRoute]int id)
        {
            await _bookRepository.UpdateBookAsync(id, bookModel);
            return Ok();



        }

    } 
}
