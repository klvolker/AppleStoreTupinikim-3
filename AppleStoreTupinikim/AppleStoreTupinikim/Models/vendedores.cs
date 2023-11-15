using System.ComponentModel.DataAnnotations;

namespace AppleStoreTupinikim.Models
{
    public class vendedores
    {
        [Key]
        public int Id { get; private set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string Email { get; set; }
        public string Site { get; set; }
        public string Telefone { get; set; }
    }
}
