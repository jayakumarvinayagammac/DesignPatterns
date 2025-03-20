using Microsoft.AspNetCore.Mvc;
using Pattern.Application.Shipment.Commands;
using MediatR;
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
        public IActionResult GetShipments()
        {
            // Placeholder for fetching shipments
            return Ok(new { Message = "List of shipments" });
        }

        [HttpGet("{id}")]
        public IActionResult GetShipmentById(int id)
        {
            // Placeholder for fetching a shipment by ID
            return Ok(new { Message = $"Shipment details for ID {id}" });
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateShipment([FromBody] CreateShipmentDto shipment)
        {
            // Placeholder for creating a new shipment
            var result = _mediator.Send(new CreateShipmentCommand(shipment));
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateShipment(int id, [FromBody] object shipment)
        {
            // Placeholder for updating a shipment
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteShipment(int id)
        {
            // Placeholder for deleting a shipment
            return NoContent();
        }
    }
}