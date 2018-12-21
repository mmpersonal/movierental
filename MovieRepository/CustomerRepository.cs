using MovieRentalModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;


namespace MovieRentalRepository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {

        public CustomerRepository(MovieRentalEntityContext context)
            : base(context)
        {
        }
        public MovieRentalEntityContext _movieRentalEntityContext
        {
            get { return _context as MovieRentalEntityContext; }
        }

        
    }
}
