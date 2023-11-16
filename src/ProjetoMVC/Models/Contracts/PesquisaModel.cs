using System.ComponentModel;

namespace ProjetoMVC.Models.Contracts
{
    public class PesquisaModel
    {
        [DisplayName("Marca")]
        public int MarcaId { get; set; }
        [DisplayName("Modelo")]
        public int ModeloId { get; set; }
        public string Pergunta { get; set; }
        public string? Resposta { get; set; }
    }
}
