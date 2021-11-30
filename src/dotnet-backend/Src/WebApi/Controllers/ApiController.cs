using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ProgrammingChallenge.WebApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ApiController : ControllerBase
    {
        protected readonly IMediator Mediator;
     
        public ApiController(IMediator mediator) => Mediator = mediator;
    }
}