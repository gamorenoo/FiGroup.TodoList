using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiGroup.TodoList.Api.DTOs
{
    public class RequestTodo
    {
        public Guid? Id { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public bool Status { get; set; }
    }
}
