using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Movies.API.DTOs;
using Movies.API.Repositories;

namespace Movies.API.Filters
{
    public class NotFoundMovieFilter : ActionFilterAttribute
    {
        private readonly IMovieRepository _movieRepository;

        public NotFoundMovieFilter(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {



            var idValue = context.HttpContext.Request.RouteValues["id"];


            int id = int.Parse(idValue.ToString());

            var movie = _movieRepository.GetById(id);

            if (movie != null)
            {
                await next.Invoke();
                return;
            }

            context.Result = new NotFoundObjectResult(ResponseDto<NoContentDto>.Fail($"Id({id})'ye sahip film bulunamamıştır.", 404));






        }
    }
}
