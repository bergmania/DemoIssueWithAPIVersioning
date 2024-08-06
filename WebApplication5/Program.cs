using WebApplication5;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// I ADDED HERE START
builder.Services.AddApiVersioning(x=>x.AssumeDefaultVersionWhenUnspecified = true).AddApiExplorer();
builder.Services.AddSingleton<MyDynamicControllerRoute>();
// I ADDED HERE END


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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// I ADDED HERE START
app.MapDynamicControllerRoute<MyDynamicControllerRoute>("/{**slug}");
// I ADDED HERE END

app.Run();

