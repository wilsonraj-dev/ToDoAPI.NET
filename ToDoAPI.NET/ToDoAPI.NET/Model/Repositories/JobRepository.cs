using Microsoft.EntityFrameworkCore;
using ToDoAPI.NET.Context;
using ToDoAPI.NET.Interfaces;
using ToDoAPI.NET.Model.Entitys;

namespace ToDoAPI.NET.Model.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly AppDbContext _context;

        public JobRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Job>> GetAllJobsAsync()
        {
            return await _context.Jobs.ToListAsync();
        }

        public async Task<IEnumerable<Job>> GetJobsWithStatusAsync(JobStatus jobStatus)
        {
            return await _context.Jobs.Where(x => x.JobStatus == jobStatus).ToListAsync();
        }

        public async Task<Job> GetJobByIdAsync(int? id)
        {
            return await _context.Jobs.FindAsync(id) ?? throw new ArgumentNullException();
        }

        public async Task<Job> CreateAsync(Job job)
        {
            _context.Add(job);
            await _context.SaveChangesAsync();
            return job;
        }

        public async Task<Job> UpdateAsync(Job job)
        {
            _context.Update(job);
            await _context.SaveChangesAsync();
            return job;
        }

        public async Task<Job> DeleteAsync(Job job)
        {
            _context.Remove(job);
            await _context.SaveChangesAsync();
            return job;
        }
    }
}
