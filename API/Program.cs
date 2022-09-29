using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<StoreContext>(x => x.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IProductRepository, ProductRepository>();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<StoreContext>();
    await dataContext.Database.MigrateAsync();
    await StoreContextSeed.SeedAsync(dataContext);
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
