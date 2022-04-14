using FluentValidation;
using Movies.API.Command;

namespace Movies.API.Validators
{
    public class MovieInsertCommandValidator : AbstractValidator<MovieInsertCommand>
    {
        public MovieInsertCommandValidator()
        {

            RuleFor(x => x.Name).NotNull().WithMessage("Name alanı boş olamaz").NotEmpty().WithMessage("Name alanı boş olamaz");
            RuleFor(x => x.Income).NotNull().WithMessage("Income alanı boş olamaz");
            RuleFor(x => x.ReleaseDate).NotNull().WithMessage("ReleaseDate alanı boş olamaz");
            RuleFor(x => x.Rating).NotNull().WithMessage("Rating alanı boş olamaz");
        }
    }
}
