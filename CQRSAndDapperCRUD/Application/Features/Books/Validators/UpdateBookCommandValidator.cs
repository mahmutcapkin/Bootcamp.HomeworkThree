using Application.BaseValidator;
using Application.Features.Books.Commands.UpdateBookCommand;
using FluentValidation;

namespace Application.Features.Books.Validators
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(ValidatorMessages.NotEmptyMessage);
            RuleFor(x => x.Id).NotNull().WithMessage(ValidatorMessages.NotNullMessage);
            RuleFor(x => x.Id).NotEqual(0).WithMessage(ValidatorMessages.IdNotEqualToZero);

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
