// using Codifico.StoreSample.Api.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiGroup.TodoList.Api.Repository;
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

            // services.AddTransient<EmployeesRepository>();

            // services.AddTransient<EmployeesDomainService>();

            // services.AddTransient<IEmployeesAppService, EmployeesAppService>();

        }
    }
}
