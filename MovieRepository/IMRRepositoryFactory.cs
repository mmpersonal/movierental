using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MovieRentalRepository
{
    public interface IMRRepositoryFactory : IDisposable
    {

        IMovieRepository Movies { get; set; }

        IPersonRepository persons { get; set; }
        IMoviePersonRepository moviePersons { get; set; }
        int Complete();
    }
}
