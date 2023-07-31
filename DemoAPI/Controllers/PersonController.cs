using DemoLibrary.Commands;
using DemoLibrary.Models;
using DemoLibrary.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IEnumerable<PersonModel>> GetPerson()
        {
            return await _mediator.Send(new GetPersonListQuery());
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<PersonModel> GetById(int id)
        {
            return await _mediator.Send(new GetPersonByIdQuery(id));
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<PersonModel> Post([FromBody] PersonModel value)
        {
            return await _mediator.Send(new InsertPersonCommands(value.FirstName, value.LastName));
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
