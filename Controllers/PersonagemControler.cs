using Microsoft.AspNetCore.Mvc;
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
        

      


    }
}