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
builder.Services.AddDbContext<ApiContext>(options => options.UseNpgsql("Host = localhost; Database = ILP; Username = postgres; Password = Haida@123;"));

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
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<AssessmentTypeRepository>();
builder.Services.AddScoped<IAssessmentTypeRepository, AssessmentTypeRepository>();


builder.Services.AddScoped<PhaseService>();
builder.Services.AddScoped<AssessmentRepository>();
builder.Services.AddScoped<IAssessmentRepository, AssessmentRepository>();
builder.Services.AddScoped<BatchTypeRepository>();
builder.Services.AddScoped<IBatchTypeRepository, BatchTypeRepository>();

builder.Services.AddScoped<AssessmentTypeService>();
builder.Services.AddValidatorsFromAssemblyContaining<AssessmentTypeDTOValidator>();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<SessionRepository>();
builder.Services.AddScoped<ISessionRepository, SessionRepository>();
builder.Services.AddScoped<ILeaveRepository, LeaveRepository>();
builder.Services.AddScoped<ILeaveApprovalRepository, LeaveApprovalRepository>();



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
