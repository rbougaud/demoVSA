using FluentValidation;

namespace StudioVSA.Services.MoviesCQRS.Commands.CreateMovie;

public class AddMovieCommandValidator : AbstractValidator<AddMovieCommand>
{
    public AddMovieCommandValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required.");
        RuleFor(x => x.Author).NotEmpty().WithMessage("Author is required.");
        RuleFor(x => x.ReleaseDate).LessThanOrEqualTo(DateTime.Now).WithMessage("Release date must be in the past.");
    }
}
