using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using FiGroup.TodoList.Api.Application.Contracts;
using FiGroup.TodoList.Api.Domain.Entities;
using FiGroup.TodoList.Api.DTOs;

namespace FiGroup.TodoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoAppService _todoAppService;

        public TodoController(ITodoAppService todoAppService)
        {
            _todoAppService = todoAppService;
        }

        [HttpPost]
        public async Task<ActionResult> save(RequestTodo todo)
        {
            var result = await _todoAppService.save(todo);

            if (result.Ok)
                return Ok(result);
            else
                return StatusCode(500, result);
        }

        [HttpGet]
        public async Task<ActionResult> get()
        {
            var result = await _todoAppService.get();
            if (result.Ok)
                return Ok(result);
            else
                return StatusCode(500, result);

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> get(Guid id)
        {
            var result = await _todoAppService.get(id);

            if (result.Ok)
                return Ok(result);
            else
                return StatusCode(500, result);
        }

        [HttpGet]
        [Route("search/{title}")]
        public async Task<ActionResult> get(string title)
        {
            var result = await _todoAppService.get(title);

            if (result.Ok)
                return Ok(result);
            else
                return StatusCode(500, result);
        }

        [HttpDelete]
        public async Task<ActionResult> delete(RequestTodo todo)
        {
            var result = await _todoAppService.delete(todo);

            if (result.Ok)
                return Ok(result);
            else
                return StatusCode(500, result);
        }

    }
}
