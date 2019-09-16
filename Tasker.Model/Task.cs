using System;
using System.Collections.Generic;
using System.Text;

namespace Tasker.Model
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public TaskState  State { get; set; }
        public int Priority { get; set; }
        public Task(string title, string description, DateTime deadline, TaskState state, int priority)
        {
            this.Deadline = deadline;
            this.Title = title;
            this.Description = description;
            this.State = state;
            this.Priority = priority;
        }

    }
}
