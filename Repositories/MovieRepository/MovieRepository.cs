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
                        var movie = new Movie()
                        {
                            Id = Convert.ToInt32(reader["ID"]),
                            Title = reader["Title"] != DBNull.Value ? reader["Title"].ToString() : string.Empty,
                            Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : string.Empty,
                            ReleaseDate = reader["ReleaseDate"] != DBNull.Value ? Convert.ToDateTime(reader["ReleaseDate"]) : DateTime.MinValue,
                            Language = reader["Language"] != DBNull.Value ? reader["Language"].ToString() : string.Empty,
                            Runtime = reader["Runtime"] != DBNull.Value ? Convert.ToInt32(reader["Runtime"]) : 0,
                            Rating = reader["Rating"] != DBNull.Value ? reader["Rating"].ToString() : string.Empty,
                            Awards = reader["Awards"] != DBNull.Value ? Convert.ToInt32(reader["Awards"]) : 0,
                            Director = reader["Director"] != DBNull.Value ? reader["Director"].ToString() : string.Empty,
                            Studio = reader["Studio"] != DBNull.Value ? reader["Studio"].ToString() : string.Empty,
                            Country = reader["Country"] != DBNull.Value ? reader["Country"].ToString() : string.Empty
                        };

                        movies.Add(movie);
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
                        movie = new Movie()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Title = reader["Title"] != DBNull.Value ? reader["Title"].ToString() : string.Empty,
                            Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : string.Empty,
                            ReleaseDate = reader["ReleaseDate"] != DBNull.Value ? Convert.ToDateTime(reader["ReleaseDate"]) : DateTime.MinValue,
                            Language = reader["Language"] != DBNull.Value ? reader["Language"].ToString() : string.Empty,
                            Runtime = reader["Runtime"] != DBNull.Value ? Convert.ToInt32(reader["Runtime"]) : 0,
                            Budget = reader["Budget"] != DBNull.Value ? Convert.ToInt32(reader["Budget"]) : 0,
                            Gross = reader["Gross"] != DBNull.Value ? Convert.ToInt32(reader["Gross"]) : 0,
                            Rating = reader["Rating"] != DBNull.Value ? reader["Rating"].ToString() : string.Empty,
                            Nominations = reader["Nominations"] != DBNull.Value ? Convert.ToInt32(reader["Nominations"]) : 0,
                            Awards = reader["Awards"] != DBNull.Value ? Convert.ToInt32(reader["Awards"]) : 0,
                            Director = reader["Director"] != DBNull.Value ? reader["Director"].ToString() : string.Empty,
                            DirectorBirthDay = reader["DirectorBirthDay"] != DBNull.Value ? Convert.ToDateTime(reader["DirectorBirthDay"]) : DateTime.MinValue,
                            DirectorGender = reader["DirectorGender"] != DBNull.Value ? reader["DirectorGender"].ToString() : string.Empty,
                            Studio = reader["Studio"] != DBNull.Value ? reader["Studio"].ToString() : string.Empty,
                            Country = reader["Country"] != DBNull.Value ? reader["Country"].ToString() : string.Empty,

                            Actors = new List<Actor>()
                        };
                    }

                    if (movie != null && reader.NextResult())
                    {
                        while (reader.Read())
                        {
                            var actor = new Actor()
                            {
                                Id = Convert.ToInt32(reader["ID"]),
                                Name = reader["Name"] != DBNull.Value ? reader["Name"].ToString() : string.Empty,
                                Birthdate = reader["Birthdate"] != DBNull.Value ? Convert.ToDateTime(reader["Birthdate"]) : DateTime.MinValue,
                                Gender = reader["Gender"] != DBNull.Value ? reader["Gender"].ToString() : string.Empty,
                                Character = reader["Character"] != DBNull.Value ? reader["Character"].ToString() : string.Empty
                            };

                            movie.Actors.Add(actor);
                        }
                    }
                }
            }

            return movie;
        }
    }
}