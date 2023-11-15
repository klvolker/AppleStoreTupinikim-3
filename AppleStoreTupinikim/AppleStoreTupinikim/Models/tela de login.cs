using System.ComponentModel.DataAnnotations;

namespace AppleStoreTupinikim.Models
{
    public class tela_de_login
    {
        [Key]
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
    }
}
