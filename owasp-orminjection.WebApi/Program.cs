using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using owasp_orminjection.Domain.Entities;
using owasp_orminjection.Domain.Interfaces;
using owasp_orminjection.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<dbloanmanagerContext>(options => options.UseMySql(builder.Configuration
                                                                      .GetConnectionString("Default"),MySqlServerVersion.LatestSupportedServerVersion));
builder.Services.AddScoped<IDBLoanManagerContext, dbloanmanagerContext>();
builder.Services.AddScoped<ICustomerRepository, UnsecureCustomerRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

