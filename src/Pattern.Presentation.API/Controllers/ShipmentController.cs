using Microsoft.AspNetCore.Mvc;
using Pattern.Application.Shipment.Commands;
using MediatR;
using Pattern.Application.Queries;
using Pattern.Application.Shipment;
namespace Pattern.Presentation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShipmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShipmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetShipments()
        {
            // Placeholder for fetching shipments
             var response = await _mediator.Send(new CollectionShipmentQuery());
            return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetShipmentById(int id)
        {
            // Placeholder for fetching a shipment by ID
            var response = await _mediator.Send(new GetShipmentQuery(id));
            return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateShipment([FromBody] CreateShipmentDto shipment)
        {
            // Placeholder for creating a new shipment
            var response = await _mediator.Send(new CreateShipmentCommand(shipment));
            return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShipment(int id, [FromBody] CreateShipmentDto shipment)
        {
            // Placeholder for updating a shipment
            var response = await _mediator.Send(new UpdateShipmentCommand(id, shipment));
            return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShipment(int id)
        {
            // Placeholder for deleting a shipment
            var response = await _mediator.Send(new DeleteShipmentCommand(id));
            return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);            
        }
    }
}