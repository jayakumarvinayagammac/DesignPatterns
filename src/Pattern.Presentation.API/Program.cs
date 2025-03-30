using Pattern.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Pattern.Application.Shipment.Commands;
using MediatR;
using Pattern.Application.Events;
using Pattern.Domain.Common;
using Pattern.Infrastructure.Repositories;
using Pattern.Domain.Entities;
using Pattern.Application.Queries;
using Pattern.Application.Mapping;
using Pattern.Application.Shipment;
using FluentValidation.AspNetCore;
using FluentValidation;
using Pattern.Application.Shipment.Validators;
using Pattern.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(EcommerceMappingProfile).Assembly);

// Add services to the container.
builder.Services
.AddShipmentServices()
.AddUserServices();
// builder.Services.AddTransient<IRequestHandler<CreateShipmentCommand, Result<ShipmentResponse>>, CreateShipmentCommandHandler>();
// builder.Services.AddTransient<IRequestHandler<CollectionShipmentQuery, Result<IEnumerable<ShipmentDto>>>, CollectionShipmentQueryHandler>();
// builder.Services.AddTransient<IRequestHandler<GetShipmentQuery, Result<ShipmentDto>>, GetShipmentQueryHandler>();
// builder.Services.AddTransient<IRequestHandler<UpdateShipmentCommand, Result<ShipmentResponse>>, UpdateShipmentCommandHandler>();
// builder.Services.AddTransient<IRequestHandler<DeleteShipmentCommand, Result<ShipmentResponse>>, DeleteShipmentCommandHandler>();
// builder.Services.AddScoped<IShipmentRepository<Shipment>, ShipmentRepository>();

builder.Services.AddControllers();

// Register FluentValidation
builder.Services.AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<CreateShipmentDtoValidator>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var Configuration = builder.Configuration;
builder.Services.AddDbContext<EcommerceDbContext>(options =>
    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pattern.Presentation.API v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
