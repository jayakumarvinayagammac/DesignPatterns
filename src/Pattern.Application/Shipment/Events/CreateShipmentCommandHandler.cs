using Pattern.Application.Shipment.Commands;
using Pattern.Domain.Shared;
using Microsoft.Extensions.Logging;

namespace Pattern.Application.Shipment.Events
{
    public class CreateShipmentCommandHandler : ICommandHandler<CreateShipmentCommand, bool>
    {
        private readonly ILogger<CreateShipmentCommandHandler> _logger;

        public CreateShipmentCommandHandler(ILogger<CreateShipmentCommandHandler> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public Task<bool> Handle(CreateShipmentCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling CreateShipmentCommand");
            _logger.LogInformation("Request details: {@Request}", request);
            // Placeholder for handling the command
            throw new NotImplementedException();
        }
    }
}