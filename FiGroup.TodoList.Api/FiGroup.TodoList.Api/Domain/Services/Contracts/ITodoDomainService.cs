using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using FiGroup.TodoList.Api.Domain.Entities;


namespace FiGroup.TodoList.Api.Domain.Services.Contracts
{
    public interface ITodoDomainService
    {
        Task<Todo> save(Todo todo);
        Task<Todo> get(Guid Id);
        Task<List<Todo>> get();
        Task<List<Todo>> get(string title);
        Task<bool> delete(Guid Id);
    }
}
