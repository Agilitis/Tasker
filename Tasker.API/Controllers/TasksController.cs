using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tasker.Model;
using Tasker.Repository;

namespace Tasker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;


        public TasksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Task> Get()
        {
            return _unitOfWork.TaskerRepository.GetAllTasks();
        }


    }
}
