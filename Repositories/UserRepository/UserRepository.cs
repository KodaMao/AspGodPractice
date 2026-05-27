using AspGodPractice.Models;
using AspGodPractice.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace AspGodPractice.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["MovieDbConnection"].ConnectionString;

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllUsers", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var user = new User()
                        {
                            Id = Convert.ToInt32(reader["ID"]),
                            Username = reader["Username"] != DBNull.Value ? reader["Username"].ToString() : string.Empty,
                            Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : string.Empty,
                        };

                        users.Add(user);
                    }
                }
            }
            return users;
        }
        public User CreateUser(CreateUserDto user)
        {
            User newUser = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("spCreateUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Email", user.Email);

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        newUser = SqlHelper.MapObject<User>(reader);
                    }
                }
            }
            return newUser;
        }

        public User GetUserDetailsById(int id)
        {
            User user = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetUserDetails", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", id);

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user = new User()
                        {
                            Id = Convert.ToInt32(reader["ID"]),
                            Username = reader["Username"] != DBNull.Value ? reader["Username"].ToString() : string.Empty,
                            Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : string.Empty,
                        };

            
                    }
                }
            }
            return user;
        }
    }
}