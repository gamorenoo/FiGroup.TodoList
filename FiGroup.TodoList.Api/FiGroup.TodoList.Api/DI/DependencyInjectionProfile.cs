// using Codifico.StoreSample.Api.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiGroup.TodoList.Api.Repository;
using FiGroup.TodoList.Api.Repository.IRepository;
using FiGroup.TodoList.Api.Application.Contracts;
using FiGroup.TodoList.Api.Application;
using FiGroup.TodoList.Api.Domain.Services.Contracts;
using FiGroup.TodoList.Api.Domain.Services;
//using Codifico.TodoList.Api.Domain.Services;
//using Codifico.TodoList.Api.Application.Services;
//using Codifico.TodoList.Api.Application.Contracts;

namespace Codifico.StoreSample.Api.DI
{
    public class DependencyInjectionProfile
    {
        private readonly IConfiguration Configuration;
        public DependencyInjectionProfile(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void InjectDependencies(IServiceCollection services)
        {
            services.AddDbContext<TodoListDBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<ITodoRepository, TodoRepository>();

            services.AddTransient<ITodoAppService, TodoAppService>();

            services.AddTransient<ITodoDomainService, TodoDomainService>();

        }
    }
}
