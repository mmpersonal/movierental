using MovieRental.DataModel.Connect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TransactionService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ITransactionService
    {
        /// <summary>
        /// Use this API for processing multiple transactions that are added to cart
        /// </summary>
        /// <param name="transactions">MovieRentalTransaction model that has movie Id, payment details ( payment type like CC, cash and the card details)</param>
        /// <returns>List of MovieTransactionResult that has transactionId ,movieId , processedon( when the transaction is processed) and status of the call</returns>
        [OperationContract]
        List<MovieTransactionResult> RentMovies(List<MovieRentalTransaction> transactions);

        /// <summary>
        ///  Process the rent transaction
        /// </summary>
        /// <param name="transaction">MovieRentalTransaction model that has movie Id, payment details ( payment type like CC, cash and the card details)</param>
        /// <returns>MovieTransactionResult that has transactionId, movieId , processedon( when the transaction is processed) and status of the call</returns>
        [OperationContract]
        MovieTransactionResult RentMovie(MovieRentalTransaction transaction);

    }
    
}
