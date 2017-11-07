using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TMS3.Library.Interfaces;
using Microsoft.Extensions.Logging;
using TMS3.Library.Entities;
using TMS3.Web.ViewModels;

namespace TMS3.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Tasks")]
    public class TasksController : Controller
    {
        private IRepository<Task> _taskRepository;
        private ILogger<TasksController> _logger;

        public TasksController(IRepository<Task> taskRepository, ILogger<TasksController> logger)
        {
            _taskRepository = taskRepository;
            _logger = logger;
        }

        public IActionResult Get()
        {
            try
            {
                var tasks = _taskRepository.GetAll();

                return Ok(tasks.Entities);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error in Task API: {ex}");
                return BadRequest();
            }
        }
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var task = _taskRepository.SingleEntity(s=>s.TaskNumber==id);

                if (task != null) return Ok(task);
                else return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in Task API: {ex}");
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Task newTask)
        {
            try
            {
              var response=  _taskRepository.Add(newTask);
                if (response.NoErrors)
                    return Created($"/api/task/{newTask.TaskNumber}", newTask);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Failed to create new task : {ex}");
            }

            return BadRequest("Failed to Create task");
        }


        [HttpPost("search")]
        public IActionResult GetTaskList([FromBody] TaskSearchParameters search)
        {
            try
            {
                var response = _taskRepository.Find(r => (string.IsNullOrEmpty(search.TaskName) || r.TaskName == search.TaskName) && (search.TaskNumber == null || r.TaskNumber == (int)search.TaskNumber));
                if (response.NoErrors)
                    return Ok(response.Entities.ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to create new task : {ex}");
            }

            return BadRequest("Failed to get data");
        }
    }
}