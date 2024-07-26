using ILPManagementSystem;
using ILPManagementSystem.Data;
using ILPManagementSystem.Models.Validators;
using ILPManagementSystem.Repository;
using ILPManagementSystem.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.AspNetCore;
using ILPManagementSystem.Services;

using ILPManagementSystem.Services.ValidationServices;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using ILPManagementSystem.EndPoints;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Protocols;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var ConnectionString = builder.Configuration.GetConnectionString("DefaultString");
builder.Services.AddDbContext<ApiContext>(options => options.UseNpgsql(ConnectionString));

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
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<AssessmentTypeRepository>();
builder.Services.AddScoped<IAssessmentTypeRepository, AssessmentTypeRepository>();

builder.Services.AddScoped<AttendanceRepository>();
builder.Services.AddScoped<IAttendanceRepository, AttendanceRepository>();
builder.Services.AddScoped<AttendanceService>();

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
builder.Services.AddScoped<PhaseAssessmentTypeMappingRepository>();
builder.Services.AddScoped<CreateBatchService>();
builder.Services.AddScoped<ICreateBatchService,CreateBatchService>();
builder.Services.AddScoped<BatchProgramRepository>();
builder.Services.AddScoped<IBatchProgramRepository, BatchProgramRepository>();

/* builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
     .AddJwtBearer(options =>
     {
         options.Authority = "https://login.microsoftonline.com/5b751804-232f-410d-bb2f-714e3bb466eb";
         options.Audience = "your-api-scope";
     });
*/
/*var key = Encoding.ASCII.GetBytes("");*/
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
 .AddJwtBearer(options =>
 {
     options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
     {
         ValidateIssuer = true,
         ValidateAudience = true,
         ValidateLifetime = true,
         ValidateIssuerSigningKey = true,
         ValidIssuer = "https://login.microsoftonline.com/5b751804-232f-410d-bb2f-714e3bb466eb",
         ValidAudience = "d85e6ad5-324d-41e5-9666-b9fb9a1a4aa3",
         IssuerSigningKeyResolver = (token, securityToken, kid, parameters) =>
         {
             // Retrieve the signing keys from Azure AD
             var discoveryDocument = $"https://login.microsoftonline.com/5b751804-232f-410d-bb2f-714e3bb466eb/.well-known/openid-configuration";
             var configurationManager = new ConfigurationManager<OpenIdConnectConfiguration>(discoveryDocument, new OpenIdConnectConfigurationRetriever());
             var config = configurationManager.GetConfigurationAsync(CancellationToken.None).Result;
             return config.SigningKeys;
         }
         /*IssuerSigningKey = new SymmetricSecurityKey(key)*/
     };
 });
    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("AdminPolicy", policy => policy.RequireClaim("roles", "Admin"));
        options.AddPolicy("TrainerPolicy", policy => policy.RequireClaim("roles", "Trainer"));
        options.AddPolicy("TraineePolicy", policy => policy.RequireClaim("roles", "Trainee"));
    });

    builder.Services.AddControllers();



var app = builder.Build();
app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.ConfigureAuthEndPoints();

app.MapControllers();

app.Run();
