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
        public ActionResult<Todo> Get(int id)
        {
            return _unitOfWork.TaskerRepository.Get(id);
        }

        [HttpPost]
        public ActionResult<Todo> Post(Todo todo)
        {
            _unitOfWork.TaskerRepository.Add(todo);
            _unitOfWork.Save();
            return todo;
        }

        [HttpPut("{Id}")]
        public ActionResult<Todo> Put(int id,Todo todo)
        {
            if (id != todo.Id)
            {
                return BadRequest();
            }
            _unitOfWork.TaskerRepository.Update(todo);
            _unitOfWork.Save();
            return todo;
        }

        [HttpDelete("{Id}")]
        public ActionResult Delete(int id)
        {
            if (_unitOfWork.TaskerRepository.Get(id) != null)
            {
                _unitOfWork.TaskerRepository.Delete(id);
                _unitOfWork.Save();
                return Ok();
            }
            else
            {
                return NotFound();
            }
            
        }


    }
}
