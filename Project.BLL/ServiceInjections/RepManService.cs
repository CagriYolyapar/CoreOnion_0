using Microsoft.Extensions.DependencyInjection;
using Project.BLL.ManagerServices.Abstracts;
using Project.BLL.ManagerServices.Concretes;
using Project.DAL.Repositories.Abstracts;
using Project.DAL.Repositories.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ServiceInjections
{
    public static class RepManService
    {
        public static IServiceCollection AddRepManServices(this IServiceCollection services)
        {
            //Repositories

            //Scoped,Transient,Singleton

            services.AddScoped(typeof(IRepository<>),typeof(BaseRepository<>));

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IAppUserRepository, AppUserRepository>();




            //Managers

            services.AddScoped(typeof(IManager<>), typeof(BaseManager<>));

            services.AddScoped<IProductManager, ProductManager>();
            services.AddScoped<ICategoryManager, CategoryManager>();
            services.AddScoped<IOrderDetailManager, OrderDetailManager>();
            services.AddScoped<IOrderManager, OrderManager>();
            services.AddScoped<IAppUserManager, AppUserManager>();
            services.AddScoped<IProfileManager, ProfileManager>();

            return services;

        }
    }
}
