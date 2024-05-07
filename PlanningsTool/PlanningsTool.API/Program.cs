using PlanningsTool.DAL.Extensions;
using PlanningsTool.BLL.Extensions;
using PlanningsTool.BLL.Exceptions;
using System.Reflection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Planningstool voor Ziekenhuisdienst",
        Description = "Een planningstool is een softwaretoepassing of digitale tool die ontworpen is om de zorgkundigen hun activiteiten in te plannen.",
        Contact = new OpenApiContact
        {
            Name = "Nabil El Moussaoui",
            Email = "Nabil_EM@outlook.com",
            Url = new Uri("https://nabilelmoussaoui.netlify.app/"),
        },
        Version = "v1"
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddCors();

builder.Services.RegisterInfrastructure();
builder.Services.RegisterServices();
builder.Services.RegisterApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();
