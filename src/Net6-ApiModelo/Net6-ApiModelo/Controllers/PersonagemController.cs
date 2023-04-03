using Microsoft.AspNetCore.Mvc;
using Net6_ApiModelo.Data;
using Net6_ApiModelo.Model.Entities;
using Net6_ApiModelo.Model.Interfaces.Generics;
using Net6_ApiModelo.Model.UnitOfWork;

namespace Net6_ApiModelo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonagemController : ControllerBase
    {

        //private  readonly ApplicationDbContext _context;
        private readonly IRepository<Personagem> _repository;
        private readonly IUnitOfWork _UoW;

        public PersonagemController(IRepository<Personagem> repository, IUnitOfWork uow)//ApplicationDbContext applicationDbContext)
        {
            //_context = applicationDbContext;
            _repository = repository;
            _UoW = uow;
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
            await _UoW.Commit(); //se no repositorio não tiver o save então chma o uow para fazer o commit no banco

            return Ok(personagem);    

        }
    }
}