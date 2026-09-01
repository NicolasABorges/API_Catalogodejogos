using CatalogoDeJogos.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new()
    {
        Title = "API do Catálogo de Jogos",
        Version = "v1",
        Description = "API REST para gerenciamento de um catálogo de jogos, com operações CRUD completas."
    });
});

builder.Services.AddSingleton<AppDbContext>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
