using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieRental.API;
using MovieRental.DataModel;
using MovieRental.DataModel.Connect;

namespace MovieRentalTests
{
    [TestClass]
    public class CatalogServiceTests
    {
        [TestMethod]
        public void GetAvailableMoviesTest()
        {
            CatalogService cs = new CatalogService();
            MoviesResult result = cs.GetAvailableMovies();
            if ((result.StatusCode == ConnectStatusCode.Success) && result.movies !=null)
                Assert.IsTrue(true);
            else
                Assert.IsTrue(false);
        }

        [TestMethod]
        public void GetAllMoviesTest()
        {
            CatalogService cs = new CatalogService();
            MoviesResult result = cs.GetAllMovies();
            if ((result.StatusCode == ConnectStatusCode.Success) && result.movies != null)
                Assert.IsTrue(true);
            else
                Assert.IsTrue(false);
        }
        [TestMethod]
        public void GetAllMoviesByCategoryTest()
        {
            CatalogService cs = new CatalogService();
            MoviesResult result = cs.GetMoviesByCategory(CategoryEnum.Comedy);
            if ((result.StatusCode == ConnectStatusCode.Success) && result.movies != null)
            {
                if(result.movies.Count > 0)
                {
                    if( result.movies[0].Category == CategoryEnum.Comedy)
                        Assert.IsTrue(true);
                }
            }   
            else
                Assert.IsTrue(false);
        }
        [TestMethod]
        public void GetAllMoviesByRatingTest()
        {
            CatalogService cs = new CatalogService();
            MoviesResult result = cs.GetMoviesByRating(RatingEnum.PG);
            if ((result.StatusCode == ConnectStatusCode.Success) && result.movies != null)
            {
                if (result.movies.Count > 0)
                {
                    if (result.movies[0].Rating == RatingEnum.PG)
                        Assert.IsTrue(true);
                    else
                        Assert.IsTrue(false);
                }
            }
            else
                Assert.IsTrue(false);
        }
        [TestMethod]
        public void SubmitMovieTest()
        {
            CatalogService cs = new CatalogService();
            MoviePersonDetails moviePerson = new MoviePersonDetails();
            MovieSummary movie = new MovieSummary();
            movie.Category = CategoryEnum.Family;
            movie.Description = "Test Movie";
            movie.Language = LanguageEnum.En;
            movie.Length = 90;
            movie.Rating = RatingEnum.G;
            movie.ReleaseYear = 2018;
            movie.rental_duration = 10; //in days
            movie.rental_rate = 10;
            movie.Summary = "Test summary";
            movie.Title = "Test movie";
            moviePerson.movie = movie;
            MovieSubmissionResult result = cs.SubmitMovie(moviePerson);
            if ((result.StatusCode == ConnectStatusCode.Success) && result.MovieId != 0)
                Assert.IsTrue(true);
            else
                Assert.IsTrue(false);
        }
    }
}
