using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tasker.Model;
using Tasker.Repository;

namespace Tasker.API.Controllers
{
    [Route("api/todos")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;


        public TodosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Todo> Get()
        {
            return _unitOfWork.TaskerRepository.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult<Todo>> Post(Todo todo)
        {
            _unitOfWork.TaskerRepository.Add(todo);
            _unitOfWork.Save();
            return todo;
        }


    }
}
