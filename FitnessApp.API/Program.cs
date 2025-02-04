using FitnessApp.API;
using FitnessApp.DAL;
using FitnessApp.Service;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();

builder.Services.AddRegisterAPI(builder);
builder.Services.AddRegisterService(builder.Configuration);
builder.Services.AddRegisterDAL();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseGlobalException();
app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();
app.Run();