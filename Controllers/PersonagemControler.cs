using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xablau.Controllers.Data;
using Xablau.Models;


namespace Xablau.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonagemControler : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public PersonagemControler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
            public async Task<IActionResult> AddPersonagem([FromBody] Personagem personagem)
            {
              if(!ModelState.IsValid){
                return BadRequest(ModelState);
              }

              _appDbContext.XablauDb.Add(personagem);
              await _appDbContext.SaveChangesAsync();
              return Created("Personagem criado co sucesso!",personagem);

            }

          [HttpGet]

           public async Task<ActionResult <IEnumerable<Personagem>>> GetPersonagem()
            {
              var personagem = await _appDbContext.XablauDb.ToListAsync();

              return Ok(personagem);

            } 

            [HttpGet("{id}")]

            public async Task<ActionResult<Personagem>>  GetPersonagemById(int id)
            {
                var personagem = await _appDbContext.XablauDb.FindAsync(id);

                if (personagem == null)
                {
                    return NotFound("Personagem não encontrado!");
                }

                return Ok(personagem);
            }

            [HttpPut("{id}")] // Define que esse método responde a requisições PUT com um ID na URL, ex: api/personagens/1

            public async Task<IActionResult> UpdatePersonagem(int id, [FromBody] Personagem personagemAtualizado)
            {
                // Busca o personagem existente no banco de dados pelo ID
                var personagemExistente = await _appDbContext.XablauDb.FindAsync(id);

                // Se o personagem não for encontrado, retorna o status 404 Not Found
                if (personagemExistente == null)
                {
                    return NotFound("Personagem não encontrado.");
                }

                // Atualiza os valores do personagem existente com os valores enviados na requisição
                _appDbContext.Entry(personagemExistente).CurrentValues.SetValues(personagemAtualizado);

                // Salva as mudanças no banco de dados
                await _appDbContext.SaveChangesAsync();

                // Retorna o status 201 Created indicando que a atualização foi feita com sucesso
                return StatusCode(201, personagemExistente);
            }

            [HttpDelete("{id}")] // Define que esse método responde a requisições DELETE com um ID na URL, ex: api/personagens/1
            public async Task<IActionResult> DeletePersonagem(int id)
            {
                // Busca o personagem pelo ID informado
                var personagem = await _appDbContext.XablauDb.FindAsync(id);

                // Se o personagem não for encontrado, retorna o status 404 Not Found
                if (personagem == null)
                {
                    return NotFound("Personagem não encontrado.");
                }

                // Remove o personagem do banco de dados
                _appDbContext.XablauDb.Remove(personagem);

                // Salva as mudanças no banco de dados
                await _appDbContext.SaveChangesAsync();

                // Retorna uma mensagem indicando que a exclusão foi bem-sucedida, com o status 200 OK
                return Ok("Personagem deletado com sucesso!");
            }


        

      


    }
}