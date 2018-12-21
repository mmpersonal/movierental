using MovieRentalModel;
using System.Collections.Generic;

namespace MovieRentalRepository
{
    public interface IMovieRepository : IRepository<Movie>
    {
        List<Movie> GetAllAvailableMovies();
        Movie GetMovieByID(long MovieId);
        List<Movie> GetMoviesByCategory(int CategoryId);
        List<Movie> GetMoviesByRating(int RatingId);
        bool GetAvailabilityStatus(int movieId);
    }
}
