using Application.Features.Books.Rules;
using Application.Repositories;
using AutoMapper;
using Domain;
using Domain.Response;
using MediatR;

namespace Application.Features.Books.Commands.DeleteBookCommand
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, ResponseDto<NoContent>>
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        BookBusinessRules _bookBusinessRules;

        public DeleteBookCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IBookRepository bookRepository, BookBusinessRules bookBusinessRules)
        {
            _mapper = mapper;
            _bookBusinessRules = bookBusinessRules;
            _bookRepository = bookRepository;
        }

        public async Task<ResponseDto<NoContent>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var mappedBook = _mapper.Map<Book>(request);
            await _bookBusinessRules.BookIdShouldExistWhenSelected(mappedBook.Id);
            var deletedbook = await _bookRepository.DeleteAsync(mappedBook);
            return deletedbook ? ResponseDto<NoContent>.Success(204) : ResponseDto<NoContent>.Fail("Delete process failed", 500);

        }
    }
}
