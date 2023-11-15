using System.ComponentModel.DataAnnotations;

namespace AppleStoreTupinikim.Models
{
    public class Login
    {
        [Key]
        public int Id { get; set; }
        public string nomeUsuario { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
    }
}
