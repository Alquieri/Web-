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
            public async Task<IActionResult> AddPersonagem(Personagem personagem)
            {
              if(personagem == null){
                return BadRequest("Dados inválidos!");
              }

              _appDbContext.XablauDb.Add(personagem);
              await _appDbContext.SaveChangesAsync();
              return StatusCode(201, personagem);

            }

          [HttpGet]

           public async Task<ActionResult <IEnumerable<Personagem>>> GetPersonagem()
            {
              var personagem = await _appDbContext.XablauDb.ToListAsync();

              return Ok(personagem);

            }

            [HttpGet("{id}")]

            public async Task<ActionResult<Personagem>> GetPersonagemById(int id)
            {
                var personagem = await _appDbContext.XablauDb.FindAsync(id);

                if (personagem == null)
                {
                    return NotFound("Personagem não encontrado!");
                }

                return Ok(personagem);
            }


        

      


    }
}