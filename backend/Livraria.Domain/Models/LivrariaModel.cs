using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Livraria.Domain.Models
{
    [Table("livro")]
    public class LivrariaModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("titulo")]
        public string Titulo { get; set; }

        [Column("autor")]
        public string Autor { get; set; }

        [Column("status")]
        public bool Status { get; set; }
    }
}

