using Xunit;
using Moq;
using Tasker.Repository;
using Tasker.Model;
using Microsoft.EntityFrameworkCore;
using Tasker.DataAccessLayer;
using System;

namespace Tasker.Tests
{
    public class RepositoryUnitTests
    {
        public TodoContext context { get; set; }
        public IUnitOfWork unitOfWork { get; set; }

        public RepositoryUnitTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<TodoContext>();
            optionsBuilder.UseInMemoryDatabase("MyDatabase");
            context = new TodoContext(optionsBuilder.Options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            unitOfWork = new UnitOfWork(context);
            unitOfWork.TaskerRepository.Add(new Todo
            {
                Deadline = DateTime.Now,
                Description = "test",
                Id = 1,
                Priority = 1,
                State = TodoState.Doing,
                Title = "test"
            });
            unitOfWork.Save();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(12314124)]
        public void TestDeleteNonExsistentItem(int todoId)
        {

            //act
            unitOfWork.TaskerRepository.Delete(todoId);
            unitOfWork.Save();

            //assert
            var todo = unitOfWork.TaskerRepository.Get(todoId);
            Assert.Null(todo);
        }
    }
}
