using System.ComponentModel.DataAnnotations;

namespace AppleStoreTupinikim.Models
{
    public class Clientes
    {
        //cpf, nome, endereço, e-mail
        [Key]
        public int cpf { get; set; }
        public string nome { get; set; }
        public string endereco { get; set; }
        public string email { get; set; }
    }
}
