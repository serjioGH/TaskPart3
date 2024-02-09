using Cloth.API.Filter;
using Cloth.Application.Behavior;
using Cloth.Application.Extensions;
using Cloth.Application.Interfaces;
using Cloth.Application.Services;
using Cloth.Infrastructure.Extensions;
using Cloth.Persistence.Ef.Repositories;
using Cloth.Persistence.Extensions;
using MediatR;
using Persistence.Abstractions.Interfaces;
using Persistence.Abstractions.Repositories;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(typeof(Program).Assembly);
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// Add services to the container.
builder.Services.AddControllers(options => options.Filters.Add(typeof(ErrorHandlingFilter)));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .RegisterPersistenceDependencies(builder.Configuration);

builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IClothRepository, ClothRepository>();
builder.Services.AddTransient<IClothService, ClothService>();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();