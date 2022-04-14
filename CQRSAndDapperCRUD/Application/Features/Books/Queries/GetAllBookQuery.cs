using Application.Features.Books.DTOs;
using Application.Repositories;
using AutoMapper;
using Domain.Response;
using MediatR;

namespace Application.Features.Books.Queries
{
    public class GetAllBookQuery : IRequest<ResponseDto<List<BookDto>>>
    {

        public class GetAllBookQueryHandler : IRequestHandler<GetAllBookQuery, ResponseDto<List<BookDto>>>
        {
            private readonly IMapper _mapper;
            private readonly IBookRepository _bookRepository;

            public GetAllBookQueryHandler(IMapper mapper, IBookRepository bookRepository)
            {
                _mapper = mapper;
                _bookRepository = bookRepository;
            }

            public async Task<ResponseDto<List<BookDto>>> Handle(GetAllBookQuery request, CancellationToken cancellationToken)
            {
                var books = await _bookRepository.GetAllAsync();
                var mappedbook = _mapper.Map<List<BookDto>>(books);
                return ResponseDto<List<BookDto>>.Success(mappedbook, 200);
            }
        }
    }
}
