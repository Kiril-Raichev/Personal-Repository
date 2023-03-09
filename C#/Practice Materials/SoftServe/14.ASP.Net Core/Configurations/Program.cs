using Configurations.Options;
using Swashbuckle.Swagger;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);


var ConStr = new SqlConnectionStringBuilder(
    builder.Configuration.GetConnectionString("Connection"));
ConStr.Password = builder.Configuration["DevPass"];
var devConnection = ConStr.ConnectionString;

builder.Services.Configure<PageOptions>(builder.Configuration.GetSection("Pagging"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
