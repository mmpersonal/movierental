using MovieRentalModel;
using MovieRentalRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MovieRentalRepostory
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(DbContext context) : base(context)
        {
        }
        public MovieRentalEntityContext _mrEntityContext
        {
            get { return _context as MovieRentalEntityContext; }
        }
        public List<Movie> GetAllAvailableMovies()
        {
            var query = (from m in _mrEntityContext.Movies
                            from c in _mrEntityContext.Inventories.Where(x => x.MovieId == m.MovieId && x.Isavailable == true)
                            select m
              
                        );
            return query.ToList();
        }
        public Movie GetMovieByID(long MovieId)
        {
            return _mrEntityContext.Movies.Where(i => i.MovieId == MovieId).FirstOrDefault(); ;
        }
        public List<Movie> GetMoviesByCategory(int CategoryId)
        {
            return _mrEntityContext.Movies.Where(i=>i.CategoryId==CategoryId).ToList();
        }
        public List<Movie> GetMoviesByRating(int RatingId)
        {
            return _mrEntityContext.Movies.Where(i=>i.RatingId==RatingId).ToList();
        }
        public bool GetAvailabilityStatus(int movieId)
        {
            var query = (from m in _mrEntityContext.Movies
                         from c in _mrEntityContext.Inventories.Where(x => x.MovieId == m.MovieId)
                         select new
                         {
                            c.Isavailable,
                            m.MovieId
                         }

                        ).FirstOrDefault();
            return (query == null) ? false : (bool)query.Isavailable;
        }
    }
}
