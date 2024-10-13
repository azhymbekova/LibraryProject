using LibraryProject.Data;
using LibraryProject.Data.Repository;
using LibraryProject.BL.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LibraryContext>(opt =>
    opt.UseNpgsql("User ID=postgres; Password=admin; Server=localhost; Port=5432; Database=postgres; Pooling=True;",
    b => b.MigrationsAssembly("LibraryProject.Data")));

builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<LibraryService>(); 
builder.Services.AddScoped<BookRepository>();
builder.Services.AddScoped<LibraryRepository>();
builder.Services.AddScoped<SimpleRepository<Library>>(); 

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<LibraryContext>();
    dbContext.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
