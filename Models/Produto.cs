using System.ComponentModel.DataAnnotations.Schema;


namespace eCommerceCrud.Models
{
    [Table("produto")]
    public class Produto
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }
        public bool Status { get; set; }
    }

}