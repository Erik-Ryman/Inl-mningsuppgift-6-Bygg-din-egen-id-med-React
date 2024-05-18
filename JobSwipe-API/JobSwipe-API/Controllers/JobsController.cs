using Microsoft.AspNetCore.Mvc;
using JobSwipe_API.Data;
using JobSwipe_API.Models;
using Microsoft.AspNetCore.Authorization;
using JobSwipe_API.Models.DTO;
using JobSwipe_API.Services;

namespace JobSwipe_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Private, Admin")]
    public class JobsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IJobService _jobService;

        public JobsController(ApplicationDbContext context, IJobService jobService)
        {
            _context = context;
            _jobService = jobService;
        }

        // GET: api/Jobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Job>>> GetJob()
        {
            return await _jobService.GetAllJobs();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Job?>> GetJob(Guid id)
        {
            var job = await _jobService.GetJob(id);

            if (job == null)
            {
                return NotFound();
            }

            return job;
        }

        [HttpGet("matchingJobs")]
        public async Task<List<Job>> GetMatchingJobs(PrivateUser user)
        {
            return await _jobService.GetMatchingJobs(user);
        }

        // PUT: api/Jobs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJob(Guid id, JobDTO job)
        {
            var result = await _jobService.UpdateJob(id, job);
            if (result == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // POST: api/Jobs
        [HttpPost]
        public async Task<ActionResult<Job>> PostJob(JobDTO jobDto)
        {
            var job = await _jobService.CreateJob(jobDto);
            if (job == null)
            {
                return BadRequest();
            }

            return CreatedAtAction("GetJob", new { id = job.Id }, job);
        }

        // DELETE: api/Jobs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob(Guid id)
        {
            var job = await _context.Jobs.FindAsync(id);
            if (job == null)
            {
                return NotFound();
            }

            _context.Jobs.Remove(job);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
