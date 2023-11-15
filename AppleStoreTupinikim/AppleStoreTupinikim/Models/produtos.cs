using System.ComponentModel.DataAnnotations;

namespace AppleStoreTupinikim.Models
{
    public class produtos
    {
        [Key]
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public decimal Valor { get; set; }
        public bool Usado { get; set; }
    }
}
