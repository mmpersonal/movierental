using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MovieRental.DataModel.Connect;

/// <summary>
/// Used for getting Movies Summary data including thumbnail , Details data from catalog and update/add movie items to the catalog
/// </summary>
namespace MovieRental.API
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ICatalogService
    {
 
        [OperationContract]
        MoviesResult GetAvailableMovies();

        [OperationContract]
        MoviesResult GetAllMovies();

        [OperationContract]
        MovieSubmissionResult SubmitMovie(MoviePersonDetails moviePersonDetails);

        
        [OperationContract]
        MovieSubmissionResult UpdateMovie(MoviePersonDetails moviePersonDetails);

        [OperationContract]
        MovieSubmissionResult RemoveMovie(int MovieId);

        [OperationContract]
        ConnectResult GetAvailabilityStatus(int MovieId);

    }   

   
}
