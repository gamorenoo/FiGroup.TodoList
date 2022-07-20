using System;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using FiGroup.TodoList.Api.Domain.Entities;
using FiGroup.TodoList.Api.Repository.IRepository;
using FiGroup.TodoList.Api.Application.Contracts;
using FiGroup.TodoList.Api.Domain.Services.Contracts;
using FiGroup.TodoList.Api.DTOs;

namespace FiGroup.TodoList.Api.Application
{
    public class TodoAppService: ITodoAppService
    {
        private readonly IMapper _mapper;
        private readonly ITodoDomainService _todoDomainService;

        public TodoAppService(IMapper mapper, ITodoDomainService todoDomainService)
        {
            _mapper = mapper;
            _todoDomainService = todoDomainService;
        }

        public async Task<ResponseGeneric<RequestTodo>> save(RequestTodo requestTodo)
        {
            try
            {
                var todo = _mapper.Map<Todo>(requestTodo);
                var result = await _todoDomainService.save(todo);

                return ResponseGeneric<RequestTodo>.CreateResponseOk(_mapper.Map<RequestTodo>(result));
            }
            catch (Exception ex)
            {
                return ResponseGeneric<RequestTodo>.CreateResponseError(ex.Message);
            }
        }

        public async Task<ResponseGeneric<RequestTodo>> get(Guid Id)
        {
            try
            {
                var result = await _todoDomainService.get(Id);

                return ResponseGeneric<RequestTodo>.CreateResponseOk(_mapper.Map<RequestTodo>(result));
            }
            catch (Exception ex)
            {
                return ResponseGeneric<RequestTodo>.CreateResponseError(ex.Message);
            }
        }

        public async Task<ResponseGeneric<List<RequestTodo>>> get()
        {
            try
            {
                var result = await _todoDomainService.get();

                return ResponseGeneric<List<RequestTodo>>.CreateResponseOk(_mapper.Map<List<RequestTodo>>(result));
            }
            catch (Exception ex)
            {
                return ResponseGeneric<List<RequestTodo>>.CreateResponseError(ex.Message);
            }
        }

        public async Task<ResponseGeneric<List<RequestTodo>>> get(string title)
        {
            try
            {
                var result = await _todoDomainService.get(title);

                return ResponseGeneric<List<RequestTodo>>.CreateResponseOk(_mapper.Map<List<RequestTodo>>(result));
            }
            catch (Exception ex)
            {
                return ResponseGeneric<List<RequestTodo>>.CreateResponseError(ex.Message);
            }
        }

        public async Task<ResponseGeneric<bool>> delete(RequestTodo requestTodo)
        {
            try
            {
                var todo = _mapper.Map<Todo>(requestTodo);
                var result = await _todoDomainService.delete(todo);

                return ResponseGeneric<bool>.CreateResponseOk(result);
            }
            catch (Exception ex)
            {
                return ResponseGeneric<bool>.CreateResponseError(ex.Message);
            }
        }

    }
}
