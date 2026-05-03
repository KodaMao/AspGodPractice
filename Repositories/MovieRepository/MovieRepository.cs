using AspGodPractice.Models;
using AspGodPractice.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

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
                        movies.Add(SqlHelper.MapObject<Movie>(reader));
                    }
                }
            }

            return movies;
        }

        public Movie GetFilmDetailsById(int id)
        {
            Movie movie = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetFilmDetails", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FilmID", id);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        movie = SqlHelper.MapObject<Movie>(reader);

                        movie.Actors = new List<Actor>();
                        if (reader.NextResult())
                        {
                            while (reader.Read())
                            {
                                var actor = SqlHelper.MapObject<Actor>(reader);
                                movie.Actors.Add(actor);
                            }
                        }
                    }
                }
            }
            return movie;
        }
    }
}