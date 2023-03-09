using Logger.Middlewares;
using Serilog;
using Serilog.Core;
using Serilog.Formatting.Json;

var builder = WebApplication.CreateBuilder(args);

//serilog
var log = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File(".Logs/logs.txt", rollingInterval: RollingInterval.Day)
    .WriteTo.File(new JsonFormatter(), ".Logs/json-logs.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
   
Log.Logger = log;

builder.Logging.ClearProviders();
builder.Logging.AddConsole();


//Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

var logger = LoggerFactory.Create(config =>
{
    config.AddConsole();
}).CreateLogger(nameof(Program));

app.UseMiddleware<ExceptionHandler>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.Map("/error", app =>
{
    app.Run((context) =>
    {
        logger.LogWarning("Error exception thrown");
        throw new Exception("Error occured");
    });
});

app.Use(async (context, next) =>
{
    logger.LogInformation("added header: test with value: test");
    context.Response.Headers.Add("test", "test");
    await next();
});

app.Use(async (context, next) =>
{
    Log.Information("added header: test with value: seriloger");
    context.Response.Headers.Add("tests", "seriloger");
    await next();
});

app.Run(async (context) =>
{
    logger.LogInformation("App launched");
    await context.Response.WriteAsync("App has launched");
});

app.Run();
