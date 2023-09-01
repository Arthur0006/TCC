using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoMVC.Models
{
    public class MecanicaFotosModel
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Arquivo { get; set; }
        public bool Padrao { get; set; }

        [ForeignKey("Mecanica")]
        public int MecanicaId { get; set; }
        public MecanicaModel? Mecanica { get; set; }

    }
}
