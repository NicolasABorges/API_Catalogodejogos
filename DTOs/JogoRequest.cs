using System.ComponentModel.DataAnnotations;

namespace CatalogoDeJogos.DTOs;

public class JogoRequest
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [StringLength(100, MinimumLength = 2)]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "O gênero é obrigatório.")]
    [StringLength(50)]
    public string Genero { get; set; } = string.Empty;

    [Required(ErrorMessage = "A plataforma é obrigatória.")]
    [StringLength(50)]
    public string Plataforma { get; set; } = string.Empty;

    [Range(0, 10000, ErrorMessage = "O preço deve estar entre 0 e 10000.")]
    public decimal Preco { get; set; }
}
