using BookStoreAPI.DTOs;
using BookStoreAPI.Entities;
using BookStoreAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers;

public class BookController : BookStoreAPIBASEController
{
    private readonly IBookRespository _bookRespository;

    public BookController(IBookRespository bookRespository)
    {
        _bookRespository = bookRespository;
    }

    [HttpGet()]
    [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
    public IActionResult Fetch()
    {
        var books = _bookRespository.Fetch();

        return Ok(books);
    }

    [HttpGet()]
    [Route("{id}")]
    [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Get([FromRoute]string id)
    {
        Book? book = _bookRespository.Get(id);

        if (book == null)
        {
            return NotFound();
        }

        return Ok(book);
    }

    [HttpPost("create")]
    [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
    public IActionResult Create([FromBody]CreateBookDTO bookDto)
    {
        string bookId = Guid.NewGuid().ToString();
        Book newBook = new Book()
        {
            Id = bookId,
            Title = bookDto.Title,
            Description = bookDto.Description,
            Genre = bookDto.Genre,
            Author = bookDto.Author,
            Quantity = bookDto.Quantity,
            Value = bookDto.Value
        };

        _bookRespository.Add(newBook);

        return Created("", bookId);
    }

    [HttpPut()]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update([FromRoute]string id, [FromBody]UpdateBookDTO bookDto)
    {
        Book? existingBook = _bookRespository.Get(id);

        if (existingBook == null) { return NotFound(); }

        existingBook.Title = bookDto.Title;
        existingBook.Description = bookDto.Description;
        existingBook.Genre = bookDto.Genre;
        existingBook.Author = bookDto.Author;
        existingBook.Quantity = bookDto.Quantity;
        existingBook.Value = bookDto.Value;

        _bookRespository.Update(existingBook);

        return Ok();
    }

    [HttpDelete()]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Delete([FromRoute]string id)
    {
        _bookRespository.Delete(id);
        return Ok();
    }
}
