using Anis.MemeberShip.Command.ly.Exceptions.Interceptors;
using Anis.MemeberShip.Command.ly.Infrastructure.MessageBus;
using Anis.MemeberShip.Command.ly.Infrastructure.Persistence;
using Anis.MemeberShip.Command.ly.Validators;
using Azure.Messaging.ServiceBus;
using Calzolari.Grpc.AspNetCore.Validation;
using System.Reflection;

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
