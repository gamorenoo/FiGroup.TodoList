using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiGroup.TodoList.Api.Domain.Entities
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public bool Status { get; set; }
    }
}
