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

        /// <summary>
        /// Gets summary data for all movies that are available to rent from the catalog/inventory
        /// </summary>
        /// <returns>Summary metdata for movies such as description,title,thumbnail, rating, genre, release Year</returns>
        [OperationContract]
        MoviesResult GetAvailableMovies();

        /// <summary>
        /// Gets summary data for all movies from the catalog/inventory
        /// </summary>
        /// <returns>Summary metdata for movies such as description,title,thumbnail, rating, genre, release Year</returns>
        [OperationContract]
        MoviesResult GetAllMovies();

        /// <summary>
        /// Submits metadata about the movie to the catalog/inventory. Adds the movie metadata into catalog
        /// </summary>
        /// <returns>status code and as movieId ( unique identifier for the movie in the catalog). 
        /// Unique movieId should be used for update/remove operations in the service to update and remove the movie in the catalog respectively</returns>
        [OperationContract]
        MovieSubmissionResult SubmitMovie(MoviePersonDetails moviePersonDetails);

        /// <summary>
        /// Update the movie information in the catalog/inventory. you will need movieId to update the movie information and personId to update the peeps information in the catalog
        /// MovieId and PersonId can be retrieved by GetMoviebyName, GetMovieByGenre etc
        /// </summary>
        /// <returns>status code and as movieId ( unique identifier for the movie in the catalog). 
        /// Unique movieId should be used for update/remove operations in the service to update and remove the movie in the catalog respectively</returns>
        [OperationContract]
        MovieSubmissionResult UpdateMovie(MoviePersonDetails moviePersonDetails);

        [OperationContract]
        MovieSubmissionResult RemoveMovie(int MovieId);

        /// <summary>
        /// Get availability to rent status for a given movie Id
        /// </summary>
        /// <param name="MovieId">Unique identifier in movie rental catalog. MovieId from getAllMovies() or GetMoviesBycategory/getMoviesbyrating call</param>
        /// <returns>connectresult that abstracts the statuscode and data object that holds boolean value</returns>
        [OperationContract]
        ConnectResult GetAvailabilityStatus(int MovieId);

        /// <summary>
        /// Get all movies metdata by category/genre
        /// </summary>
        /// <param name="category/genre"> Genre/Category Enum values of the movie such as Action</param>
        /// <returns>Statuscode and the list of Movie object that has Summary metdata for movies such as description,title,thumbnail, rating, genre, release Year</returns>
        [OperationContract]
        MoviesResult GetMoviesByCategory(CategoryEnum category);

        /// <summary>
        /// Get all movies metdata by MPAA rating 
        /// </summary>
        /// <param name="rating">MPAA rating enum such as G</param>
        /// <returns>Statuscode and the list of Movie object that has Summary metdata for movies such as description,title,thumbnail, rating, genre, release Year</returns>
        [OperationContract]
        MoviesResult GetMoviesByRating(RatingEnum rating);

    }   

   
}
