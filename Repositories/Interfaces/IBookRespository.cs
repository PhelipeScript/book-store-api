using BookStoreAPI.Entities;

namespace BookStoreAPI.Repositories.Interfaces;

public interface IBookRespository
{
    List<Book> Fetch();
}
