using Microsoft.AspNetCore.Mvc;
using Net6_ApiModelo.Data;
using Net6_ApiModelo.Model.Entities;
using Net6_ApiModelo.Model.Interfaces.Generics;

namespace Net6_ApiModelo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonagemController : ControllerBase
    {

        //private  readonly ApplicationDbContext _context;
        private readonly IRepository<Personagem> _repository;

        public PersonagemController(IRepository<Personagem> repository)//ApplicationDbContext applicationDbContext)
        {
            //_context = applicationDbContext;
            _repository = repository;
        }

        [HttpGet("Todos-Personagem")]
        public Task<List<Personagem>> Get()
        {
            var Person = _repository.GetAll(); //.Personagem.ToList();
            return Person;
        }

        //sem retorno
        [HttpPost("Adicionar-Personagem-Void")]
        public void AddPerson(Personagem personagem)
        {
            _repository.Add(personagem);
        }

        //retornando task
        [HttpPost("Adicionar-Personagem-Task")]
        public async Task<ActionResult<Personagem>> AddTask(Personagem personagem) 
        {
            if (personagem == null) return BadRequest(); // NotFound() pode ser tambem mais usando para get "busca"
            await _repository.AddTask(personagem);

            return Ok(personagem);    

        }












        ////VER FUTURAMENTE ADD USANDO INTERFACE ERRO QUE APRESENTA.
        //[HttpPost("Adicionar-Personagem")]
        //public  Task<ActionResult<Personagem>> AddPerson(Personagem personagem) 
        //{
        //    foreach (var item in personagem)
        //    {
        //        Personagem _personagem = new Personagem();
        //        _personagem = item.id,
        //             _personagem = item.name,
        //        _repository.Add(_personagem);
        //    }

        //   // var PersonAdd = _repository.Add(personagem);

        //   // return Ok();
        //}
    }
}