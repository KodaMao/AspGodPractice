using System.Collections.Generic;

namespace AspGodPractice.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public List<UserLikedMovies> LikedMovies { get; set; } = new List<UserLikedMovies>();
    }
}