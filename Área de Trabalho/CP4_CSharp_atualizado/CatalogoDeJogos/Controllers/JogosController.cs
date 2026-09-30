using CatalogoDeJogos.Data;
using CatalogoDeJogos.DTOs;
using CatalogoDeJogos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    public async Task<ActionResult<List<Jogo>>> GetTodos()
    {
        var jogos = await _context.Jogos.AsNoTracking().ToListAsync();
        return Ok(jogos);
    }

    // GET: api/v1/jogos/1
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Jogo>> GetPorId(int id)
    {
        var jogo = await _context.Jogos.AsNoTracking().FirstOrDefaultAsync(j => j.Id == id);

        if (jogo is null)
            return NotFound(new { mensagem = $"Jogo com Id {id} não encontrado." });

        return Ok(jogo);
    }

    // POST: api/v1/jogos
    [HttpPost]
    public async Task<ActionResult<Jogo>> Criar(JogoRequest request)
    {
        var jogo = new Jogo
        {
            Nome = request.Nome,
            Genero = request.Genero,
            Plataforma = request.Plataforma,
            Preco = request.Preco
        };

        _context.Jogos.Add(jogo);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPorId), new { id = jogo.Id }, jogo);
    }

    // PUT: api/v1/jogos/1
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Atualizar(int id, JogoRequest request)
    {
        var jogo = await _context.Jogos.FirstOrDefaultAsync(j => j.Id == id);

        if (jogo is null)
            return NotFound(new { mensagem = $"Jogo com Id {id} não encontrado." });

        jogo.Nome = request.Nome;
        jogo.Genero = request.Genero;
        jogo.Plataforma = request.Plataforma;
        jogo.Preco = request.Preco;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/v1/jogos/1
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Excluir(int id)
    {
        var jogo = await _context.Jogos.FirstOrDefaultAsync(j => j.Id == id);

        if (jogo is null)
            return NotFound(new { mensagem = $"Jogo com Id {id} não encontrado." });

        _context.Jogos.Remove(jogo);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
