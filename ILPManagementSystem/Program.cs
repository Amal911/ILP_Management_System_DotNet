using ILPManagementSystem;
using ILPManagementSystem.Data;
using ILPManagementSystem.Models.Validators;
using ILPManagementSystem.Repository;
using ILPManagementSystem.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.AspNetCore;
using ILPManagementSystem.Services;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApiContext>(options => options.UseNpgsql("Host = localhost; Database = ILP; Username = postgres; Password = Santhi@2001;"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddAutoMapper(typeof(MappingConfig));



builder.Services.AddScoped<BatchRepository>();
builder.Services.AddScoped<IBatchRepository, BatchRepository>();
builder.Services.AddScoped<LocationRepository>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<PhaseRepository>();
builder.Services.AddScoped<IPhaseRepository, PhaseRepository>();
builder.Services.AddScoped<BatchPhaseRepository>();
builder.Services.AddScoped<IBatchPhaseRepository, BatchPhaseRepository>();
builder.Services.AddScoped<SessionAttendanceRepository>();  
builder.Services.AddScoped<ISessionAttendanceRepository, SessionAttendanceRepository>();


builder.Services.AddScoped<PhaseService>();

builder.Services.AddValidatorsFromAssemblyContaining<PhaseDTOValidator>();
builder.Services.AddFluentValidationAutoValidation();

var app = builder.Build();
app.UseCors("AllowAll");

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
