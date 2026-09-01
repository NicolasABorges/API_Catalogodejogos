using CatalogoDeJogos.Models;

namespace CatalogoDeJogos.Data;

public class AppDbContext
{
    public List<Jogo> Jogos { get; set; } = new()
    {
        new Jogo
        {
            Id = 1,
            Nome = "Minecraft",
            Genero = "Sandbox",
            Plataforma = "PC",
            Preco = 99.90m
        },
        new Jogo
        {
            Id = 2,
            Nome = "Marvel Rivals",
            Genero = "Ação",
            Plataforma = "PC",
            Preco = 0m
        },
        new Jogo
        {
            Id = 3,
            Nome = "The Witcher 3",
            Genero = "RPG",
            Plataforma = "PC",
            Preco = 149.90m
        }
    };
}
