using FiGroup.TodoList.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiGroup.TodoList.Api.Repository.IRepository
{
    public interface ITodoRepository
    {
        Task<Todo> save(Todo todo);
        Task<Todo> get(Guid Id);
        Task<List<Todo>> get();
        Task<List<Todo>> get(string title);
        Task<bool> delete(Todo todo);
    }
}
