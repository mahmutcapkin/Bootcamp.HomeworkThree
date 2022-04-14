using Domain.Response;
using MediatR;

namespace Application.Features.Books.Commands.DeleteBookCommand
{
    public class DeleteBookCommand : IRequest<ResponseDto<NoContent>>
    {
        public int Id { get; set; }
    }
}
