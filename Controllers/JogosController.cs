using CatalogoDeJogos.Data;
using CatalogoDeJogos.DTOs;
using CatalogoDeJogos.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoDeJogos.Controllers;

[ApiController]
[Route("api/v1/jogos")]
public class JogosController : ControllerBase
{
    private readonly AppDbContext _context;

    public JogosController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/v1/jogos
    [HttpGet]
    public ActionResult<List<Jogo>> GetTodos()
    {
        return Ok(_context.Jogos);
    }

    // GET: api/v1/jogos/1
    [HttpGet("{id:int}")]
    public ActionResult<Jogo> GetPorId(int id)
    {
        var jogo = _context.Jogos.FirstOrDefault(j => j.Id == id);

        if (jogo is null)
            return NotFound($"Jogo com Id {id} não encontrado.");

        return Ok(jogo);
    }

    // POST: api/v1/jogos
    [HttpPost]
    public ActionResult<Jogo> Criar(JogoRequest request)
    {
        var novoId = _context.Jogos.Count == 0
            ? 1
            : _context.Jogos.Max(j => j.Id) + 1;

        var jogo = new Jogo
        {
            Id = novoId,
            Nome = request.Nome,
            Genero = request.Genero,
            Plataforma = request.Plataforma,
            Preco = request.Preco
        };

        _context.Jogos.Add(jogo);

        return CreatedAtAction(
            nameof(GetPorId),
            new { id = jogo.Id },
            jogo);
    }

    // PUT: api/v1/jogos/1
    [HttpPut("{id:int}")]
    public IActionResult Atualizar(int id, JogoRequest request)
    {
        var jogo = _context.Jogos.FirstOrDefault(j => j.Id == id);

        if (jogo is null)
            return NotFound($"Jogo com Id {id} não encontrado.");

        jogo.Nome = request.Nome;
        jogo.Genero = request.Genero;
        jogo.Plataforma = request.Plataforma;
        jogo.Preco = request.Preco;

        return NoContent();
    }

    // DELETE: api/v1/jogos/1
    [HttpDelete("{id:int}")]
    public IActionResult Excluir(int id)
    {
        var jogo = _context.Jogos.FirstOrDefault(j => j.Id == id);

        if (jogo is null)
            return NotFound($"Jogo com Id {id} não encontrado.");

        _context.Jogos.Remove(jogo);

        return NoContent();
    }
}
