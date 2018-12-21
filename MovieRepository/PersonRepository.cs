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
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(DbContext context) : base(context)
        {
        }
        public MovieRentalEntityContext _mrEntityContext
        {
            get { return _context as MovieRentalEntityContext; }
        }
        
    }
}
