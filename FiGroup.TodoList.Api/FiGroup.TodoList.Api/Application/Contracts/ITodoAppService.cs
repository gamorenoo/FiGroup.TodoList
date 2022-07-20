using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using FiGroup.TodoList.Api.Domain.Entities;
using FiGroup.TodoList.Api.DTOs;

namespace FiGroup.TodoList.Api.Application.Contracts
{
    public interface ITodoAppService
    {
        Task<ResponseGeneric<RequestTodo>> save(RequestTodo todo);
        Task<ResponseGeneric<RequestTodo>> get(Guid Id);
        Task<ResponseGeneric<List<RequestTodo>>> get();
        Task<ResponseGeneric<List<RequestTodo>>> get(string title);
        Task<ResponseGeneric<bool>> delete(RequestTodo todo);
    }
}
