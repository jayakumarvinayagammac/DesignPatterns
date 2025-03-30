using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pattern.Application.User.Queries;

namespace Pattern.Presentation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        } 

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            // Placeholder for fetching users
            var response = await _mediator.Send(new CollectionUserQuery());
            return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);            
        }   

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            // Placeholder for fetching a user by ID
            var response = await _mediator.Send(new GetUserQuery(id));
            return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);
        }
    }
}