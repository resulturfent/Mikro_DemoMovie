using DemoMovie.Core.Repositories;
using DemoMovie.Core.Services;
using DemoMovie.Core.UnitOfWorks;
using DemoMovie.Repository;
using DemoMovie.Repository.Repositories;
using DemoMovie.Repository.UnitOfWorks;
using DemoMovie.Service.Mapping;
using DemoMovie.Service.Services;
using Emptor.Shared.MassTransit.Net6;
using Emptor.Shared.MassTransit.Net6.Configurators;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Proje içinde kullanılacak classların tanımlanması

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>),typeof(Service<>));

builder.Services.AddAutoMapper(typeof(MapProfile));//Assembly olarak verildi

#endregion

#region RabbitMq entegrasyonu

builder.Services.AddEmptorMassTransit(new EmptorMassTransitConfiguration()
{

    RabbitMqApiRoot = "http://" + builder.Configuration.GetValue<string>("MassTransit:Host") + ":15672/api",
    HostAddress = builder.Configuration.GetValue<string>("MassTransit:Host"),
    Username = builder.Configuration.GetValue<string>("MassTransit:Username"),
    Password = builder.Configuration.GetValue<string>("MassTransit:Password"),
    Consumers = new List<EmptorConsumer>()
    {
        EmptorConsumerCreator.Create<MikroDemoConsumer>(builder.Configuration.GetValue<string>("RabbitMQ:MovieMessage")),
      //  EmptorConsumerCreator.Create<MikroDemoConsumer2>(builder.Configuration.GetValue<string>("RabbitMQ:MovieMessage") + "2"),
        //EmptorConsumerCreator.Create<MikroDemoConsumer3>(builder.Configuration.GetValue<string>("RabbitMQ:MovieMessage") + "3")
    }
});

#endregion

#region SQL Connaction

builder.Services.AddDbContext<AppDbContext>(k =>
{
    k.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), options =>
    {
        //options.MigrationsAssembly("DemoMovie.Repository");//Migration yapılacak katmanı verir. Bu şekilde tanımlanması güvenli değildir. Sadece katmana göre tanımlanıyor çünkü ama katman adı vermen class ile çağırma işlemi için aşağıdaki gibi tanımlanır
        options.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);//AppDbContext class'ının olduğu Assembly referans alınaral migration işlemleri yapılacak
    });

});

#endregion

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
