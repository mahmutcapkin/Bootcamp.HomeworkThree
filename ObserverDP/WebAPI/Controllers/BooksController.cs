using Application.Features.Books.Commands.DeleteBookCommand;
using Application.Features.Books.Commands.InsertBookCommand;
using Application.Features.Books.Commands.InsertBookFeatProcCommand;
using Application.Features.Books.Commands.UpdateBookCommand;
using Application.Features.Books.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerCustomBase
    {
        private readonly IMediator _mediator;
        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllBookQuery());
            return CreateActionResult(response);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _mediator.Send(new GetByIdBookQuery() { Id = id });
            return CreateActionResult(response);
        }

        [HttpGet("pages/{page:int}/{pagesize:int}")]
        public async Task<IActionResult> GetAllWithPage(int page, int pagesize)
        {
            var response = await _mediator.Send(new GetAllWithPageBookQuery() { Page = page, PageSize = pagesize });
            return CreateActionResult(response);
        }


        [HttpPost]
        public async Task<IActionResult> Insert(InsertBookCommand command)
        {
            return CreateActionResult(await _mediator.Send(command));
        }


        [HttpPut]
        public async Task<IActionResult> Update(UpdateBookCommand command)
        {
            return CreateActionResult(await _mediator.Send(command));
        }



        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        { 
            return CreateActionResult(await _mediator.Send(new DeleteBookCommand() { Id = id }));
        }


        [HttpPost("InsertBookFeature")]
        public async Task<IActionResult> InsertBookFeature(InsertBookFeatProcCommand command)
        {
            return CreateActionResult(await _mediator.Send(command));
        }

        [HttpGet("GetBookFullBookId/{bookId:int}")]
        public async Task<IActionResult> GetBookFullBookId(int bookId)
        {
            return CreateActionResult(await _mediator.Send(new GetBookFullBookIdQuery() {BookId=bookId }));
        }

        [HttpGet("GetBooksAvgPageNumber")]
        public async Task<IActionResult> GetBooksAvgPageNumber()
        {
            return CreateActionResult(await _mediator.Send(new GetBooksAvgPageNumberQuery()));
        }


        [HttpGet("GetSumPageNumberAuthorId/{authorId:int}")]
        public async Task<IActionResult> GetSumPageNumberAuthorId(int authorId)
        {
            return CreateActionResult(await _mediator.Send(new GetSumPageNumberAuthorIdQuery() { AuthorId = authorId }));
        }


    }
}
