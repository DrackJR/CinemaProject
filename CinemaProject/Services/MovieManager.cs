using CinemaProject.Repositories;
using CinemaProject.Models;
using System.Collections.Generic;

namespace CinemaProject.Managers
{
    public class MovieManager
    {
        private List<Movie> movies_ = new List<Movie>();
        private readonly MovieRepository repo_ = new MovieRepository();

        public List<Movie> GetAllMovies()
        {
            movies_ = repo_.GetAllMovies();
            return movies_;
        }

        public List<Movie> SearchMovies(string query)
        {
            return repo_.SearchMovies(query);
        }

        public List<Movie> FilterByGenre(string genre)
        {
            return repo_.GetMoviesByGenre(genre);
        }

        public void AddMovie(Movie newMovie)
        {
            repo_.AddMovie(newMovie);
        }

        public void UpdateMovie(Movie updatedMovie)
        {
            repo_.UpdateMovie(updatedMovie);
        }

        public void DeleteMovie(int movieId)
        {
            repo_.DeleteMovie(movieId);
        }

        public Movie GetMovieById(int id)
        {
            return repo_.GetMovieById(id);
        }
    }
}