using System.Collections.Generic;

namespace CinemaProject.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public List<int> History { get; set; }
        public string Role { get; set; }

        public User()
        {
            Login = string.Empty;
            Password = string.Empty;
            History = new List<int>();
            Role = "User";
        }
    }
}