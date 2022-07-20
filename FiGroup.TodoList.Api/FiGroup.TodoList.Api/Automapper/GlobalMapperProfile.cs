using AutoMapper;
using FiGroup.TodoList.Api.DTOs;
using FiGroup.TodoList.Api.Domain.Entities;

namespace FiGroup.TodoList.Api.Automapper
{
    public class GlobalMapperProfile : Profile
    {
        public GlobalMapperProfile() : base()
        {
            CreateMap<RequestTodo, Todo>();

            CreateMap<Todo, RequestTodo>();
        }
    }
}
