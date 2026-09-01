namespace CatalogoDeJogos.Models;

public class Jogo
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Genero { get; set; } = string.Empty;
    public string Plataforma { get; set; } = string.Empty;
    public decimal Preco { get; set; }
}
