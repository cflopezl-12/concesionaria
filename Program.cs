using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Interfaces;
using Infraestructure.Data;
using Infraestructure.Repositories;
using Infraestructure;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Service;
using WebAppConcesionaria.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<StoreDatabaseSettings>(
                builder.Configuration.GetSection(nameof(StoreDatabaseSettings)));

builder.Services.AddSingleton<IStoreDatabaseSettings>(sp =>
                                                        sp.GetRequiredService<IOptions<StoreDatabaseSettings>>().Value
                                                     );

builder.Services.AddSingleton<IMongoClient>(s =>
        new MongoClient(builder.Configuration.GetValue<string>("StoreDatabaseSettings:ConnectionString")));




builder.Services.Add(
    new ServiceDescriptor(typeof(IUnitOfWork), typeof(UnitOfWork), ServiceLifetime.Transient)
);
builder.Services.Add(
    new ServiceDescriptor(typeof(IVehiculoRepository), typeof(VehiculoRepository), ServiceLifetime.Transient)
    );
builder.Services.Add(
    new ServiceDescriptor(typeof(IVehiculoService), typeof(VehiculoService), ServiceLifetime.Transient)
    );

builder.Services.AddAutoMapper(typeof(MappingProfiles));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
