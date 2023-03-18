using Microsoft.AspNetCore.Mvc;
using Net6_ApiModelo.Data;
using Net6_ApiModelo.Model.Entities;

namespace Net6_ApiModelo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonagemController : ControllerBase
    {

        private  readonly ApplicationDbContext _context;

        public PersonagemController(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }



        [HttpGet("Personagem")]
        public IEnumerable<Personagem> Get()
        {
           var Person =  _context.Personagem.ToList();
            return Person;
        }
    }
}