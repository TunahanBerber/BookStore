using FluentValidation;
using WebApi.BookOperations.CreateBookCs;
namespace WebApi.BookOperations.CreateBook
{
    public class DeleteBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            // RuleFor(command => command.BookId).GreaterThan(0));
        }
    }
}
