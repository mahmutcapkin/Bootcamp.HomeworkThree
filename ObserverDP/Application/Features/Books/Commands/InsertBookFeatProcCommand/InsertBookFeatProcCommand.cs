using Domain.Response;
using MediatR;

namespace Application.Features.Books.Commands.InsertBookFeatProcCommand
{
    public class InsertBookFeatProcCommand : IRequest<ResponseDto<NoContent>>
    {
        public int BookId { get; set; }
        public string FontStyle { get; set; }
    }
}
