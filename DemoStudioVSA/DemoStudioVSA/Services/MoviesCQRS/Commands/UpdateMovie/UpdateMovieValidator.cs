using FluentValidation;

namespace StudioVSA.Services.MoviesCQRS.Commands.UpdateMovie;

public class UpdateMovieValidator : AbstractValidator<UpdateMovieCommand>
{
    public UpdateMovieValidator()
    {
        RuleFor(x => x.MovieDto).NotNull();
        RuleFor(x => x.MovieDto.Id).NotNull();
    }
}
