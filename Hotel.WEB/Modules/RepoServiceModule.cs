using Autofac;
using Module = Autofac.Module;
using Hotel.Core.Repositories;
using Hotel.Core.Services;
using Hotel.Core.UnitOfWorks;
using Hotel.Repository.Repositories;
using Hotel.Repository.UnitOfWorks;
using Hotel.Repository;
using Hotel.Service.Mapping;
using Hotel.Service.Services;
using System.Reflection;

namespace Hotel.WEB.Modules
{
    public class RepoServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //program.cs te eklediğimiz scopeları artık burda yapıyoruz ordan sileceğiz.

            //generic olan ekleme
            //builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();

            //ServiceWithDTO interface impl. bu generic servis interface iki tane generic tip aldığı için < arasına bir virgül koymak gerek>
            builder.RegisterGeneric(typeof(ServiceWithDTO<,>)).As(typeof(IServiceWithDTO<,>)).InstancePerLifetimeScope();

            //generic olmayan ekleme
            //builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            //DTO dönen servisin Dependency injectionu
            builder.RegisterType<RoomServiceWithDTO>().As<IRoomServiceWithDTO>().InstancePerLifetimeScope();

            //customer service injection
            builder.RegisterType<CustomerServiceWithDTO>().As<ICustomerServiceWithDTO>().InstancePerLifetimeScope();

            builder.RegisterType<FloorServiceWithDTO>().As<IFloorServiceWithDTO>().InstancePerLifetimeScope();

            var apiAssembly = Assembly.GetExecutingAssembly(); //apinin assemblysi
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext)); //repository katmanında herhangi bir classı verdik ordan assmbly bilgisi alcaz.
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile)); //aynı şekilde servis katmanında da assembly bilgisine eriştik

            //bu aşağıdaki kod program.cs te addcsope yaptığımız kodları kısaltıyor asemmblylere gidip sonu Repository ile biten classları alııyor.
            //daha sonra onların interfacelerini de implemente ediyor.
            //builder.Services.AddScoped<ICategoryRepository, CategoryRepository>(); bu satırdaki işi yapıyor ama tek seferde bütün Repository olanlar için
            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly!, serviceAssembly!).Where(x => x.Name.EndsWith("Repository"))
                   .AsImplementedInterfaces().InstancePerLifetimeScope();
            //InstancePerLifetimeScope() => AddScoped(); request bitene kadar aynı instance kullanılır
            //InstancePerDependency() => AddTransient(); herhangi bir classın constructorında o interface nerde geçildiyse her seferinde yeni instance oluşur.
            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly!, serviceAssembly!).Where(x => x.Name.EndsWith("Service"))
                   .AsImplementedInterfaces().InstancePerLifetimeScope();

            //Cacheten işlem yapan servisi baz al IProductService görürsen.
            //builder.RegisterType<ProductServiceWithCaching>().As<IProductService>().InstancePerLifetimeScope();
        }
    }
}