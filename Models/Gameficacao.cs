namespace GamificacaoApp.Models
{
    public class Gameficacao
    {
        public int Id { get; set; }
        public int FuncionarioId { get; set; }
        public int ProjetoId { get; set; }
        public string Fase { get; set; }
        public DateTime Data { get; set; }
        public int Pontos { get; set; }
    }
}