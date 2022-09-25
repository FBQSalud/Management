using FBQ.Salud_AccessData.Commands;
using FBQ.Salud_AccessData.Queries;
using FBQ.Salud_Application.Services;
using FBQ.Salud_Domain.Commands;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(x =>
                                x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);
builder.Services.AddDbContext<FBQSaludDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//Repository
builder.Services.AddTransient<IInsumosRepository, IsumosRepository>();
builder.Services.AddTransient<IInsumosService, InsumosServices>();
builder.Services.AddTransient<IDocumentosRepository, DocumentosRepository>();
builder.Services.AddTransient<IDocumentosSevice, DocumentosServices>();

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
