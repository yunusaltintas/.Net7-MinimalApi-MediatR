using Azure.Core;
using Mam.Api.Extensions;
using Mam.Application.Commands.Reservartion.CreateReservation;
using Mam.Application.Commands.Reservartion.UpdateReservation;
using Mam.Application.Interfaces.IRepository;
using Mam.Application.Interfaces.IUnitOfWork;
using Mam.Application.Queries.Reservation.GetReservationById;
using Mam.Persistence.Context;
using Mam.Persistence.Repository;
using Mam.Persistence.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddDbContext<HotelDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(x => x.AsScoped(), typeof(CreateReservationCommand));

builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("fixed", _options =>
    {
        _options.Window = TimeSpan.FromSeconds(20);
        _options.PermitLimit = 3;
        _options.QueueLimit = 1;
        _options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
    });


    // -------- --------    ---------------------
    options.AddSlidingWindowLimiter("sliding", _options =>
    {
        _options.Window = TimeSpan.FromSeconds(20);
        _options.PermitLimit = 3;
        _options.QueueLimit = 1;
        _options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        _options.SegmentsPerWindow = 2;
    });


    options.AddConcurrencyLimiter("concurrency", _options =>
    {
        _options.PermitLimit = 10;
        _options.QueueLimit = 1;
        _options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
    });


    options.AddTokenBucketLimiter("Token", _options =>
    {
        _options.TokensPerPeriod = 4;
        _options.TokenLimit = 4;
        _options.QueueLimit = 1;
        _options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        _options.ReplenishmentPeriod = TimeSpan.FromSeconds(20);
    });


    options.RejectionStatusCode = 429;
});

builder.Services.AddOutputCache(options =>
{
    options.AddBasePolicy(_opt =>
    {
        _opt.Expire(TimeSpan.FromSeconds(20));
    });

    options.AddPolicy("5sn", _opt =>
    {
        _opt.Expire(TimeSpan.FromSeconds(5));
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.UseOutputCache();
//app.UseRateLimiter();


app.MapGet("datetime", () =>
{
    return Results.Ok(new
    {
        Datetime = DateTime.Now
    });
}).CacheOutput("5sn");

app.MapGet("reservations/{id}", async (IMediator mediator, Guid id) =>
{
    await mediator.Send(new GetReservationByIdQuery(id));
});

app.MapPost("reservations", async (IMediator mediator, [FromBody] CreateReservationCommand request) =>
{
    await mediator.Send(request);
});

app.MapPut("reservations/{id}", async (IMediator mediator, Guid id, [FromBody] UpdateReservationCommand request) =>
{
    await mediator.Send(request);
});

app.DatabaseInitialize();
app.Run();

