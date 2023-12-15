using Autofac;
using Autofac.Extensions.DependencyInjection;
using Hotel.Repository;
using Hotel.WEB.Modules;
using Hotel.WEB.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext))?.GetName().Name); //migration dosyasý oluþacak yerin adresini verdik.
    });
});
//api ile haberleþme için
builder.Services.AddHttpClient<CustomerAPIService>(opt =>
{
    opt.BaseAddress = new Uri(builder.Configuration["BaseUrl"]!);
});
builder.Services.AddHttpClient<RoomAPIService>(opt =>
{
    opt.BaseAddress = new Uri(builder.Configuration["BaseUrl"]!);
});

//autofac Dependency Injection container!!!! program.cs içinde yaptýðýmýz dependency injectionlarý artýk yeni modülümüzde yapcaz.
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()); //indirdiðimiz autofac kütüphanesi
//ardýndan bir modül ekleyeceðiz bu modül içerisinde dinamik olarak ekleme  iþlemleri yapacaðýz bu modülü de burada ekledik.
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));
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

app.Run();