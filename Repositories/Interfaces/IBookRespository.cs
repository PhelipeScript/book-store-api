using BookStoreAPI.Entities;

namespace BookStoreAPI.Repositories.Interfaces;

public interface IBookRespository
{
    List<Book> Fetch();
    Book? Get(string id);
    void Add(Book book);
    void Delete(string id);
}
