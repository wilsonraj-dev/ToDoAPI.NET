using ToDoAPI.NET.Model.Entitys;
using ToDoAPI.NET.Validations.Interfaces;

namespace ToDoAPI.NET.Validations.Services
{
    public class ValidateStatusJobs : IValidateStatusJobs
    {
        public void ValidateInsertJob(JobStatus jobStatus)
        {
            if (jobStatus == JobStatus.Finish || jobStatus == JobStatus.Canceled)
            {
                throw new Exception("You cannot add a Job with status Finish or Canceled!");
            }
        }

        public void ValidateUpdateJob(JobStatus currentJobStatus, JobStatus newJobStatus)
        {
            if (currentJobStatus == JobStatus.Backlog && (newJobStatus == JobStatus.Finish || newJobStatus == JobStatus.Canceled))
            {
                throw new Exception("You cannot change JobStatus the Backlog to Finish ou Canceled");
            }
            else if (currentJobStatus == JobStatus.InProgress && newJobStatus == JobStatus.Backlog)
            {
                throw new Exception("You cannot change JobStatus the Progress to Backlog");
            }
            else if (currentJobStatus == JobStatus.Canceled && newJobStatus != JobStatus.Canceled)
            {
                throw new Exception("You cannot change JobStatus Canceled to another status");
            }
        }
    }
}
