namespace GamificacaoApp.Models
{
    public class Pontuacao
    {
        public int Id { get; set; }
        public int ProjetoId { get; set; }
        public string Fase { get; set; }
        public int Pontos { get; set; }
    }
}