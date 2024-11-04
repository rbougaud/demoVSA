using StudioVSA.Common.Dto;
using StudioVSA.Domain.Abstractions;
using StudioVSA.Domain.Entities;
using StudioVSA.Services.MoviesCQRS.Commands.CreateMovie;

namespace StudioVSA.Mapping;

public static class MovieMapper
{
    public static Movie ToDao(this AddMovieCommand command)
    {
        return new Movie
        {
            Id = Guid.NewGuid(),
            Title = command.Title,
            Author = command.Author,
            ReleaseDate = command.ReleaseDate
        };
    }

    public static IMovieDto ToDto(this Movie? movie)
    {
        if (movie is null) { return new MovieDtoNotFound(); }
        return new MovieDto 
        { 
            Id= movie.Id,
            Title = movie.Title,
            Author = movie.Author, 
            ReleaseDate = movie.ReleaseDate
        };
    }
}
