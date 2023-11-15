using System.ComponentModel.DataAnnotations;

namespace AppleStoreTupinikim.Models
{
    public class Produtos
    {
        //marca, modelo, valor, usado (sim ou não)
        [Key]
        public int IdProduto { get; set; }
        public string modelo { get; set; }
        public float valor {  get; set; }
        public bool usado { get; set; }
    }
}
