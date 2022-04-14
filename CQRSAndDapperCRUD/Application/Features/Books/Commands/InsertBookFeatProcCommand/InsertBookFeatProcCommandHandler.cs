using Application.Repositories;
using Domain.Response;
using MediatR;

namespace Application.Features.Books.Commands.InsertBookFeatProcCommand
{
    public class InsertBookFeatProcCommandHandler : IRequestHandler<InsertBookFeatProcCommand, ResponseDto<NoContent>>
    {
        private readonly IBookRepository _bookRepository;

        public InsertBookFeatProcCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ResponseDto<NoContent>> Handle(InsertBookFeatProcCommand request, CancellationToken cancellationToken)
        {
            var result = await _bookRepository.InsertBookFeatureByProcedure(request);
            if (result)
            {
                return ResponseDto<NoContent>.Success(201);
            }
            return ResponseDto<NoContent>.Fail("InsertBookFeatProcCommand could not be inserted ", 500);

        }
    }
}
