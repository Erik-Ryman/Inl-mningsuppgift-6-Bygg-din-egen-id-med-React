using Microsoft.EntityFrameworkCore;
using JobSwipe_API.Models;
using JobSwipe_API.Models.DTO.Auth;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Net.Mime.MediaTypeNames;

namespace JobSwipe_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            var companyId = "7479a49d-e9b1-4179-a2db-6a7d64faa0c7";

            // guid parse strings to use as skillId / jobId
            var skillId1 = Guid.Parse("bb4359b0-d8c2-479f-9397-4ce96ecc3459");
            var skillId2 = Guid.Parse("bb4359b0-d8c2-479f-9397-4ce96ecc3460");
            var skillId3 = Guid.Parse("bb4359b0-d8c2-479f-9397-4ce96ecc3461");
            var skillId4 = Guid.Parse("bb4359b0-d8c2-479f-9397-4ce96ecc3462");
            var skillId5 = Guid.Parse("bb4359b0-d8c2-479f-9397-4ce96ecc3463");
            var skillId6 = Guid.Parse("bb4359b0-d8c2-479f-9397-4ce96ecc3464");
            var skillId7 = Guid.Parse("bb4359b0-d8c2-479f-9397-4ce96ecc3465");
            var skillId8 = Guid.Parse("bb4359b0-d8c2-479f-9397-4ce96ecc3466");
            var skillId9 = Guid.Parse("bb4359b0-d8c2-479f-9397-4ce96ecc3467");
            var skillId10 = Guid.Parse("bb4359b0-d8c2-479f-9397-4ce96ecc3468");

            var jobId1 = Guid.Parse("bb4359b0-d8c2-479f-9397-4ce96ecc3458");
            var jobId2 = Guid.Parse("bb4359b0-d8c2-479f-9397-4ce96ecc3457");
            var jobId3 = Guid.Parse("bb4359b0-d8c2-479f-9397-4ce96ecc3456");
            var jobId4 = Guid.Parse("bb4359b0-d8c2-479f-9397-4ce96ecc3454");
            var jobId5 = Guid.Parse("bb4359b0-d8c2-479f-9397-4ce96ecc3455");
            var jobId6 = Guid.Parse("bb4359b0-d8c2-479f-9397-4ce96ecc3453");
            var jobId7 = Guid.Parse("bb4359b0-d8c2-479f-9397-4ce96ecc3452");
            var jobId8 = Guid.Parse("bb4359b0-d8c2-479f-9397-4ce96ecc3451");
            var jobId9 = Guid.Parse("bb4359b0-d8c2-479f-9397-4ce96ecc3488");
            var jobId10 = Guid.Parse("bb4359b0-d8c2-479f-9397-4ce96ecc3418");

            modelBuilder
                .Entity<CompanyUser>()
                .HasData(
                    new CompanyUser
                    {
                        Id = Guid.Parse(companyId),
                        Email = "company@test.com",
                        PasswordHash = "p3ln9clcsffFCYXmkm9XfR2mmyH6XSptR777LC3XinRHPdVMKi0/1ttIZcr+rUC69TrpB3RVuC/MPAbLhnV+xw==",
                        CompanyName = "TestCompanyName",
                        AboutCompany = "Testing company",
                        Location = new List<string> { "TestLocation" },
                        Website = "http://website.com",
                        Jobs = new List<Job>(),
                        RoleId = Guid.Parse("d3717c53-1d0e-41cd-81b4-a522925c493a"),
                    }
                );

            modelBuilder
                .Entity<PrivateUser>()
                .HasData(
                    new PrivateUser
                    {
                        Id = Guid.Parse("d6ff4515-c1cb-4d3d-a268-cdff700f2168"),
                        Email = "private@test.com",
                        PasswordHash = "p3ln9clcsffFCYXmkm9XfR2mmyH6XSptR777LC3XinRHPdVMKi0/1ttIZcr+rUC69TrpB3RVuC/MPAbLhnV+xw==",
                        FirstName = "Private",
                        LastName = "User",
                        AboutMe =
                            "A highly motivated and experienced software engineer, I am currently seeking a new role that challenges me and provides opportunities for growth. My background in developing scalable web applications, along with my superior team collaboration and problem-solving skills, makes me a strong candidate for any forward-thinking company.",
                        Location = ["Behind you..."],
                        Skills = new List<Skill>(),
                        RoleId = Guid.Parse("db66e303-9b61-49c6-b25b-edd06d1b193a")
                    }
                );

            // Define the relationship between User and Skill
            modelBuilder.Entity<PrivateUser>().HasMany(u => u.Skills).WithMany();

            modelBuilder
                .Entity<Job>()
                .HasOne(j => j.Company)
                .WithMany(c => c.Jobs)
                .HasForeignKey(j => j.CompanyId);

            var userRoleId = "db66e303-9b61-49c6-b25b-edd06d1b193a";
            var companyRoleId = "d3717c53-1d0e-41cd-81b4-a522925c493a";
            var adminRoleId = "62f24422-c5cf-4468-b4e3-f988a76d90a0";

            var roles = new List<Role>
            {
                new Role
                {
                    Id = Guid.Parse(adminRoleId),
                    Name = "Admin"
                },
                new Role
                {
                    Id = Guid.Parse(companyRoleId),
                    Name = "Company",
                },
                new Role
                {
                    Id = Guid.Parse(userRoleId),
                    Name = "Private",
                }
            };

            modelBuilder.Entity<Role>().HasData(roles);

            // Seed jobs
            modelBuilder
                .Entity<Job>()
                .HasData(
                    new Job
                    {
                        Id = jobId1,
                        Title = "Job 1",
                        Description =
                            "We are seeking a talented and motivated Software Engineer to join our growing team. As a Software Engineer at [Company Name], you will have the opportunity to work on cutting-edge projects that impact millions of users worldwide. You will collaborate with cross-functional teams to design, develop, and deploy high-quality software solutions that drive our products forward.",
                        CompanyId = Guid.Parse(companyId),
                        Location = ["Location 1"],
                        Salary = "Salary 1",
                        FinalApplicationDate = DateTime.Now.AddDays(30).ToUniversalTime(),
                        CompanyUrl = "http://company1.com",
                        RequiredSkills = new List<Skill>()
                    },
                    new Job
                    {
                        Id = jobId2,
                        Title = "Job 2",
                        Description =
                            "We are seeking a talented and motivated Software Engineer to join our growing team. As a Software Engineer at [Company Name], you will have the opportunity to work on cutting-edge projects that impact millions of users worldwide. You will collaborate with cross-functional teams to design, develop, and deploy high-quality software solutions that drive our products forward.",
                        CompanyId = Guid.Parse(companyId),
                        Location = ["Location 2"],
                        Salary = "Salary 2",
                        FinalApplicationDate = DateTime.Now.AddDays(30).ToUniversalTime(),
                        CompanyUrl = "http://company2.com",
                        RequiredSkills = new List<Skill>()
                    },
                    new Job
                    {
                        Id = jobId3,
                        Title = "Job 3",
                        Description =
                            "We are seeking a talented and motivated Software Engineer to join our growing team. As a Software Engineer at [Company Name], you will have the opportunity to work on cutting-edge projects that impact millions of users worldwide. You will collaborate with cross-functional teams to design, develop, and deploy high-quality software solutions that drive our products forward.",
                        CompanyId = Guid.Parse(companyId),
                        Location =[ "Location 3"],
                        Salary = "Salary 3",
                        FinalApplicationDate = DateTime.Now.AddDays(30).ToUniversalTime(),
                        CompanyUrl = "http://company3.com",
                        RequiredSkills = new List<Skill>()

                    },
                    new Job
                    {
                        Id = jobId4,
                        Title = "Job 4",
                        Description =
                            "We are seeking a talented and motivated Software Engineer to join our growing team. As a Software Engineer at [Company Name], you will have the opportunity to work on cutting-edge projects that impact millions of users worldwide. You will collaborate with cross-functional teams to design, develop, and deploy high-quality software solutions that drive our products forward.",
                        CompanyId = Guid.Parse(companyId),
                        Location = ["Location 4"],
                        Salary = "Salary 4",
                        FinalApplicationDate = DateTime.Now.AddDays(30).ToUniversalTime(),
                        CompanyUrl = "http://company4.com",
                        RequiredSkills = new List<Skill>()

                    },
                    new Job
                    {
                        Id = jobId5,
                        Title = "Job 5",
                        Description =
                            "We are seeking a talented and motivated Software Engineer to join our growing team. As a Software Engineer at [Company Name], you will have the opportunity to work on cutting-edge projects that impact millions of users worldwide. You will collaborate with cross-functional teams to design, develop, and deploy high-quality software solutions that drive our products forward.",
                        CompanyId = Guid.Parse(companyId),
                        Location = ["Location 5"],
                        Salary = "Salary 5",
                        FinalApplicationDate = DateTime.Now.AddDays(30).ToUniversalTime(),
                        CompanyUrl = "http://company5.com",
                        RequiredSkills = new List<Skill>()
                    },
                    new Job
                    {
                        Id = jobId6,
                        Title = "Job 6",
                        Description =
                            "We are seeking a talented and motivated Software Engineer to join our growing team. As a Software Engineer at [Company Name], you will have the opportunity to work on cutting-edge projects that impact millions of users worldwide. You will collaborate with cross-functional teams to design, develop, and deploy high-quality software solutions that drive our products forward.",
                        CompanyId = Guid.Parse(companyId),
                        Location = ["Location 6"],
                        Salary = "Salary 6",
                        FinalApplicationDate = DateTime.Now.AddDays(30).ToUniversalTime(),
                        CompanyUrl = "http://company6.com",
                        RequiredSkills = new List<Skill>()
                    },
                    new Job
                    {
                        Id = jobId7,
                        Title = "Job 7",
                        Description =
                            "We are seeking a talented and motivated Software Engineer to join our growing team. As a Software Engineer at [Company Name], you will have the opportunity to work on cutting-edge projects that impact millions of users worldwide. You will collaborate with cross-functional teams to design, develop, and deploy high-quality software solutions that drive our products forward.",
                        CompanyId = Guid.Parse(companyId),
                        Location = ["Location 7"],
                        Salary = "Salary 7",
                        FinalApplicationDate = DateTime.Now.AddDays(30).ToUniversalTime(),
                        CompanyUrl = "http://company7.com",
                        RequiredSkills = new List<Skill>()
                    },
                    new Job
                    {
                        Id = jobId8,
                        Title = "Job 8",
                        Description =
                            "We are seeking a talented and motivated Software Engineer to join our growing team. As a Software Engineer at [Company Name], you will have the opportunity to work on cutting-edge projects that impact millions of users worldwide. You will collaborate with cross-functional teams to design, develop, and deploy high-quality software solutions that drive our products forward.",
                        CompanyId = Guid.Parse(companyId),
                        Location = ["Location 8"],
                        Salary = "Salary 8",
                        FinalApplicationDate = DateTime.Now.AddDays(30).ToUniversalTime(),
                        CompanyUrl = "http://company8.com",
                        RequiredSkills = new List<Skill>()
                    },
                    new Job
                    {
                        Id = jobId9,
                        Title = "Job 9",
                        Description =
                            "We are seeking a talented and motivated Software Engineer to join our growing team. As a Software Engineer at [Company Name], you will have the opportunity to work on cutting-edge projects that impact millions of users worldwide. You will collaborate with cross-functional teams to design, develop, and deploy high-quality software solutions that drive our products forward.",
                        CompanyId = Guid.Parse(companyId),
                        Location = ["Location 9"],
                        Salary = "Salary 9",
                        FinalApplicationDate = DateTime.Now.AddDays(30).ToUniversalTime(),
                        CompanyUrl = "http://company9.com",
                        RequiredSkills = new List<Skill>()
                    },
                    new Job
                    {
                        Id = jobId10,
                        Title = "Job 10",
                        Description =
                            "We are seeking a talented and motivated Software Engineer to join our growing team. As a Software Engineer at [Company Name], you will have the opportunity to work on cutting-edge projects that impact millions of users worldwide. You will collaborate with cross-functional teams to design, develop, and deploy high-quality software solutions that drive our products forward.",
                        CompanyId = Guid.Parse(companyId),
                        Location = ["Location 10"],
                        Salary = "Salary 10",
                        FinalApplicationDate = DateTime.Now.AddDays(30).ToUniversalTime(),
                        CompanyUrl = "http://company10.com",
                        RequiredSkills = new List<Skill>()
                    }
                );

            // Seed skills
            modelBuilder
                .Entity<Skill>()
                .HasData(
                    new Skill { Id = skillId1, Name = "Skill 1", },
                    new Skill { Id = skillId2, Name = "Skill 2", },
                    new Skill { Id = skillId3, Name = "Skill 3", },
                    new Skill { Id = skillId4, Name = "Skill 4", },
                    new Skill { Id = skillId5, Name = "Skill 5", },
                    new Skill { Id = skillId6, Name = "Skill 6", },
                    new Skill { Id = skillId7, Name = "Skill 7", },
                    new Skill { Id = skillId8, Name = "Skill 8", },
                    new Skill { Id = skillId9, Name = "Skill 9", },
                    new Skill { Id = skillId10, Name = "Skill 10", }
                );

            modelBuilder
                .Entity<Job>()
                .HasMany(j => j.RequiredSkills)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "JobSkill",
                    j => j.HasOne<Skill>().WithMany().HasForeignKey("SkillId"),
                    s => s.HasOne<Job>().WithMany().HasForeignKey("JobId"),
                    je =>
                    {
                        je.HasData(
                            new { JobId = jobId1, SkillId = skillId1 },
                            new { JobId = jobId2, SkillId = skillId2 },
                            new { JobId = jobId3, SkillId = skillId3 },
                            new { JobId = jobId4, SkillId = skillId4 },
                            new { JobId = jobId5, SkillId = skillId5 },
                            new { JobId = jobId6, SkillId = skillId6 },
                            new { JobId = jobId7, SkillId = skillId7 },
                            new { JobId = jobId8, SkillId = skillId8 },
                            new { JobId = jobId9, SkillId = skillId9 },
                            new { JobId = jobId10, SkillId = skillId10 },
                            new { JobId = jobId10, SkillId = skillId9 },
                            new { JobId = jobId10, SkillId = skillId8 },
                            new { JobId = jobId10, SkillId = skillId7 },
                            new { JobId = jobId10, SkillId = skillId6 },
                            new { JobId = jobId10, SkillId = skillId5 }
                        );
                    }
                );
        }

        public DbSet<PrivateUser> PrivateUsers { get; set; } = default!;
        public DbSet<CompanyUser> CompanyUsers { get; set; } = default!;
        public DbSet<Role> Roles { get; set; } = default!;
        public DbSet<Job> Jobs { get; set; } = default!;
        public DbSet<Match> Matches { get; set; } = default!;
        public DbSet<Skill> Skills { get; set; } = default!;
    }
}
