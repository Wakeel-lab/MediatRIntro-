using DemoLibrary.Models;
using DemoLibrary.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary.Handlers
{
    public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdQuery, PersonModel>
    {
        private readonly IMediator _mediator;

        public GetPersonByIdHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<PersonModel> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            Response response = new();
            var result = await _mediator.Send(new GetPersonListQuery());
            PersonModel output;
            try
            {
                output = result.FirstOrDefault(x => x.Id == request.id);
            }
            catch(Exception ex)
            {
                throw new ArgumentException($"Person with the specified {result.FirstOrDefault().Id} cannot be found");
            }
            

            return output;
        }
    }
}
