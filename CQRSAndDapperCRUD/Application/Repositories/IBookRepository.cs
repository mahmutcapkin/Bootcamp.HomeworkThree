using Application.Features.Books.Commands.InsertBookFeatProcCommand;
using Application.Features.Books.DTOs;
using Domain;

namespace Application.Repositories
{
    public interface IBookRepository
    {
        Task<Book> GetByIdAsync(int id);
        Task<List<Book>> GetAllAsync();
        Task<List<Book>> GetAllWithPage(int page, int pageSize);
        Task<int> AddAsync(Book entity);
        Task<bool> UpdateAsync(Book entity);
        Task<bool> DeleteAsync(Book entity);

        Task<bool> InsertBookFeatureByProcedure(InsertBookFeatProcCommand command);

        Task<int> GetBooksAvgPageNumber();

        Task<BookSumPageNumberDto> GetSumPageNumberAuthorIdByFunction(int authorId);
        Task<BookFullDto> GetBookFullBookIdByFunction(int bookId);
    }
}
