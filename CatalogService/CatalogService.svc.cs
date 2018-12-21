using MovieRental.DataModel.Connect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MovieRental;
using MovieRentalRepository;
using MovieRentalModel;

namespace MovieRental.API
{
    /// <summary>
    /// Supports Servies for Movie Catalog that can be used to build Discovery experience of movies for consumer before renting
    /// Browse Movies by Genre, rating , availability to rent 
    /// </summary>
    
    public class CatalogService : ICatalogService
    {
        /// <summary>
        /// Gets summary data for all movies that are available to rent from the catalog/inventory
        /// </summary>
        /// <returns>Summary metdata for movies such as description,title,thumbnail, rating, genre, release Year</returns>
        [OperationContract]
        public MoviesResult GetAvailableMovies()
        {
            //data set would be large as the business grows, TODO: this should be limited to number that can be displayed in a page such as 20 
            //perhaps based on availability and as well rating / popularity once we have the data available to determine what criteria can be used best
            //to filter top x movies   
            try
            {
                List<MovieSummary> movieSummaries = new List<MovieSummary>();
                MoviesResult result = new MoviesResult();
                using (var context = new MRRepositoryFactory(new MovieRentalEntityContext()))
                {
                    var movies = context.Movies.GetAllAvailableMovies();
                    if (movies != null && movies.Count > 0)
                    {
                        foreach (Movie movie in movies)
                        {
                            MovieSummary movieSummary = new MovieSummary();
                            movieSummary.Description = movie.Description;
                            movieSummary.IsAvailable = true;
                            movieSummary.Length = movie.Length;
                            movieSummary.ReleaseYear = movie.ReleaseYear;
                            movieSummary.rental_duration = movie.rental_duaration;
                            movieSummary.rental_rate = movie.rental_rate;
                            movieSummary.Summary = movie.Summary;
                            movieSummary.Title = movie.Title;
                            movieSummary.MovieId = movie.MovieId;
                            movieSummary.Category = (CategoryEnum)movie.CategoryId;
                            movieSummary.Language = (LanguageEnum)movie.LanguageId;
                            movieSummary.Rating = (RatingEnum)movie.RatingId;
                            movieSummaries.Add(movieSummary);
                        }
                    }
                }
                result.movies = movieSummaries;
                return result;
                
            }catch(Exception ex)
            {
                return new MoviesResult(ex);
            }
        }

        [OperationContract]
        public MoviesResult GetAllMovies()
        {
            //TODO: not sure how much this call will be useful. Perhaps this should be deprecated
            //and same thoughts as Getallavailablemovies() to limit the payload size for improving the performance
            //
            try
            {
                List<MovieSummary> movieSummaries = new List<MovieSummary>();
                MoviesResult result = new MoviesResult();
                using (var context = new MRRepositoryFactory(new MovieRentalEntityContext()))
                {
                    var movies = context.Movies.GetAll().ToList();
                    if (movies != null && movies.Count > 0)
                    {
                        foreach (Movie movie in movies)
                        {
                            MovieSummary movieSummary = new MovieSummary();
                            movieSummary.Description = movie.Description;
                            movieSummary.IsAvailable = true;
                            movieSummary.Length = movie.Length;
                            movieSummary.ReleaseYear = movie.ReleaseYear;
                            movieSummary.rental_duration = movie.rental_duaration;
                            movieSummary.rental_rate = movie.rental_rate;
                            movieSummary.Summary = movie.Summary;
                            movieSummary.Title = movie.Title;
                            movieSummary.MovieId = movie.MovieId;
                            movieSummary.Category = (CategoryEnum)movie.CategoryId;
                            movieSummary.Language = (LanguageEnum)movie.LanguageId;
                            movieSummary.Rating = (RatingEnum)movie.RatingId;
                            movieSummaries.Add(movieSummary);
                        }
                    }
                }
                result.movies = movieSummaries;
                return result;

            }
            catch (Exception ex)
            {
                return new MoviesResult(ex);
            }
        }

