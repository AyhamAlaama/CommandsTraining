using MediatR;
using MemberShip.Query.Infrastructure.Helpers;
using MemberShip.Query.Infrastructure.Persistence;
using MemberShip.Query.Infrastructure.ServiceBus.MemberShip;
using MemberShip.Query.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var serviceBusConfig = builder.Configuration.GetSection("ServiceBusConfigurations");

builder.Services.Configure<ServiceBusConfig>(serviceBusConfig);

builder.Services.AddGrpc();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddDbContext
    <ApplicationDbContext>
(opt => { 
    opt.UseSqlServer(
        builder.
        Configuration.
        GetConnectionString("MemberShipDbConnection")); });



builder.Services.AddSingleton<MemberShipServiceBus>();
builder.Services.AddSingleton<MemberShipListener>();
builder.Services.AddHostedService<MemberShipListener>();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<MemberShipService>();

app.Run();
