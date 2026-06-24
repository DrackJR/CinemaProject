using CinemaProject.Data;
using CinemaProject.Models;
using CinemaProject;
using Npgsql;
using System;
using System.Collections.Generic;

namespace CinemaProject.Repositories
{
    public class MovieRepository
    {
        private readonly string connectionString = DbConfig.ConnectionString;

        private NpgsqlConnection ConnectionDB()
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            conn.Open();
            return conn;
        }

        public List<Movie> GetAllMovies()
        {
            List<Movie> movies = new List<Movie>();
            using (NpgsqlConnection conn = ConnectionDB())
            {
                string sql = "SELECT id, title, genre, rating, description, video_480p, video_720p, video_1080p, poster_path FROM movies ORDER BY title";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            movies.Add(MapMovie(reader));
                        }
                    }
                }
            }
            return movies;
        }

        public Movie GetMovieById(int id)
        {
            using (NpgsqlConnection conn = ConnectionDB())
            {
                string sql = "SELECT id, title, genre, rating, description, video_480p, video_720p, video_1080p, poster_path FROM movies WHERE id = @id";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) return MapMovie(reader);
                    }
                }
            }
            return null;
        }

        public List<Movie> GetMoviesByGenre(string genre)
        {
            if (string.IsNullOrEmpty(genre) || genre == "Все") return GetAllMovies();
            List<Movie> movies = new List<Movie>();
            using (NpgsqlConnection conn = ConnectionDB())
            {
                string sql = "SELECT id, title, genre, rating, description, video_480p, video_720p, video_1080p, poster_path FROM movies WHERE genre = @genre ORDER BY title";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("genre", genre);
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) movies.Add(MapMovie(reader));
                    }
                }
            }
            return movies;
        }

        public List<Movie> SearchMovies(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm)) return GetAllMovies();
            List<Movie> movies = new List<Movie>();
            using (NpgsqlConnection conn = ConnectionDB())
            {
                string sql = "SELECT id, title, genre, rating, description, video_480p, video_720p, video_1080p, poster_path FROM movies WHERE title ILIKE @query ORDER BY title";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("query", "%" + searchTerm + "%");
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) movies.Add(MapMovie(reader));
                    }
                }
            }
            return movies;
        }

        public void AddMovie(Movie movie)
        {
            using (NpgsqlConnection conn = ConnectionDB())
            {
                string sql = "INSERT INTO movies (title, genre, rating, description, video_480p, video_720p, video_1080p, poster_path) " +
                     "VALUES (@title, @genre, @rating, @desc, @v480, @v720, @v1080, @poster)";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("title", movie.Title);
                    cmd.Parameters.AddWithValue("genre", movie.Genre);
                    cmd.Parameters.AddWithValue("rating", Convert.ToDecimal(movie.Rating));
                    cmd.Parameters.AddWithValue("desc", movie.Description ?? string.Empty);
                    cmd.Parameters.AddWithValue("v480", movie.VideoPath480p ?? string.Empty);
                    cmd.Parameters.AddWithValue("v720", movie.VideoPath720p ?? string.Empty);
                    cmd.Parameters.AddWithValue("v1080", movie.VideoPath1080p ?? string.Empty);
                    cmd.Parameters.AddWithValue("poster", movie.PosterPath ?? string.Empty);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateMovie(Movie movie)
        {
            using (NpgsqlConnection conn = ConnectionDB())
            {
                string sql = @"UPDATE movies 
                       SET title = @title, 
                           genre = @genre, 
                           rating = @rating, 
                           description = @desc, 
                           poster_path = @poster, 
                           video_480p = @v480, 
                           video_720p = @v720, 
                           video_1080p = @v1080 
                       WHERE id = @id";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("id", movie.Id);
                    cmd.Parameters.AddWithValue("title", movie.Title);
                    cmd.Parameters.AddWithValue("genre", movie.Genre);
                    cmd.Parameters.AddWithValue("rating", Convert.ToDecimal(movie.Rating));
                    cmd.Parameters.AddWithValue("desc", movie.Description ?? string.Empty);

                    cmd.Parameters.AddWithValue("poster", movie.PosterPath ?? string.Empty);
                    cmd.Parameters.AddWithValue("v480", movie.VideoPath480p ?? string.Empty);
                    cmd.Parameters.AddWithValue("v720", movie.VideoPath720p ?? string.Empty);
                    cmd.Parameters.AddWithValue("v1080", movie.VideoPath1080p ?? string.Empty);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteMovie(int id)
        {
            using (NpgsqlConnection conn = ConnectionDB())
            {
                string sql = "DELETE FROM movies WHERE id = @id";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static Movie MapMovie(NpgsqlDataReader reader)
        {
            Movie m = new Movie();
            m.Id = reader.GetInt32(0);
            m.Title = reader.GetString(1);
            m.Genre = reader.GetString(2);
            m.Rating = Convert.ToDouble(reader.GetDecimal(3));
            m.Description = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
            m.VideoPath480p = reader.GetString(5);
            m.VideoPath720p = reader.GetString(6);
            m.VideoPath1080p = reader.GetString(7);
            m.PosterPath = reader.GetString(8);
            return m;
        }
    }
}