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

    [HttpGet("fetch")]
    [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
    public IActionResult Fetch()
    {
        var books = _bookRespository.Fetch();

        return Ok(books);
    }
}
