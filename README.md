# API Catálogo de Jogos

API REST feita em ASP.NET Core (.NET 10) para gerenciar um catálogo de jogos. Permite cadastrar, listar, buscar, atualizar e remover jogos. Os dados ficam salvos em memória (sem banco de dados).

## Integrantes

Nicolas Borges - RM556617
Gustavo Atanazio - RM559098
Gustavo Coelho - RM556289
Dayana Quispe - RM558023
Matheus Vinícius - RM555177

## Como rodar

```bash
git clone https://github.com/NicolasABorges/API_Catalogodejogos.git
cd CatalogoDeJogos
dotnet restore
dotnet run
```

Depois acesse: `http://localhost:5000/swagger`

## Endpoints

| Método | Rota | Descrição |
| GET | /api/v1/jogos | lista todos os jogos |
| GET | /api/v1/jogos/{id} | busca um jogo pelo id |
| POST | /api/v1/jogos | cria um jogo |
| PUT | /api/v1/jogos/{id} | atualiza um jogo |
| DELETE | /api/v1/jogos/{id} | remove um jogo |

### Exemplo de criação (POST)

```json
{
  "nome": "Elden Ring",
  "genero": "RPG",
  "plataforma": "PC",
  "preco": 249.90
}
```

## Testes no Swagger

 ### GET - listar todos ![GET listar](prints/get-listar.png) 
 ### POST - criar jogo ![POST criar](prints/post-criar.png) 
 ### GET - buscar por id ![GET por id](prints/get-id.png) 
 ### PUT - atualizar jogo ![PUT atualizar](prints/put-atualizar.png) 
 ### DELETE - remover jogo ![DELETE](prints/delete.png) 
 ### GET - confirmando 404 após delete ![GET 404](prints/get-404.png)

## Tecnologias

ASP.NET Core (.NET 10), Swashbuckle/Swagger, C#
