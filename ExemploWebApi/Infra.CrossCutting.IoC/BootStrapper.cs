using Aplication;
using Aplication.Interface;
using Domain.Interfaces;
using Domain.Interfaces.Services;
using Domain.Services;
using Infra.Repositories;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static Container Start()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            //Application
            container.Register<ICategoryAppService, CategoryAppService>(Lifestyle.Scoped);
            container.Register<IProductAppService, ProductAppService>(Lifestyle.Scoped);

            //Domain
            container.Register<ICategoryService, CategoryService>(Lifestyle.Scoped);
            container.Register<IProductService, ProductService>(Lifestyle.Scoped);

            //Infra
            container.Register<ICategoryRepository, CategoryRepository>(Lifestyle.Scoped);
            container.Register<IProductRepository, ProductRepository>(Lifestyle.Scoped);

            // This is an extension method from the integration package.

            return container;
        }
    }
}
