using BookstoreAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace BookstoreAPI.Repositry;


public interface IBookRepository
{
    Task<List<BookModel>> GetAllBookAsync();

    Task<BookModel> GetBookByIdAsync(int bookId);

   
    Task<int> AddBookAsync(BookModel bookModel);

    Task UpdateBookAsync(int bookId, BookModel bookModel);
}
