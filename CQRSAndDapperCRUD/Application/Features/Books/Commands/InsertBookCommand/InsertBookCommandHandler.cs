using Application.Observer;
using Application.Repositories;
using AutoMapper;
using Domain;
using Domain.Response;
using MediatR;

namespace Application.Features.Books.Commands.InsertBookCommand
{
    public class InsertBookCommandHandler : IRequestHandler<InsertBookCommand, ResponseDto<int>>
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        private readonly ObserverSubject _observerSubject;

        public InsertBookCommandHandler(IMapper mapper, IBookRepository bookRepository, ObserverSubject observerSubject)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
            _observerSubject = observerSubject;
        }

        public async Task<ResponseDto<int>> Handle(InsertBookCommand request, CancellationToken cancellationToken)
        {
            var mappedBook = _mapper.Map<Book>(request);
            var id = await _bookRepository.AddAsync(mappedBook);
            if (id > 0)
            {
                _observerSubject.NotifySubscribes(_mapper.Map<BookCreated>(mappedBook));
            }
            return ResponseDto<int>.Success(id, 201);
        }
    }
}
