using HealthChecks.UI.Client;
using HealthCheckSample;
using HealthCheckSample.Health;
using HealthCheckSample.Services;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHealthChecks()
    .AddCheck<EmailServiceHealthCheck>("EmailService")
    .AddSqlServer(builder.Configuration.GetConnectionString("DbConnectionString")!);

builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionString")));

var app = builder.Build();



app.MapHealthChecks("/_health" ,new HealthCheckOptions()
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
     
});

app.UseAuthorization();

app.MapControllers();

app.Run();
