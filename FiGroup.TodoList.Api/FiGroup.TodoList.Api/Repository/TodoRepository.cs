using FiGroup.TodoList.Api.Domain.Entities;
using FiGroup.TodoList.Api.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiGroup.TodoList.Api.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly IGenericRepository<Todo> _todoRepository;

        public TodoRepository(IGenericRepository<Todo> todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<Todo> save(Todo todo) {
            if (todo.Id.Equals(Guid.Empty))
            {
                todo = await _todoRepository.Add(todo);
            }
            else {
                todo = await _todoRepository.Update(todo);
            }
            
            return todo;
        }

        public async Task<Todo> get(Guid Id)
        {
            var result = await _todoRepository.GetList(t => t.Id.Equals(Id));

            return result.FirstOrDefault();
        }

        public async Task<List<Todo>> get()
        {
            return await _todoRepository.GetList();
        }

        public async Task<List<Todo>> get(string title)
        {
            return await _todoRepository.GetList(t => t.Title.Contains(title));
        }

        public async Task<bool> delete(Todo todo)
        {
            await _todoRepository.Delete(todo);
            return true;
        }
    }
}
