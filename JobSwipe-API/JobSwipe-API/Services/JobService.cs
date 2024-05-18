using JobSwipe_API.Data;
using JobSwipe_API.Models;
using JobSwipe_API.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobSwipe_API.Services
{
    public interface IJobService
    {
        Task<Job> CreateJob(JobDTO jobDto);
        Task<ActionResult<IEnumerable<Job>>> GetAllJobs();
        Task<ActionResult<Job?>> GetJob(Guid id);
        Task<List<Job>> GetMatchingJobs(PrivateUser user);
        Task<Job?> UpdateJob(Guid id, JobDTO jobDto);
    }
    public class JobService(ApplicationDbContext context) : IJobService
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<ActionResult<IEnumerable<Job>>> GetAllJobs()
        {
            return await _context.Jobs
                .Include(j => j.RequiredSkills)
                .ToListAsync();
        }

        public async Task<ActionResult<Job?>> GetJob(Guid id)
        {
            var job = await _context.Jobs
                .Include(j => j.RequiredSkills)
                .FirstOrDefaultAsync(j => j.Id == id);
            return job;
        }

        public async Task<List<Job>> GetMatchingJobs(PrivateUser user)
        {
            return await _context.Jobs
            .Select(job => new
            {
                Job = job,
                MatchingSkillsCount = job.RequiredSkills.Count(rs => user.Skills.Any(us => us.Id == rs.Id))
            })
            .Where(x => x.MatchingSkillsCount > 0)
            .OrderByDescending(x => x.MatchingSkillsCount)
            .Select(x => x.Job)
            .ToListAsync();
        }

        private bool JobExists(Guid id)
        {
            return _context.Jobs.Any(e => e.Id == id);
        }

        // Create job
        public async Task<Job> CreateJob(JobDTO jobDto)
        {

            var job = new Job
            {
                Id = Guid.NewGuid(),
                Title = jobDto.Title,
                Description = jobDto.Description,
                CompanyId = Guid.Parse(jobDto.CompanyId),
                RequiredSkills = jobDto.RequiredSkills,
                Location = jobDto.Location,
                Salary = jobDto.Salary ?? "",
                FinalApplicationDate = jobDto.FinalApplicationDate,
                CompanyUrl = jobDto.CompanyUrl,
                OptionalSkills = jobDto.OptionalSkills ?? []
            };
            _context.Jobs.Add(job);
            await _context.SaveChangesAsync();

            return job;
        }

        public async Task<Job?> UpdateJob(Guid id, JobDTO jobDto)
        {
            var job = await _context.Jobs.FindAsync(id);

            if (job == null)
            {
                return null;
            }

            job.Title = jobDto.Title;
            job.Description = jobDto.Description;
            job.CompanyId = Guid.Parse(jobDto.CompanyId);
            job.RequiredSkills = jobDto.RequiredSkills;
            job.Location = jobDto.Location;
            job.Salary = jobDto.Salary ?? "";
            job.FinalApplicationDate = jobDto.FinalApplicationDate;
            job.CompanyUrl = jobDto.CompanyUrl;
            job.OptionalSkills = jobDto.OptionalSkills ?? [];

            _context.Entry(job).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return job;
        }

    }


}
