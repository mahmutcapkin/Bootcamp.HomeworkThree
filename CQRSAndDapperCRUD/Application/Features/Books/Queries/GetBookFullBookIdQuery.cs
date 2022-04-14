using Application.Features.Books.DTOs;
using Application.Repositories;
using Domain.Response;
using MediatR;

namespace Application.Features.Books.Queries
{
    public class GetBookFullBookIdQuery : IRequest<ResponseDto<BookFullDto>>
    {
        public int BookId { get; set; }
        public class GetBookFullBookIdQueryHandler : IRequestHandler<GetBookFullBookIdQuery, ResponseDto<BookFullDto>>
        {
            private readonly IBookRepository _bookRepository;

            public GetBookFullBookIdQueryHandler(IBookRepository bookRepository)
            {
                _bookRepository = bookRepository;
            }
            public async Task<ResponseDto<BookFullDto>> Handle(GetBookFullBookIdQuery request, CancellationToken cancellationToken)
            {
                var result = await _bookRepository.GetBookFullBookIdByFunction(request.BookId);
                return ResponseDto<BookFullDto>.Success(result, 200);
            }
        }
    }
}
