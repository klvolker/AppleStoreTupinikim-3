using System.ComponentModel.DataAnnotations;

namespace AppleStoreTupinikim.Models
{
    public class Vendedores
    {
        //razão social, CNPJ, e-mail, site e telefone
        public string razaoSocial { get; set; }
        [Key]
        public string cnpj {  get; set; }
        public string email { get; set; }
        public string site { get; set; }
        public int telefone { get; set; }
    }
}
