using Application.Features.Books.Rules;
using Application.Repositories;
using AutoMapper;
using Domain;
using Domain.Response;
using MediatR;

namespace Application.Features.Books.Commands.UpdateBookCommand
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, ResponseDto<NoContent>>
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        BookBusinessRules _bookBusinessRules;

        public UpdateBookCommandHandler(IMapper mapper, IBookRepository bookRepository, BookBusinessRules bookBusinessRules)
        {
            _mapper = mapper;
            _bookBusinessRules = bookBusinessRules;
            _bookRepository = bookRepository;
        }
        public async Task<ResponseDto<NoContent>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var mappedbook = _mapper.Map<Book>(request);
            await _bookBusinessRules.BookIdShouldExistWhenSelected(mappedbook.Id);
            var uptadedbook = await _bookRepository.UpdateAsync(mappedbook);
            return uptadedbook ? ResponseDto<NoContent>.Success(204) : ResponseDto<NoContent>.Fail("Update process failed", 500);
        }
    }
}
