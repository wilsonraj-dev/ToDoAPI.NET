using Microsoft.AspNetCore.Mvc;
using ToDoAPI.NET.Interfaces;
using ToDoAPI.NET.Model.Entitys;
using ToDoAPI.NET.Model.Repositories;
using ToDoAPI.NET.Validations.Interfaces;

namespace ToDoAPI.NET.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobRepository _jobRepository;
        private readonly IValidateStatusJobs _validateInsertJobs;

        public JobsController(IJobRepository jobRepository, IValidateStatusJobs validateInsertJobs)
        {
            _jobRepository = jobRepository;
            _validateInsertJobs = validateInsertJobs;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Job>>> GetAllJobs()
        {
            var jobs = await _jobRepository.GetAllJobsAsync();

            if (jobs == null)
                return NotFound("No jobs found, try again please!");

            return Ok(jobs);
        }

        [HttpGet("getStatusJobs/{jobStatus:int}", Name = "GetStatusJobs")]
        public async Task<ActionResult<IEnumerable<Job>>> GetJobWithStatus(JobStatus jobStatus)
        {
            var jobs = await _jobRepository.GetJobsWithStatusAsync(jobStatus);

            if (jobs == null)
                return NotFound($"No jobs with status {jobStatus} found!");

            return Ok(jobs);
        }

        [HttpGet("getJobById/{id:int}", Name = "GetJobId")]
        public async Task<ActionResult<Job>> GetJobById(int id)
        {
            var job = await _jobRepository.GetJobByIdAsync(id);

            if (job == null)
                return NotFound($"No job with Id {id} found!");

            return Ok(job);
        }

        [HttpPost(Name = "CreateJob")]
        public async Task<ActionResult<Job>> CreateJob([FromBody] Job job)
        {
            if (job == null)
            {
                return BadRequest("Invalid value entered!!");
            }

            _validateInsertJobs.ValidateInsertJob(job.JobStatus);

            await _jobRepository.CreateAsync(job);
            return Ok(job);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Job>> UpdateJob([FromBody] Job job, int id)
        {
            if (job.Id != id)
            {
                return BadRequest("Invalid value entered, the Id specified doesn't exist!!");
            }
            else if (job == null)
            {
                return NotFound($"No job with Id {id} found!");
            }
            else if (!Enum.IsDefined(typeof(JobStatus), job.JobStatus))
            {
                return BadRequest("The informed status doesn't not exists. Try a new value!");
            }

            _validateInsertJobs.ValidateUpdateJob(await _jobRepository.GetJobStatus(job), job.JobStatus);
            await _jobRepository.UpdateAsync(job);
            return Ok(job);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Job>> DeleteJob(int? id)
        {
            if (id == null || id < 0)
            {
                return NotFound($"No job with Id {id} found!");
            }

            var job = await _jobRepository.GetJobByIdAsync(id);
            await _jobRepository.DeleteAsync(job);
            return NoContent();
        }
    }
}
