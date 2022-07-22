using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using FiGroup.TodoList.Api.Domain.Services.Contracts;
using FiGroup.TodoList.Api.Repository.IRepository;
using FiGroup.TodoList.Api.Domain.Entities;

namespace FiGroup.TodoList.Api.Domain.Services
{
    public class TodoDomainService: ITodoDomainService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoDomainService(ITodoRepository todoRepository) {
            _todoRepository = todoRepository;
        }

        public async Task<Todo> save(Todo todo)
        {
            return await _todoRepository.save(todo);
        }
        
        public async Task<Todo> get(Guid Id) 
        {
            return await _todoRepository.get(Id);
        }
        
        public async Task<List<Todo>> get()
        {
            return await _todoRepository.get();
        }
        
        public async Task<List<Todo>> get(string title) 
        {
            return await _todoRepository.get(title);
        }

        public async Task<bool> delete(Guid Id)
        {
            return await _todoRepository.delete(Id);
        }
    }
}
