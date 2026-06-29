using System;
using System.Collections.Generic;
using Npgsql;
using CinemaProject.Models;

namespace CinemaProject.Repositories
{
    public class UserRepository
    {
        //private const string connectionString = "Host=192.168.1.48;Username=st53-6;Password=536;Database=cinema_db";
        private readonly string connectionString = "Host=localhost;Port=5432;Database=cinema_db;Username=postgres;Password=123";

        public NpgsqlConnection ConnectionDB()
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            conn.Open();
            return conn;
        }

        public bool TestDB()
        {
            try
            {
                using (NpgsqlConnection conn = ConnectionDB()) { return true; }
            }
            catch { return false; }
        }

        public User Authenticate(string login, string password)
        {
            using (NpgsqlConnection conn = ConnectionDB())
            {
                string sql = "SELECT id, login, password, role FROM users WHERE login = @login AND password = @password";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            User user = new User();
                            user.Id = reader.GetInt32(0);
                            user.Login = reader.GetString(1);
                            user.Password = reader.GetString(2);
                            user.Role = reader.GetString(3);
                            return user;
                        }
                    }
                }
            }
            return null;
        }

        public bool IsLoginExists(string login)
        {
            using (NpgsqlConnection conn = ConnectionDB())
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT COUNT(1) FROM users WHERE login = @login", conn))
                {
                    cmd.Parameters.AddWithValue("@login", login);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public int RegisterUser(string login, string password, string role)
        {
            using (NpgsqlConnection conn = ConnectionDB())
            {
                string sql = "INSERT INTO users (login, password, role) VALUES (@login, @password, @role) RETURNING id;";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@role", role);

                    int newId = Convert.ToInt32(cmd.ExecuteScalar());

                    return newId;
                }
            }
        }

        public List<int> GetUserHistory(int userId)
        {
            List<int> movieIds = new List<int>();

            using (NpgsqlConnection conn = ConnectionDB())
            {
                string sql = "SELECT movie_id FROM history WHERE user_id = @userId ORDER BY id DESC;";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            movieIds.Add(reader.GetInt32(0));
                        }
                    }
                }
            }

            return movieIds;
        }

        public void AddToHistory(int userId, int movieId)
        {
            using (NpgsqlConnection conn = ConnectionDB())
            {
                string sql = "INSERT INTO watch_history (user_id, movie_id) VALUES (@userId, @movieId) ON CONFLICT DO NOTHING";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@movieId", movieId);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public List<Movie> GetPersonalRecommendations(int userId)
        {
            List<Movie> recommendations = new List<Movie>();
            using (NpgsqlConnection conn = ConnectionDB())
            {
                int watchedCount = 0;
                using (NpgsqlCommand checkCmd = new NpgsqlCommand("SELECT COUNT(1) FROM watch_history WHERE user_id = @userId", conn))
                {
                    checkCmd.Parameters.AddWithValue("@userId", userId);
                    watchedCount = Convert.ToInt32(checkCmd.ExecuteScalar());
                }

                if (watchedCount == 0)
                {
                    string sql = "SELECT id, title, genre, rating, description, video_480p, video_720p, video_1080p FROM movies ORDER BY rating DESC LIMIT 10";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        FillMovies(cmd, recommendations);
                    }
                }
                else
                {
                    string favoriteGenre = string.Empty;
                    using (NpgsqlCommand genreCmd = new NpgsqlCommand("SELECT m.genre FROM watch_history wh JOIN movies m ON wh.movie_id = m.id WHERE wh.user_id = @userId GROUP BY m.genre ORDER BY COUNT(m.genre) DESC LIMIT 1", conn))
                    {
                        genreCmd.Parameters.AddWithValue("@userId", userId);
                        object res = genreCmd.ExecuteScalar();
                        if (res != null) favoriteGenre = res.ToString();
                    }

                    if (!string.IsNullOrEmpty(favoriteGenre))
                    {
                        string sql = "SELECT id, title, genre, rating, description, video_480p, video_720p, video_1080p FROM movies WHERE genre = @genre AND id NOT IN (SELECT movie_id FROM watch_history WHERE user_id = @userId) ORDER BY rating DESC LIMIT 5";
                        using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@genre", favoriteGenre);
                            cmd.Parameters.AddWithValue("@userId", userId);
                            FillMovies(cmd, recommendations);
                        }
                    }

                    if (recommendations.Count < 5)
                    {
                        int needed = 5 - recommendations.Count;
                        string extraSql = "SELECT id, title, genre, rating, description, video_480p, video_720p, video_1080p FROM movies WHERE id NOT IN (SELECT movie_id FROM watch_history WHERE user_id = @userId) ";
                        if (recommendations.Count > 0)
                        {
                            List<string> ids = new List<string>();
                            foreach (Movie m in recommendations) ids.Add(m.Id.ToString());
                            extraSql += "AND id NOT IN (" + string.Join(",", ids) + ") ";
                        }
                        extraSql += "ORDER BY rating DESC LIMIT @limit";

                        using (NpgsqlCommand extraCmd = new NpgsqlCommand(extraSql, conn))
                        {
                            extraCmd.Parameters.AddWithValue("@userId", userId);
                            extraCmd.Parameters.AddWithValue("@limit", needed);
                            FillMovies(extraCmd, recommendations);
                        }
                    }
                }
            }
            return recommendations;
        }
        public void SaveMovieToHistory(int userId, int movieId)
        {
            using (NpgsqlConnection conn = ConnectionDB())
            {
                string sql = "INSERT INTO history (user_id, movie_id) VALUES (@userId, @movieId);";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@movieId", movieId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static void FillMovies(NpgsqlCommand cmd, List<Movie> list)
        {
            using (NpgsqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
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
                    list.Add(m);
                }
            }
        }
    }
}