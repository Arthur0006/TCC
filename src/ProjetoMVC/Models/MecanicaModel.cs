using ProjetoMVC.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoMVC.Models
{
    public class MecanicaModel
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "O campo {0} deve ter um tamanho máximo de {1} caracteres")]
        public string Nome { get; set; }
        [MaxLength(70, ErrorMessage = "O campo {0} deve ter um tamanho máximo de {1} caracteres")]
        public string Email { get; set; }
        [MaxLength(20, ErrorMessage = "O campo {0} deve ter um tamanho máximo de {1} caracteres")]
        public string Senha { get; set; }
        public string Cidade { get; set; }
        public string Telefone { get; set; }
        public string Tipo { get; set; }
        [MaxLength(08, ErrorMessage = "O campo {0} deve ter um tamanho máximo de {1} caracteres")]
        public string Cep { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string? Imagem { get; set; }
        [MaxLength(150, ErrorMessage = "O campo {0} deve ter um tamanho máximo de {1} caracteres")]
        public string Descricao { get; set; }

        [ForeignKey("Usuario")]
        public string UsuarioId { get; set; }
        public UsuarioModel? Usuario { get; set; }  

        public ICollection<MecanicaFotosModel>? Fotos { get; set; }
    }
}
