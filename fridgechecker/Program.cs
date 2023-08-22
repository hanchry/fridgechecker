using fridgechecker.Services;
using fridgechecker.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IApiClientProxy, ApiClientProxy>();
builder.Services.AddScoped<IHouseHoldService, HouseHoldService>();
builder.Services.AddScoped<IStorageService, StorageService>();
builder.Services.AddScoped<IFoodService, FoodService>();

builder.Services.AddAuthentication("CookieAuth")
    .AddCookie("CookieAuth", config =>
    {
        //if a user tries to access a page, while not authorized, they'll be redirected to the login page
        config.AccessDeniedPath = "/Login";
        config.LoginPath = "/Login";
        
        // config.ExpireTimeSpan = TimeSpan.FromHours(18);
        // config.Cookie.MaxAge = config.ExpireTimeSpan; // optional
        // config.SlidingExpiration = true;
    });
builder.Services.AddSession(options =>
{
    options.Cookie.IsEssential = true; // This is required for the session to work
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.Run();