using System;
using System.Collections.Generic;
using System.Text;

namespace Tasker.Model
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public TodoState  State { get; set; }
        public int Priority { get; set; }
        public Todo(int id, string title, string description, DateTime deadline, TodoState state, int priority)
        {
            this.Id = id;
            this.Deadline = deadline;
            this.Title = title;
            this.Description = description;
            this.State = state;
            this.Priority = priority;
        }

        public Todo()
        {

        }

    }
}
