using ToDoAPI.NET.Validation;

namespace ToDoAPI.NET.Model.Entitys
{
    public sealed class Job
    {
        public int Id { get; private set; }
        public string JobName { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public DateTime StartDate { get; private set; } = DateTime.UtcNow;
        public JobStatus JobStatus { get; private set; }

        public Job(int id, string jobName, string description, DateTime startDate, JobStatus jobStatus)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id");
            ValidateDomain(jobName, description, startDate, jobStatus);
        }

        private void ValidateDomain(string jobName, string description, DateTime startDate, JobStatus jobStatus)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(jobName), "Job name cannot be null.");
            DomainExceptionValidation.When(jobName.Length > 50, "Job name cannot be bigger than 50 caracter.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Description cannot be null.");
            DomainExceptionValidation.When(description.Length > 100, "Description cannot be bigger than 100 caracter.");
            DomainExceptionValidation.When(startDate < DateTime.Today, "Start date cannot be minor than today.");

            JobName = jobName;
            Description = description;
            StartDate = startDate;
            JobStatus = jobStatus;
        }
    }
}
