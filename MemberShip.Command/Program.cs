using MemberShip.Command.Infrastructure.MessageBus;
using MemberShip.Command.Infrastructure.Persistence;
using MemberShip.Command.Validators;
using Azure.Messaging.ServiceBus;
using Calzolari.Grpc.AspNetCore.Validation;
using MemberShip.Command.Contracts;
using MemberShip.Command.Exceptions.Interceptors;
using MemberShip.Command.Infrastructure.Implementation;
using System.Reflection;
using MemberShip.Command.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddGrpc(o =>
{
    o.Interceptors.Add<MemberShipInterceptor>();
    o.EnableMessageValidation();
});
builder.Services.AddValidator<SendInvitationRequestValidator>();
builder.Services.AddGrpcValidation();
builder.Services.AddMediatR
(Assembly.GetExecutingAssembly());

builder.Services.AddDbContext
    <ApplicationDbContext>
(opt => { opt.UseSqlServer(builder.Configuration.GetConnectionString("MemberShipDbConnection")); });

builder.Services.AddScoped<IEventStore, EventStore>();

builder.Services.AddSingleton(
    new ServiceBusClient(
        builder.Configuration.GetConnectionString("MemberShipServiceBus")));

builder.Services.AddSingleton<ServiceBusPublisher>();
var app = builder.Build();

app.MapGrpcService<MemberShipService>();

app.Run();
