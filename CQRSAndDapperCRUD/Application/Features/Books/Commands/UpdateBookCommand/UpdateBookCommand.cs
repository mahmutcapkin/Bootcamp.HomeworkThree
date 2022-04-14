using Domain;
using Domain.Response;
using MediatR;

namespace Application.Features.Books.Commands.UpdateBookCommand
{
    public class UpdateBookCommand : IRequest<ResponseDto<NoContent>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PageNumber { get; set; }
        public string Publisher { get; set; }
        public int AuthorId { get; set; }
    }
}
