using Microsoft.AspNetCore.Mvc;
using Net6_ApiModelo.Data;
using Net6_ApiModelo.Model.Entities;

namespace Net6_ApiModelo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonagemController : ControllerBase
    {
        //controller simples com Instancia do DBcontext direto sem DI

        private  readonly ApplicationDbContext _context;

        //construtor recebendo Instancia direto
        public PersonagemController()
        {
            _context = new ApplicationDbContext();
        }



        [HttpGet("Personagem")]
        public IEnumerable<Personagem> Get()
        {
           var Person =  _context.Personagem.ToList();
            return Person;
        }
    }
}