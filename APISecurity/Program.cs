using APISecurity.Data;
using APISecurity.Middleware;
using APISecurity.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
#region DbContext
//Configure the ConnectionString and DbContext class
builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("sqlServerConnectionString"));
});
#endregion

builder.Services.AddScoped<KeyManagementService>();
builder.Services.AddScoped<AesEncryptionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// Add the AES Encryption Middleware before routing.
app.UseMiddleware<AesEncryptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
