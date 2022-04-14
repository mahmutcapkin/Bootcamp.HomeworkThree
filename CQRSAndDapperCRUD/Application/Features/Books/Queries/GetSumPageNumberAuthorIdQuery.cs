using Application.Features.Books.DTOs;
using Application.Repositories;
using Domain.Response;
using MediatR;

namespace Application.Features.Books.Queries
{
    public class GetSumPageNumberAuthorIdQuery : IRequest<ResponseDto<BookSumPageNumberDto>>
    {
        public int AuthorId { get; set; }
        public class GetSumPageNumberAuthorIdQueryHandler : IRequestHandler<GetSumPageNumberAuthorIdQuery, ResponseDto<BookSumPageNumberDto>>
        {
            private readonly IBookRepository _bookRepository;

            public GetSumPageNumberAuthorIdQueryHandler(IBookRepository bookRepository)
            {
                _bookRepository = bookRepository;
            }
            public async Task<ResponseDto<BookSumPageNumberDto>> Handle(GetSumPageNumberAuthorIdQuery request, CancellationToken cancellationToken)
            {
               var result = await _bookRepository.GetSumPageNumberAuthorIdByFunction(request.AuthorId);
                return ResponseDto<BookSumPageNumberDto>.Success(result, 200);
            }
        }
    }
}
