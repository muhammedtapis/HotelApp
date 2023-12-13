using Hotel.API.Filters;
using Hotel.Repository;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using Hotel.API.Modules;
using Hotel.API.Middlewares;
using Hotel.Service.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers(options => options.Filters.Add(new ValidateFilterAttribute())).
//    .AddFluentValidationAutoValidation(x => x.RegisterValidatorsFromAssemblyContaining<CustomerDTOValidator>());

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext))?.GetName().Name); //migration dosyas� olu�acak yerin adresini verdik.
    });
});

//filter tan�mlamas� yapt�k ��nk� bu filter ctor da interface al�yo
builder.Services.AddScoped(typeof(NotFoundFilter<,>));
//Mapleme tan�t�m�
builder.Services.AddAutoMapper(typeof(MapProfile));  //assembly de verebiliriz biz type of verdik.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()); //indirdi�imiz autofac k�t�phanesi
//ard�ndan bir mod�l ekleyece�iz bu mod�l i�erisinde dinamik olarak ekleme  i�lemleri yapaca��z bu mod�l� de burada ekledik.
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCustomException();
app.UseAuthorization();

app.MapControllers();

app.Run();