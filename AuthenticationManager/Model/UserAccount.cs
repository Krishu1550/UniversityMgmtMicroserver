using System.ComponentModel.DataAnnotations;

namespace AuthenticationManager.Model
{
    public class UserAccount
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
