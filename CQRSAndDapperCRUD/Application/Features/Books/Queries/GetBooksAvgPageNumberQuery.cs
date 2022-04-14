using Application.Repositories;
using Domain.Response;
using MediatR;

namespace Application.Features.Books.Queries
{
    public class GetBooksAvgPageNumberQuery : IRequest<ResponseDto<int>>
    {

        public class GetBooksAvgPageNumberQueryHandler : IRequestHandler<GetBooksAvgPageNumberQuery, ResponseDto<int>>
        {
            private readonly IBookRepository _bookRepository;

            public GetBooksAvgPageNumberQueryHandler(IBookRepository bookRepository)
            {
                _bookRepository = bookRepository;
            }
            public async Task<ResponseDto<int>> Handle(GetBooksAvgPageNumberQuery request, CancellationToken cancellationToken)
            {
                var result = await _bookRepository.GetBooksAvgPageNumber();
                return ResponseDto<int>.Success(result, 200);
            }
        }
    }
}
