using FluentValidation;

namespace Pattern.Application.Shipment.Validators
{
    public class CreateShipmentDtoValidator : AbstractValidator<CreateShipmentDto>
    {
        public CreateShipmentDtoValidator()
        {
            RuleFor(x => x.OrderId)
                .GreaterThan(0).WithMessage("OrderId must be greater than 0.");

            RuleFor(x => x.ShipmentDate)
                .NotEmpty().WithMessage("ShipmentDate is required.")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("ShipmentDate cannot be in the future.");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Status is required.")
                .MaximumLength(50).WithMessage("Status cannot exceed 50 characters.");

            RuleFor(x => x.TrackingNumber)
                .NotEmpty().WithMessage("TrackingNumber is required.")
                .MaximumLength(100).WithMessage("TrackingNumber cannot exceed 100 characters.");

            RuleFor(x => x.Carrier)
                .NotEmpty().WithMessage("Carrier is required.")
                .MaximumLength(100).WithMessage("Carrier cannot exceed 100 characters.");
        }
    }
}