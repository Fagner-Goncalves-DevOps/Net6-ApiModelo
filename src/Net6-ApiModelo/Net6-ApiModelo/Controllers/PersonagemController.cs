using Microsoft.AspNetCore.Mvc;
using Net6_ApiModelo.Data;
using Net6_ApiModelo.Model.Entities;
using Net6_ApiModelo.Model.Interfaces.Generics;
using Net6_ApiModelo.Model.Interfaces.UnitOfWork;

namespace Net6_ApiModelo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonagemController : ControllerBase
    {
        //Uow Generics
        protected readonly IUnitOfWorkGenerics<ApplicationDbContext> _UoW;  //esse que esta em uso total agora, os demais apenas amostrar para teste

        //private  readonly ApplicationDbContext _context;            //usando contexto puro, ver nas outras branchs 
        // private readonly IRepository<Personagem> _repository;      //usando repostrio generico sem uow direto model
        // private readonly IUnitOfWork _Work; //modelo concreto usando direto para save uow  

        public PersonagemController(
                                    IUnitOfWorkGenerics<ApplicationDbContext> unitOfWorkGenerics
                                   //IRepository<Personagem> repository, 
                                   //IUnitOfWork uow,
                                   )//ApplicationDbContext applicationDbContext) //usando contexto puro, ver nas outras branchs 
        {
            //_context = applicationDbContext; //usando contexto puro, ver nas outras branchs 
            //_repository = repository;
            //_UoW = uow; 
            _UoW = unitOfWorkGenerics;  //esse que esta em uso total agora
        }

        [HttpGet("Todos-Personagem")]
        public Task<List<Personagem>> Get()
        {
            var Person = _UoW.GetRepository<Personagem>().GetAll(); //_repository.GetAll(); //.Personagem.ToList();
            return Person;
        }

        //sem retorno
        [HttpPost("Adicionar-Personagem-Void")]
        public void AddPerson(Personagem personagem)
        {
            _UoW.GetRepository<Personagem>().Add(personagem);
            _UoW.SaveChanges();
            //_repository.Add(personagem);
        }

        //retornando task
        [HttpPost("Adicionar-Personagem-Task")]
        public async Task<ActionResult<Personagem>> AddTask(Personagem personagem) 
        {
            if (personagem == null) return BadRequest(); // NotFound() pode ser tambem mais usando para get "busca"
            await _UoW.GetRepository<Personagem>().AddTask(personagem);
            await _UoW.SaveChangesAsync();

            return Ok(personagem);

            //await _repository.AddTask(personagem);
            //await _UoW.Commit(); //se no repositorio não tiver o save então chma o uow para fazer o commit no banco



        }
    }
}