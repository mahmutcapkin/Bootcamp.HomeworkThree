using Application.Exceptions;
using Application.Repositories;
using Domain;

namespace Application.Features.Books.Rules
{
    public class BookBusinessRules
    {
        private readonly IBookRepository  _bookRepository;
        public BookBusinessRules(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task BookIdShouldExistWhenSelected(int id)
        {
            Book? result = await _bookRepository.GetByIdAsync(id);
            if (result == null) throw new BusinessException("book not exists.");
        }

    }
}
