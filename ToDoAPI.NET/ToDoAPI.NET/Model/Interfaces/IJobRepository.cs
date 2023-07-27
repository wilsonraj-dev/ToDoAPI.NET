using ToDoAPI.NET.Model.Entitys;

namespace ToDoAPI.NET.Interfaces
{
    public interface IJobRepository
    {
        Task<IEnumerable<Job>> GetAllJobsAsync();
        Task<IEnumerable<Job>> GetJobsWithStatusAsync(JobStatus jobStatus);
        Task<Job> GetJobByIdAsync(int? id);
        Task<JobStatus> GetJobStatus(Job job);
        Task<Job> CreateAsync(Job job);
        Task<Job> UpdateAsync(Job job);
        Task<Job> DeleteAsync(Job job);
    }
}
