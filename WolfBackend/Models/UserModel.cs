using System.ComponentModel.DataAnnotations;

namespace WolfGame.Model
{
    public class UserModel
    {
        [Key]
        public string Account { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Name { get; set; } = null!;
    }
}