        [OperationContract]
        public MovieSubmissionResult SubmitMovie(MoviePersonDetails moviePersonDetails)
        {
            //TODO: insert update should be moved to Movie repository like. if primarykey value is zero , update it and if not add it
            try
            {
                MovieSubmissionResult result = new MovieSubmissionResult();
                #region input validation
                if (moviePersonDetails == null)
                {
                    return new MovieSubmissionResult(ConnectStatusCode.ClientError);

                }
                //atleast movie details need to be present when Submitting movie to the catalog
                if (moviePersonDetails.movie == null)
                {
                    return new MovieSubmissionResult(ConnectStatusCode.ClientError);
                }
                if (string.IsNullOrEmpty(moviePersonDetails.movie.Title))
                {
                    return new MovieSubmissionResult(ConnectStatusCode.ClientError);
                }
                #endregion

                using (var context = new MRRepositoryFactory(new MovieRentalEntityContext()))
                {
                    //first add movie details to Movie table

                    Movie movie = new Movie();
                    MovieSummary movieDetails = moviePersonDetails.movie;
                    movie.CategoryId = (int)movieDetails.Category;
                    movie.CreatedBy = -1; //TODO: should be logged in user Id 
                    movie.CreatedOn = DateTime.Now;
                    movie.Description = movieDetails.Description.Trim();
                    movie.LanguageId = (int)movieDetails.Language;
                    movie.Length = movieDetails.Length;
                    movie.RatingId = (int)movieDetails.Rating;
                    movie.ReleaseYear = movieDetails.ReleaseYear;
                    movie.rental_duaration = movieDetails.rental_duration;
                    movie.rental_rate = movieDetails.rental_rate;
                    movie.Summary = movieDetails.Summary.Trim();
                    movie.Title = movieDetails.Title.Trim();
                    movie.UpdatedBy = -1;
                    movie.UpdatedOn = DateTime.Now;
                    context.Movies.Add(movie);
                    MoviePerson movieperson = new MoviePerson();
                    movieperson.MovieId = movie.MovieId;
                    //Add person details to Person table
                    if (moviePersonDetails.persons != null)
                    {
                        var persons = moviePersonDetails.persons;
                        if (persons.Count > 0)
                        {
                            foreach (PersonDetails personinfo in persons)
                            {
                                if (personinfo != null)
                                {
                                    Person person = new Person();
                                    person.FirstName = personinfo.FirstName;
                                    person.LasttName = personinfo.LastName;
                                    person.RoleId = (int)personinfo.Role;
                                    context.persons.Add(person);
                                    movieperson.PersonId = person.PersonId;
                                    //add association of persons to movie
                                    context.moviePersons.Add(movieperson);
                                }

                            }

                        }
                    }

                    context.Complete();
                    result.MovieId = movie.MovieId;
                    return result;

                }
            }catch(Exception ex)
            {
                return new MovieSubmissionResult(ex);
            }
            
        }


        [OperationContract]
        public MovieSubmissionResult UpdateMovie(MoviePersonDetails moviePersonDetails)
        {
            //TODO: insert update should be moved to Movie repository like. if primarykey value is zero , update it and if not add it
            //This is duplicate code and by doing above refactor, duplicate code issue will be taken care of.
            try
            {
                MovieSubmissionResult result = new MovieSubmissionResult();
                #region input validation
                if (moviePersonDetails == null)
                {
                    return new MovieSubmissionResult(ConnectStatusCode.ClientError);

                }
                //atleast movie details need to be present when Submitting movie to the catalog
                if (moviePersonDetails.movie == null)
                {
                    return new MovieSubmissionResult(ConnectStatusCode.ClientError);
                }
                if (moviePersonDetails.movie.MovieId == 0)
                {
                    return new MovieSubmissionResult(ConnectStatusCode.ClientError);
                }
                if (string.IsNullOrEmpty(moviePersonDetails.movie.Title))
                {
                    return new MovieSubmissionResult(ConnectStatusCode.ClientError);
                }
                #endregion

                using (var context = new MRRepositoryFactory(new MovieRentalEntityContext()))
                {
                    //Get the Movie from DB and update the values if it exists already

                    Movie movie = context.Movies.GetMovieByID(moviePersonDetails.movie.MovieId);
                    if(movie == null)
                        return new MovieSubmissionResult(ConnectStatusCode.ClientError);
                    
                    MovieSummary movieDetails = moviePersonDetails.movie;
                    movie.CategoryId = (int)movieDetails.Category;
                    movie.CreatedBy = -1; //TODO: should be logged in user Id 
                    movie.CreatedOn = DateTime.Now;
                    movie.Description = movieDetails.Description.Trim();
                    movie.LanguageId = (int)movieDetails.Language;
                    movie.Length = movieDetails.Length;
                    movie.RatingId = (int)movieDetails.Rating;
                    movie.ReleaseYear = movieDetails.ReleaseYear;
                    movie.rental_duaration = movieDetails.rental_duration;
                    movie.rental_rate = movieDetails.rental_rate;
                    movie.Summary = movieDetails.Summary.Trim();
                    movie.Title = movieDetails.Title.Trim();
                    movie.UpdatedBy = -1;
                    movie.UpdatedOn = DateTime.Now;
                    context.Movies.Update(movie);
                    MoviePerson movieperson = new MoviePerson();
                    movieperson.MovieId = movie.MovieId;
                    //Update person details to Person table
                    if (moviePersonDetails.persons != null)
                    {
                        var persons = moviePersonDetails.persons;
                        if (persons.Count > 0)
                        {
                            foreach (PersonDetails personinfo in persons)
                            {
                                if (personinfo != null )
                                {
                                    Person person = context.persons.GetByID(personinfo.PersonId);
                                    if (person != null)
                                    {
                                        person.FirstName = personinfo.FirstName;
                                        person.LasttName = personinfo.LastName;
                                        person.RoleId = (int)personinfo.Role;
                                        context.persons.Update(person);
                                        movieperson.PersonId = person.PersonId;
                                        //add association of persons to movie
                                        context.moviePersons.Update(movieperson);
                                    }
                                }

                            }

                        }
                    }

                    context.Complete();
                    result.MovieId = movie.MovieId;
                    return result;

                }
            }
            catch (Exception ex)
            {
                return new MovieSubmissionResult(ex);
            }

        }

        [OperationContract]
        public MovieSubmissionResult RemoveMovie(int MovieId)
        {
            throw new NotImplementedException();
        }

        [OperationContract]
        public ConnectResult GetAvailabilityStatus(int MovieId)
        {
            throw new NotImplementedException();
        }
    }
}
