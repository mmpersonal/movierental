using MovieRental.DataModel.Connect;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SearchService
{
    
    [ServiceContract]
    public interface ISearchService
    {
        /// <summary>
        /// Returns list of Movies matched the given search terms
        /// </summary>
        /// <param name="movieRentalSearchModel"></param>
        /// <returns>List of movies matched the search term</returns>
        [OperationContract]
        List<MovieSummary> MovieSearch(MovieRentalSearchModel movieRentalSearchModel);
    }


    
}
