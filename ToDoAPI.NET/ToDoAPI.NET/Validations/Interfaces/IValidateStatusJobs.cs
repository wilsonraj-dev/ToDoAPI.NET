using ToDoAPI.NET.Model.Entitys;

namespace ToDoAPI.NET.Validations.Interfaces
{
    public interface IValidateStatusJobs
    {
        void ValidateInsertJob(JobStatus jobStatus);
        void ValidateUpdateJob(JobStatus currentJobStatus, JobStatus newJobStatus);
    }
}
