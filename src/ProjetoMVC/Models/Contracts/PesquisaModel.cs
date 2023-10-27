namespace ProjetoMVC.Models.Contracts
{
    public class PesquisaModel
    {
        public int MarcaId { get; set; }
        public int ModeloId { get; set; }
        public string Pergunta { get; set; }
        public string? Resposta { get; set; }
    }
}
