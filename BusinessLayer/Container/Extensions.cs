using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Container
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAdminService, AdminManager>();
            services.AddScoped<IAdminDal, EfAdminDal>();

            services.AddScoped<IAuthorService, AuthorManager>();
            services.AddScoped<IAuthorDal, EfAuthorDal>();

            services.AddScoped<IAuthorsWordService, AuthorsWordManager>();
            services.AddScoped<IAuthorsWordDal, EfAuthorsWordDal>();

            services.AddScoped<IBookService, BookManager>();
            services.AddScoped<IBookDal, EfBookDal>();

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();

            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IContactDal, EfContactDal>();
        }
    }
}
