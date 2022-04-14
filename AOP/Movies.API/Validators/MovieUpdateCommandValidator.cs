using FluentValidation;
using Movies.API.Command;

namespace Movies.API.Validators
{
    public class MovieUpdateCommandValidator:AbstractValidator<MovieUpdateCommand>
    {
        public MovieUpdateCommandValidator()
        {

            RuleFor(x => x.Name).NotNull().WithMessage("Name alanı boş olamaz").NotEmpty().WithMessage("Name alanı boş olamaz");
            RuleFor(x => x.Income).NotNull().WithMessage("Income alanı boş olamaz");
            RuleFor(x => x.ReleaseDate).NotNull().WithMessage("ReleaseDate alanı boş olamaz");
            RuleFor(x => x.Rating).NotNull().WithMessage("Rating alanı boş olamaz");
            RuleFor(x => x.Id).NotNull().WithMessage("Id alanı boş olamaz");

        }
    }
}
