using webapi;
using webapi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<TareasContext>("Data Source=PRC00006\\SQLEXPRESS;Initial Catalog=TareasDB;User id=se; password=123456; Encrypt=False");
//Inyección de dependencias
builder.Services.AddScoped<IHelloWordService, HelloWordService>();
//Inyección de dependencias
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
//Inyección de dependencias
builder.Services.AddScoped<ITareaService, TareasService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseWelcomePage();
//app.UseTimeMiddleware();

app.MapControllers();

app.Run();
