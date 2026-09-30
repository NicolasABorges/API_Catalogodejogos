using System.ComponentModel.DataAnnotations;

namespace CatalogoDeJogos.Models;

public class Jogo
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Nome { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string Genero { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string Plataforma { get; set; } = string.Empty;

    public decimal Preco { get; set; }
}
