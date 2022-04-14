using Domain.Response;
using MediatR;

namespace Application.Features.Books.Commands.InsertBookCommand
{
    public class InsertBookCommand : IRequest<ResponseDto<int>>
    {
        public string Name { get; set; }
        public int PageNumber { get; set; }
        public string Publisher { get; set; }
        public int AuthorId { get; set; }
    }
}
