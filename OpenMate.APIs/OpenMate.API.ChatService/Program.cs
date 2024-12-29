using Microsoft.EntityFrameworkCore;
using OpenMate.API.Domain.Interfaces;
using OpenMate.API.Infrastructure.Data;
using OpenMate.API.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped(typeof(IUserService), typeof(UserService));

var app = builder.Build();

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();