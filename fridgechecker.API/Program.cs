using fridgechecker.Legacy;
using fridgechecker.Service;
using fridgechecker.Utilities.Mapper;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IHouseHoldService, HouseHoldService>();
builder.Services.AddScoped<IStorageService, StorageService>();
builder.Services.AddScoped<IFoodService, FoodService>();
builder.Services.AddScoped<IDishService, DishService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddDbContext<FridgeLegacyContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("ProductionConnection"))
);
builder.Services.AddAutoMapper(typeof(FridgeCheckerMapper));

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