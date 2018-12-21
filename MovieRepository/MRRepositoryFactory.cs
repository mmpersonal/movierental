
using MovieRentalModel;
using MovieRentalRepostory;

namespace MovieRentalRepository
{
    public class MRRepositoryFactory : IMRRepositoryFactory
    {
        private readonly MovieRentalEntityContext _context;

        public MRRepositoryFactory(MovieRentalEntityContext context)
        {
            _context = context;

            _context.Configuration.LazyLoadingEnabled = false;

            Movies = new MovieRepository(_context);
            persons = new PersonRepository(_context);
            moviePersons = new MoviePersonRepository(_context);

        }

        public IMovieRepository Movies { get; set; }
        public IPersonRepository persons { get; set; }
        public IMoviePersonRepository moviePersons { get; set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
