using Application.Features.Books.DTOs;
using Application.Repositories;
using AutoMapper;
using Domain.Response;
using MediatR;

namespace Application.Features.Books.Queries
{
    public class GetAllWithPageBookQuery : IRequest<ResponseDto<List<BookDto>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public class GetAllWithPageBookQueryHandler : IRequestHandler<GetAllWithPageBookQuery, ResponseDto<List<BookDto>>>
        {
            private readonly IMapper _mapper;
            private readonly IBookRepository _bookRepository;

            public GetAllWithPageBookQueryHandler(IMapper mapper, IBookRepository bookRepository)
            {
                _mapper = mapper;
                _bookRepository = bookRepository;
            }

            public async Task<ResponseDto<List<BookDto>>> Handle(GetAllWithPageBookQuery request, CancellationToken cancellationToken)
            {
                var books = await _bookRepository.GetAllWithPage(request.Page, request.PageSize);
                var mappedbooks = _mapper.Map<List<BookDto>>(books);
                return ResponseDto<List<BookDto>>.Success(mappedbooks, 200);
            }
        }
    }
}
