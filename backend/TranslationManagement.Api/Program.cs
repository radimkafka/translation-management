using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using TranslationManagement.Business;
using TranslationManagement.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfg => 
{ 
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly); 
    cfg.RegisterServicesFromAssembly(typeof(GetTranslators).Assembly); 
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TranslationManagement.Api", Version = "v1" });
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=TranslationAppDatabase.db"));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TranslationManagement.Api v1"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();
