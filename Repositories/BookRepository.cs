using BookStoreAPI.Entities;
using BookStoreAPI.Repositories.Interfaces;
using System.Text.Json;

namespace BookStoreAPI.Repositories;

public class BookRepository : IBookRespository
{
    private List<Book> _books;

    public BookRepository()
    {
        string json = File.ReadAllText("books.json");
        _books = JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
    }

    public List<Book> Fetch()
    {
        return _books;
    }

    public Book? Get(string id)
    {
        Book? book = _books.Find(book => book.Id.Equals(id));
        return book;
    }

    public void Delete(string id)
    {
        List<Book> booksWithoutTheDeletedOne = _books.FindAll(book => book.Id != id);

        _books = booksWithoutTheDeletedOne;
    }
}
