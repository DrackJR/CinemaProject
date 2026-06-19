using CinemaProject.Repositories;
using CinemaProject.Models;
using System.Collections.Generic;

namespace CinemaProject.Managers
{
    public class MovieManager
    {
        private List<Movie> movies_ = new List<Movie>();
        private readonly MovieRepository _repo = new MovieRepository();

        public List<Movie> GetAllMovies()
        {
            movies_ = _repo.GetAllMovies();
            return movies_;
        }

        public List<Movie> SearchMovies(string query)
        {
            return _repo.SearchMovies(query);
        }

        public List<Movie> FilterByGenre(string genre)
        {
            return _repo.GetMoviesByGenre(genre);
        }

        public void AddMovie(Movie newMovie)
        {
            _repo.AddMovie(newMovie);
        }

        public void UpdateMovie(Movie updatedMovie)
        {
            _repo.UpdateMovie(updatedMovie);
        }

        public void DeleteMovie(int movieId)
        {
            _repo.DeleteMovie(movieId);
        }

        public Movie GetMovieById(int id)
        {
            return _repo.GetMovieById(id);
        }
    }
}