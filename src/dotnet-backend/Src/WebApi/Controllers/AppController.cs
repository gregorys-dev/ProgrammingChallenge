using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ProgrammingChallenge.WebApi.Controllers
{
    public class AppController : ControllerBase
    {
        protected readonly IMediator Mediator;
     
        public AppController(IMediator mediator) => Mediator = mediator;
    }
}