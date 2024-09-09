using Insurance.Api.Infra.ExceptionHandler;
using Insurance.Application.Services;
using Insurance.DataAccess.DbContexts;
using Insurance.DataAccess.Repositories;
using Insurance.DataAccess.SeedData;
using Insurance.Domain.RepositoriesInterface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<InsuranceDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IInsuranceService,InsuranceService>();
builder.Services.AddScoped<IInsuranceDemandRepository, InsuranceDemandRepository>();
builder.Services.AddScoped<IInsuranceCoverageRepository, InsuranceCoverageRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<InsuranceDbContext>();
    DbInitializer.Initialize(context);
}


app.Run();
