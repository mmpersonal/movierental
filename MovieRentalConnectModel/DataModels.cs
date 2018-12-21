using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

/// <summary>
/// DataModel for Web Service APIs
/// </summary>
namespace MovieRental.DataModel.Connect
{
    /// <summary>
    /// Status Code as Enum Values
    /// </summary>
    [DataContract]
    public enum ConnectStatusCode
    {
        /// <summary>
        /// The api call is successful.
        /// </summary>
        [EnumMember]
        Success = 0,

        /// <summary>
        /// The api call is not authorized (wrong username/password)
        /// </summary>
        [EnumMember]
        Unauthorized = 1,

        /// <summary>
        /// An error occurred because of client's input.
        /// </summary>
        [EnumMember]
        ClientError = 2,

        /// <summary>
        /// An error occurred because of something in the server.
        /// </summary>
        [EnumMember]
        ServerError = 3
    }

    /// <summary>
    /// Language of the Movie as a metadata , ISO-639-1
    /// </summary>
    [DataContract]
    public enum LanguageEnum
    {
        //TODO: Still need add other languages
        [EnumMember]
        En = 0,
        [EnumMember]
        FR = 1,
        [EnumMember]
        ar = 2,
        [EnumMember]
        hy = 3,
        [EnumMember]
        zh = 4,
        [EnumMember]
        da = 5,
        [EnumMember]
        cs = 6,
        [EnumMember]
        eo = 7,
        [EnumMember]
        ka = 8,
        [EnumMember]
        de = 9,
        [EnumMember]
        el = 10,
        [EnumMember]
        it = 11,
        [EnumMember]
        ja = 12,
        [EnumMember]
        ko = 13,
        [EnumMember]
        ms = 14,
        [EnumMember]
        ku = 15,
        [EnumMember]
        fa = 16,
        [EnumMember]
        pt = 17,
        [EnumMember]
        ro = 18
    }
    /// <summary>
    /// Category/genre of the Movie  
    /// </summary>
    [DataContract]
    public enum CategoryEnum
    {
        //TODO: need to have this complete and match with lookup table in SQL Server
        [EnumMember]
        Comedy = 0,
        [EnumMember]
        SciFi = 1,
        [EnumMember]
        Horror = 2,
        [EnumMember]
        Action = 3,
        [EnumMember]
        Thriller = 4,
        [EnumMember]
        Romance = 5,
        [EnumMember]
        Family = 6
    }

    /// <summary>
    /// MPAA rating of the Movie  
    /// </summary>
    [DataContract]
    public enum RatingEnum
    {
        //TODO: need to have this complete and match with lookup table in SQL Server
        [EnumMember]
        G = 0,
        [EnumMember]
        PG = 1,
        [EnumMember]
        PG13 = 2,
        [EnumMember]
        R = 3,
        [EnumMember]
        NC17 = 4,
    }

    /// <summary>
    /// Person role in the movie ( Actor , producer etc) 
    /// </summary>
    [DataContract]
    public enum MoviePersonRoleEnum
    {
        //TODO: need to have this complete and match with lookup table in SQL Server
        [EnumMember]
        Actor = 0,
        [EnumMember]
        Director = 1,
        [EnumMember]
        Producer = 2,
        [EnumMember]
        StoryWriter = 3,
        [EnumMember]
        MusicDirector = 4,
    }
    /// <summary>
    /// Payment Type to be specifiied for supported payment type 
    /// </summary>
    [DataContract]
    public enum PaymentTypeEnum
    {
        //TODO: need to have this complete and match with lookup table in SQL Server
        [EnumMember]
        CreditCard = 0,
        [EnumMember]
        DebitCard = 1,
        [EnumMember]
        Cash = 2,
        [EnumMember]
        ACH = 3        
    }

    [DataContract]
    public class MovieSummary
    {
        [DataMember]
        public long MovieId { get; set; }
        [DataMember]
        public LanguageEnum Language { get; set; }
        [DataMember]
        public CategoryEnum Category { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public short? ReleaseYear { get; set; }
        [DataMember]
        public short? rental_duration { get; set; }
        [DataMember]
        public decimal? rental_rate { get; set; }
        [DataMember]
        public short? Length { get; set; }
        [DataMember]
        public RatingEnum Rating { get; set; }
        [DataMember]
        public string Summary { get; set; }
        [DataMember]
        public bool IsAvailable { get; set; }

    }

    [DataContract]
    public class MovieRentalSearchModel
    {        
        [DataMember]
        public CategoryEnum Category { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public short? ReleaseYear { get; set; }
        [DataMember]
        public short? rental_duration { get; set; }
        [DataMember]
        public decimal? rental_rate { get; set; }
        [DataMember]
        public short? Length { get; set; }
        [DataMember]
        public RatingEnum Rating { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string NickName { get; set; }


    }
    [DataContract]
    public class PersonDetails
    {
        [DataMember]
        public int PersonId { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string NickName { get; set; }
        [DataMember]
        public MoviePersonRoleEnum Role { get; set; }

    }
    [DataContract]
    public class MoviePersonDetails
    {
        [DataMember]
        public MovieSummary movie { get; set; }
        [DataMember]
        public List<PersonDetails> persons { get; set; }

    }
    
    
    [DataContract]
    public class PaymentDetails
    {
        [DataMember]
        public decimal PaymentAmt { get; set; }
        [DataMember]
        public PaymentTypeEnum paymentType { get; set; }

    }
    [DataContract]
    public class MovieRentalTransaction
    {
        [DataMember]
        public int movieId { get; set; }
        [DataMember]
        public PaymentDetails payment { get; set; }

    }

    [DataContract]
    public class MovieTransactionResult : ConnectResult
    {
        public MovieTransactionResult(ConnectStatusCode statusCode)
            : base(statusCode)
        {
            this.ProcessedOn = System.DateTime.Now;
        }
        [DataMember]
        public int TransactionId { get; set; }
        [DataMember]
        public long MovieId { get; set; }
        [DataMember]
        public DateTime ProcessedOn { get; set; }

    }
    [DataContract]
    public class MovieSubmissionResult : ConnectResult
    {
        public MovieSubmissionResult(ConnectStatusCode statusCode)
            : base(statusCode)
        {
            this.ProcessedOn = System.DateTime.Now;
        }
        public MovieSubmissionResult() : base(ConnectStatusCode.Success)
        {
            this.ProcessedOn = System.DateTime.Now;            
        }
        public MovieSubmissionResult(Exception ex) : base(ex)
        {

        }
        [DataMember]
        public DateTime ProcessedOn { get; set; }

        [DataMember]
        public long MovieId { get; set; }
       
    }
    [DataContract]
    public class MoviesResult : ConnectResult
    {
        public MoviesResult() : base(ConnectStatusCode.Success)
        {
            
        }
        public MoviesResult(Exception ex) : base(ex)
        {

        }
        [DataMember]
        public List<MovieSummary> movies { get; set; }
    }
}
