using Mam.Api.Extensions;
using Mam.Application.Commands.Reservartion.CreateReservation;
using Mam.Application.Interfaces.IRepository;
using Mam.Application.Interfaces.IUnitOfWork;
using Mam.Application.Queries.Reservation.GetReservationById;
using Mam.Persistence.Context;
using Mam.Persistence.Repository;
using Mam.Persistence.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddDbContext<HotelDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(x => x.AsScoped(), typeof(CreateReservationCommand));


//builder.Services.AddOutputCache(options =>
//{
//    options.AddBasePolicy(builder =>
//    {
//        builder.Expire(TimeSpan.FromSeconds(10));
//    });
//});


builder.Services.AddOutputCache(options =>
{
    options.AddPolicy("Custom", builder =>
    {
        builder.Expire(TimeSpan.FromSeconds(5));
    });
});


builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("Basic", builder =>
    {
        builder.Window = TimeSpan.FromSeconds(10);
        builder.PermitLimit = 3;
        builder.QueueLimit = 1;
        builder.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.UseOutputCache();
app.UseRateLimiter();


app.Get<GetReservationByIdQuery>("reservation/{id}");
app.Post<CreateReservationCommand>("reservation");


app.MapGet("deneme", (int? age) =>
{
    return Results.Ok(new
    {
        message = "age: " + age
    });
});


app.MapGet("ratelimit", () =>
{
    return Results.Ok(new
    {
        DateTime = DateTime.Now,
    });
}).RequireRateLimiting("Basic");


//app.MapGet("cache", () =>
//{
//    return Results.Ok(new
//    {
//        DateTime = DateTime.Now,

//    });
//}).CacheOutput();


app.MapGet("CustomCache", () =>
{
    return Results.Ok(new
    {
        DateTime = DateTime.Now,

    });
}).CacheOutput("Custom");

app.DatabaseInitialize();
app.Run();

