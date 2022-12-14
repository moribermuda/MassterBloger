using MB.Infrastructure.Core;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
//builder.Services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
//builder.Services.AddDbContext<MasterBloggContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("MasterBlogDb")));
BootStrapper.Config(builder.Services, builder.Configuration.GetConnectionString("MasterBloggDB"));
builder.Services.AddRazorPages();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapDefaultControllerRoute();
app.MapRazorPages();
app.Run();
