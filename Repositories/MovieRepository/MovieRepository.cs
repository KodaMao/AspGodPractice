using AspGodPractice.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AspGodPractice.Repositories.MovieRepository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["MovieDbConnection"].ConnectionString;

        public List<Movie> GetAllFilms()
        {
            var movies = new List<Movie>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllFilms", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        movies.Add(MapToMovie(reader));
                    }
                }
            }

            return movies;
        }

        /// <summary>
        /// The Translator: Maps raw SQL columns to the C# Movie object properties.
        /// </summary>
        private Movie MapToMovie(SqlDataReader reader)
        {
            return new Movie
            {
                Id = Convert.ToInt32(reader["Id"]),
                Title = reader["Title"]?.ToString(),
                Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : string.Empty,
                ReleaseDate = Convert.ToDateTime(reader["ReleaseDate"]),
                Language = reader["Language"]?.ToString(),
                Runtime = reader["Runtime"] != DBNull.Value ? Convert.ToInt32(reader["Runtime"]) : 0,
                Rating = reader["Rating"]?.ToString(),
                Awards = reader["Awards"] != DBNull.Value ? Convert.ToInt32(reader["Awards"]) : 0,
                Director = reader["Director"]?.ToString(),
                Studio = reader["Studio"]?.ToString(),
                Country = reader["Country"]?.ToString()
            };
        }
    }
}