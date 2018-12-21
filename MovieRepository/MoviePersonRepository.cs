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
    public class MoviePersonRepository : Repository<MoviePerson>, IMoviePersonRepository
    {
        public MoviePersonRepository(DbContext context) : base(context)
        {
        }
        public MovieRentalEntityContext _mrEntityContext
        {
            get { return _context as MovieRentalEntityContext; }
        }

    }
}
