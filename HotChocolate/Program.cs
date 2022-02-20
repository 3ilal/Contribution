using Queries;
using Data;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<DataContext>();

builder.Services.AddGraphQLServer()
.AddQueryType<Query>()
.AddProjections()
.InitializeOnStartup();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

using var scope = app.Services.CreateScope();

var db = scope.ServiceProvider.GetRequiredService<DataContext>();
db.Database.EnsureCreated();
db.Aggregates.AddRange(new[]{
    new MyAggregate{
        Id = Guid.NewGuid(),
        Total = 100,
        Discount =0,
    },
        new MyAggregate{
        Id = Guid.NewGuid(),
        Total = 200,
        Discount =50,
    },
        new MyAggregate{
        Id = Guid.NewGuid(),
        Total = 400,
        Discount =30,
    },
        new MyAggregate{
        Id = Guid.NewGuid(),
        Total = 700,
        Discount =100,
    },
});

db.SaveChanges();

app.MapGraphQL();
app.Run();