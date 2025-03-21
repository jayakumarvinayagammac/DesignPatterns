using Pattern.Application.Shipment.Commands;
using Pattern.Domain.Shared;
using Microsoft.Extensions.Logging;
using Pattern.Domain.Common;

namespace Pattern.Application.Shipment.Events
{
    public class CreateShipmentCommandHandler : ICommandHandler<CreateShipmentCommand, Result>
    {
        private readonly ILogger<CreateShipmentCommandHandler> _logger;

        public CreateShipmentCommandHandler(ILogger<CreateShipmentCommandHandler> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<Result> Handle(CreateShipmentCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling CreateShipmentCommand");
            _logger.LogInformation("Request details: {@Request}", request);
            // Placeholder for handling the command
            //throw new NotImplementedException();
            await Task.Delay(1000);
            try
            {
                return Result.Success();
            }
            catch (Exception ex)
            {
                 // TODO
                return Result.Failure(FollowerErrors.AlreadyFollowing);
            }
        }
    }
}