using Application.BaseValidator;
using Application.Features.Books.Commands.InsertBookCommand;
using FluentValidation;

namespace Application.Features.Books.Validators
{
    public class InsertBookCommandValidator : AbstractValidator<InsertBookCommand>
    {
        public InsertBookCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.Name).NotNull().WithMessage(ValidatorMessages.NotNullMessage);

            RuleFor(x => x.AuthorId).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.AuthorId).NotNull().WithMessage(ValidatorMessages.NotNullMessage);
            RuleFor(x => x.AuthorId).NotEqual(0).WithMessage(ValidatorMessages.IdNotEqualToZero);

            RuleFor(x => x.Publisher).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.Publisher).NotNull().WithMessage(ValidatorMessages.NotNullMessage);

            RuleFor(x => x.PageNumber).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.PageNumber).NotNull().WithMessage(ValidatorMessages.NotNullMessage);
            RuleFor(x => x.PageNumber).NotEqual(0).WithMessage(ValidatorMessages.IdNotEqualToZero);


             


        }
    }
}
