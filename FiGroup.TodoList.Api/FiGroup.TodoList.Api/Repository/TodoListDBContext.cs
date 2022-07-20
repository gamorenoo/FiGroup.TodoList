using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiGroup.TodoList.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FiGroup.TodoList.Api.Repository
{
    public class TodoListDBContext : DbContext
    {
        public TodoListDBContext(DbContextOptions<TodoListDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
