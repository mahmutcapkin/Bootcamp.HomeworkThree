using Application.Features.Books.DTOs;
using Application.Repositories;
using AutoMapper;
using Domain.Response;
using MediatR;

namespace Application.Features.Books.Queries
{
    public class GetByIdBookQuery : IRequest<ResponseDto<BookDto>>
    {
        public int Id { get; set; }

        public class GetByIdBookQueryHandler : IRequestHandler<GetByIdBookQuery, ResponseDto<BookDto>>
        {
            private readonly IMapper _mapper;
            private readonly IBookRepository _bookRepository;

            public GetByIdBookQueryHandler(IMapper mapper, IBookRepository bookRepository)
            {
                _mapper = mapper;
                _bookRepository = bookRepository;
            }
            public async Task<ResponseDto<BookDto>> Handle(GetByIdBookQuery request, CancellationToken cancellationToken)
            {
                var book = _bookRepository.GetByIdAsync(request.Id);
                var mappedbook = _mapper.Map<BookDto>(book.Result);
                return ResponseDto<BookDto>.Success(mappedbook, 200);


            }
        }
    }
}
