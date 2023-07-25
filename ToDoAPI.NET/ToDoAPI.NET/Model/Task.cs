using ToDoAPI.NET.Validation;

namespace ToDoAPI.NET.Model
{
    public sealed class Task
    {
        public int Id { get; private set; }
        public string TaskName { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public DateTime StartDate { get; private set; } = DateTime.UtcNow;
        public TaskStatus TaskStatus { get; private set; }

        public Task(int id, string taskName, string description, DateTime startDate, TaskStatus taskStatus)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id");
            ValidateDomain(taskName, description, startDate, taskStatus);
        }

        private void ValidateDomain(string taskName, string description, DateTime startDate, TaskStatus taskStatus)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(taskName), "Task name cannot be null");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Description cannot be null");
            DomainExceptionValidation.When(startDate < DateTime.Today, "Start date cannot be minor than today");

            TaskName = taskName;
            Description = description;
            StartDate = startDate;
            TaskStatus = taskStatus;
        }
    }
}
