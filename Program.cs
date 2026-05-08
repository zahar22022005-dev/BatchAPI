using BatchAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ⬇️⬇️⬇️ ДОБАВЬТЕ ЭТУ СТРОКУ ⬇️⬇️⬇️
builder.Services.AddSingleton<BatchService>();
// ⬆️⬆️⬆️ ДОБАВЬТЕ ЭТУ СТРОКУ ⬆️⬆️⬆️

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();