using CleanArchitectureSample.Application.Extensions;
using CleanArchitectureSample.Persistence.Extensions;
using CleanArchitectureSample.Infrastructure.Extensions;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationLayer();

builder.Services.AddInfrastructureLayer();
//builder.Services.AddDbContext<TraineeDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("myconnection")));
builder.Services.AddPersistenceLayer(builder.Configuration);
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
