using AuthorizationService.BackgroundServices;
using AuthorizationService.Services.Contracts;
using AuthorizationService.Services.Implementation;
using AuthorizationService.Utilidades;
using ConfirmationService.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Persistence.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(opt => opt.AddPolicy("AllowWebapp", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

// Agregar servicios al contenedor de inyección de dependencias
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AuthorizationService", Version = "v1" });
});

builder.Services.AddDbContext<AplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddScoped<IAuthorizationRepository, AuthorizationRepository>();

// Registrar el cliente HTTP del procesador de pagos
builder.Services.AddHttpClient<PaymentProcessorClient>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7278/");
});

// Registro el servicio en segundo plano para reversión de autorizaciones
builder.Services.AddHostedService<AuthorizationReversalService>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Documentation");
    });
}

app.UseCors("AllowWebapp");
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.Run();
