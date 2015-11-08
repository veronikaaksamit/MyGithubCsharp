using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Display(Name="User")]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
