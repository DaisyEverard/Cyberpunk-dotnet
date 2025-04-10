

using cyberpunk_dotnet.Data.Interfaces;
using cyberpunk_dotnet.Data.Mongo;
using Microsoft.AspNetCore.Http.Features;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "all", policy => {
        policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
        }
    );
});

builder.Services.Configure<FormOptions>(options => {
    options.KeyLengthLimit = int.MaxValue;
    });

builder.Services.AddHttpLogging((o) => { });
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICharacterRepository, Mongo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("all");
app.UseHttpLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
