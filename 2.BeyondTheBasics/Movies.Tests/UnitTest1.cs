using FluentAssertions;
using Movies.Api.Controllers;
using Movies.Application.Services;
using Movies.Domain.Models;
using NSubstitute;

namespace Movies.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            //Arrange
            var movieService = Substitute.For<IMovieService>();
            var _sut = new MoviesController(movieService);
            var token = new CancellationToken();

            //Act
            var result = await _sut.GetAll(token);



            //Assert
            result.Should().NotBeNull();


        }

        [Fact]
        public async Task Should_Be_Success_When_Exits()
        {
            var movie = new Movie
            {
                Title = "Test",
                Id = Guid.NewGuid(),
                Genres = new List<Genre>(),
                YearOfRelease = 2001
            };


            var movieService = Substitute.For<IMovieService>();
            var _sut = new MoviesController(movieService);
            var token = new CancellationToken();
            await movieService.CreateAsync(movie);




            //Act
            var result = await _sut.GetAll(token);



            //Assert
            result.Should().NotBeNull();
        }
    }
}