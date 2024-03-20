using Microsoft.EntityFrameworkCore;
using SharpCodingAPI.Domains.DTO.dbContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); // Registra e Procura controladores na aplicacao
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var defaultConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BankDbContext>(options => {
    options.UseSqlite(defaultConnectionString);
});

builder.Services.AddCors(options =>
{
   options.AddDefaultPolicy(
     policy =>
     {
       policy.AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod();
     });
});

var app = builder.Build();
app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}

app.UseHttpsRedirection();


app.MapControllers(); // mapeia os controladores quando a aplicacao iniciar

app.Run();

