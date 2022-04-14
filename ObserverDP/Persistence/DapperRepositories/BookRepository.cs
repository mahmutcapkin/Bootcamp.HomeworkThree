using Application.Features.Books.Commands.InsertBookFeatProcCommand;
using Application.Features.Books.DTOs;
using Application.Repositories;
using Dapper;
using Domain;
using System.Data;

namespace Persistence.DapperRepositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IDbConnection _connection;

        public BookRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<int> AddAsync(Book entity)
        {

            var command = "insert into books(name,pagenumber,publisher,authorid) values(@name,@pagenumber,@publisher,@authorid) returning id";
            var id = await _connection.ExecuteScalarAsync<int>(command, entity);
            return id;

        }

        public async Task<bool> UpdateAsync(Book entity)
        {

            var command = "update books set name=@name, pagenumber=@pagenumber, publisher=@publisher, authorid=@authorid  where id=@id";
            return await _connection.ExecuteAsync(command, entity) > 0;
        }

        public async Task<bool> DeleteAsync(Book entity)
        {
            var command = "delete from books where id=@id";
            return await _connection.ExecuteAsync(command, entity) > 0;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            var query = "select * from books";
            var books = await _connection.QueryAsync<Book>(query);
            return books.ToList();
        }

        public async Task<List<Book>> GetAllWithPage(int page, int pageSize)
        {
            int offset = (page - 1) * pageSize;
            var query = "select * from books order by id desc limit @pagesize offset @offset";
            var books = await _connection.QueryAsync<Book>(query, new { pagesize = pageSize, offset = offset });
            return books.ToList();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            var query = "select * from books where id=@id";
            var book = await _connection.QuerySingleOrDefaultAsync<Book>(query, new { id = id });
            return book;
        }

        public async Task<bool> InsertBookFeatureByProcedure(InsertBookFeatProcCommand command)
        {
            var sp = $"call sp_insert_bookfeatures({command.BookId},{command.FontStyle})";
            return await _connection.ExecuteAsync(sp, command) > 0;
        }

        public async Task<int> GetBooksAvgPageNumber()
        {
            var query = "func_books_avg_pagenumber";
            var result = await _connection.ExecuteScalarAsync<int>(query, commandType: CommandType.StoredProcedure);
            return result;
        }

        public async Task<BookSumPageNumberDto> GetSumPageNumberAuthorIdByFunction(int authorId)
        {

            var query = "select sum_pagenumber sumpagenumber from  func_book_sum_pagenumber_by_authorid(@authorid)";
            var result = await _connection.QueryFirstAsync<BookSumPageNumberDto>(query, new { authorid = authorId });
            return result;

        }

        public async Task<BookFullDto> GetBookFullBookIdByFunction(int bookId)
        {

            var query = "select * from func_full_book(@bookid)";
            var result = await _connection.QueryFirstAsync<BookFullDto>(query, new { bookid = bookId });
            return result;
        }





    }
}
