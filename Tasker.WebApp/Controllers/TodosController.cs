using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tasker.Model;
using Tasker.Repository;

namespace Tasker.React
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

        [HttpGet("{Id}")]
        public ActionResult<Todo> Get(int Id)
        {
            return _unitOfWork.TaskerRepository.Get(Id);
        }

        [HttpPost]
        public ActionResult<Todo> Post(Todo todo)
        {
            _unitOfWork.TaskerRepository.Add(todo);
            _unitOfWork.Save();
            return todo;
        }

        [HttpPut("{Id}")]
        public ActionResult<Todo> Put(int Id,Todo todo)
        {
            if (Id != todo.Id)
            {
                return BadRequest();
            }
            _unitOfWork.TaskerRepository.Update(todo);
            _unitOfWork.Save();
            return todo;
        }

        [HttpDelete("{Id}")]
        public ActionResult<Todo> Delete(int Id)
        {
            var todoToDelete =_unitOfWork.TaskerRepository.Delete(Id);
            _unitOfWork.Save();
            return todoToDelete;
        }


    }
}
