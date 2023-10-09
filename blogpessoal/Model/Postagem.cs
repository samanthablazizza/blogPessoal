using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Newtonsoft.Json;

namespace blogpessoal.Model
{
    public class Postagem : Auditable
    {
        [Key] // Chave Primária (Id)
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // IDENTITY (1,1)
        public long Id { get; set; }

        [Column(TypeName = "varchar")] //SQL não lê string, então é preciso converter para varchar
        [StringLength(100)]
        public string Titulo { get; set; } = string.Empty;

        [Column(TypeName = "varchar")]
        [StringLength(1000)]
        public string Texto {  get; set; } = string.Empty;
        public virtual Tema? Tema { get; set; }
        public virtual User? Usuario { get; set; }
    }
}
