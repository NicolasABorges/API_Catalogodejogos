using CatalogoDeJogos.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddProblemDetails();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new()
    {
        Title = "API do Catálogo de Jogos",
        Version = "v1",
        Description = "API REST para gerenciamento de um catálogo de jogos, com operações CRUD completas."
    });
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Aplica as migrations automaticamente (cria o catalogo.db na primeira execução)
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.Migrate();
}

// Tratamento global de erros inesperados (retorna 500 em formato ProblemDetails)
app.UseExceptionHandler();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
