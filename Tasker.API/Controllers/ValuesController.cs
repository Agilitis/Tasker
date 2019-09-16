using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tasker.DataAccessLayer;
using Tasker.Model;

namespace Tasker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly TaskerContext _context;

        public ValuesController(TaskerContext context)
        {
            _context = context;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Task>> Get()
        {
            var myTask = new Task("Title", "desc", DateTime.Now, TaskState.Doing, 2);
            _context.Add(myTask);
            _context.SaveChanges();
            return _context.Tasks;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
