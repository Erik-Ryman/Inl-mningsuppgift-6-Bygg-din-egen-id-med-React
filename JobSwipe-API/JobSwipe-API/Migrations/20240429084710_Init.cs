using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobSwipe_API.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Swipes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    JobId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsLike = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Swipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyName = table.Column<string>(type: "text", nullable: true),
                    AboutCompany = table.Column<string>(type: "text", nullable: true),
                    Website = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<List<string>>(type: "text[]", nullable: true),
                    RefreshToken = table.Column<string>(type: "text", nullable: true),
                    RefreshTokenExpiry = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyUsers_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrivateUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    AboutMe = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<List<string>>(type: "text[]", nullable: true),
                    RefreshToken = table.Column<string>(type: "text", nullable: true),
                    RefreshTokenExpiry = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrivateUsers_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    Salary = table.Column<string>(type: "text", nullable: true),
                    CompanyUrl = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<List<string>>(type: "text[]", nullable: false),
                    FinalApplicationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_CompanyUsers_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "CompanyUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    JobId = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    PrivateUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_CompanyUsers_CompanyUserId",
                        column: x => x.CompanyUserId,
                        principalTable: "CompanyUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matches_PrivateUsers_PrivateUserId",
                        column: x => x.PrivateUserId,
                        principalTable: "PrivateUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    JobId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JobSkill",
                columns: table => new
                {
                    JobId = table.Column<Guid>(type: "uuid", nullable: false),
                    SkillId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSkill", x => new { x.JobId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_JobSkill_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobSkill_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrivateUserSkill",
                columns: table => new
                {
                    PrivateUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    SkillsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateUserSkill", x => new { x.PrivateUserId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_PrivateUserSkill_PrivateUsers_PrivateUserId",
                        column: x => x.PrivateUserId,
                        principalTable: "PrivateUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrivateUserSkill_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("62f24422-c5cf-4468-b4e3-f988a76d90a0"), "Admin" },
                    { new Guid("d3717c53-1d0e-41cd-81b4-a522925c493a"), "Company" },
                    { new Guid("db66e303-9b61-49c6-b25b-edd06d1b193a"), "Private" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "JobId", "Name" },
                values: new object[,]
                {
                    { new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3459"), null, "Skill 1" },
                    { new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3460"), null, "Skill 2" },
                    { new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3461"), null, "Skill 3" },
                    { new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3462"), null, "Skill 4" },
                    { new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3463"), null, "Skill 5" },
                    { new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3464"), null, "Skill 6" },
                    { new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3465"), null, "Skill 7" },
                    { new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3466"), null, "Skill 8" },
                    { new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3467"), null, "Skill 9" },
                    { new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3468"), null, "Skill 10" }
                });

            migrationBuilder.InsertData(
                table: "CompanyUsers",
                columns: new[] { "Id", "AboutCompany", "CompanyName", "Created", "Email", "Location", "PasswordHash", "RefreshToken", "RefreshTokenExpiry", "RoleId", "Website" },
                values: new object[] { new Guid("7479a49d-e9b1-4179-a2db-6a7d64faa0c7"), "Testing company", "TestCompanyName", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "company@example.com", new List<string> { "TestLocation" }, "$2y$10$0mSQNNORMDUpvbWmYti2K.Yf.EC.5X4TOMUJnthfgtBwz6ht7zxzC", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d3717c53-1d0e-41cd-81b4-a522925c493a"), "http://website.com" });

            migrationBuilder.InsertData(
                table: "PrivateUsers",
                columns: new[] { "Id", "AboutMe", "Created", "Email", "FirstName", "LastName", "Location", "PasswordHash", "RefreshToken", "RefreshTokenExpiry", "RoleId" },
                values: new object[] { new Guid("d6ff4515-c1cb-4d3d-a268-cdff700f2168"), "A highly motivated and experienced software engineer, I am currently seeking a new role that challenges me and provides opportunities for growth. My background in developing scalable web applications, along with my superior team collaboration and problem-solving skills, makes me a strong candidate for any forward-thinking company.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "private@test.com", "Private", "User", new List<string> { "Behind you..." }, "$2y$10$0mSQNNORMDUpvbWmYti2K.Yf.EC.5X4TOMUJnthfgtBwz6ht7zxzC", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("db66e303-9b61-49c6-b25b-edd06d1b193a") });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "CompanyId", "CompanyUrl", "Description", "FinalApplicationDate", "Location", "Salary", "Title" },
                values: new object[,]
                {
                    { new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3418"), new Guid("7479a49d-e9b1-4179-a2db-6a7d64faa0c7"), "http://company10.com", "We are seeking a talented and motivated Software Engineer to join our growing team. As a Software Engineer at [Company Name], you will have the opportunity to work on cutting-edge projects that impact millions of users worldwide. You will collaborate with cross-functional teams to design, develop, and deploy high-quality software solutions that drive our products forward.", new DateTime(2024, 5, 29, 8, 47, 8, 650, DateTimeKind.Utc).AddTicks(3914), new List<string> { "Location 10" }, "Salary 10", "Job 10" },
                    { new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3451"), new Guid("7479a49d-e9b1-4179-a2db-6a7d64faa0c7"), "http://company8.com", "We are seeking a talented and motivated Software Engineer to join our growing team. As a Software Engineer at [Company Name], you will have the opportunity to work on cutting-edge projects that impact millions of users worldwide. You will collaborate with cross-functional teams to design, develop, and deploy high-quality software solutions that drive our products forward.", new DateTime(2024, 5, 29, 8, 47, 8, 650, DateTimeKind.Utc).AddTicks(3899), new List<string> { "Location 8" }, "Salary 8", "Job 8" },
                    { new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3452"), new Guid("7479a49d-e9b1-4179-a2db-6a7d64faa0c7"), "http://company7.com", "We are seeking a talented and motivated Software Engineer to join our growing team. As a Software Engineer at [Company Name], you will have the opportunity to work on cutting-edge projects that impact millions of users worldwide. You will collaborate with cross-functional teams to design, develop, and deploy high-quality software solutions that drive our products forward.", new DateTime(2024, 5, 29, 8, 47, 8, 650, DateTimeKind.Utc).AddTicks(3891), new List<string> { "Location 7" }, "Salary 7", "Job 7" },
                    { new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3453"), new Guid("7479a49d-e9b1-4179-a2db-6a7d64faa0c7"), "http://company6.com", "We are seeking a talented and motivated Software Engineer to join our growing team. As a Software Engineer at [Company Name], you will have the opportunity to work on cutting-edge projects that impact millions of users worldwide. You will collaborate with cross-functional teams to design, develop, and deploy high-quality software solutions that drive our products forward.", new DateTime(2024, 5, 29, 8, 47, 8, 650, DateTimeKind.Utc).AddTicks(3883), new List<string> { "Location 6" }, "Salary 6", "Job 6" },
                    { new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3454"), new Guid("7479a49d-e9b1-4179-a2db-6a7d64faa0c7"), "http://company4.com", "We are seeking a talented and motivated Software Engineer to join our growing team. As a Software Engineer at [Company Name], you will have the opportunity to work on cutting-edge projects that impact millions of users worldwide. You will collaborate with cross-functional teams to design, develop, and deploy high-quality software solutions that drive our products forward.", new DateTime(2024, 5, 29, 8, 47, 8, 650, DateTimeKind.Utc).AddTicks(3867), new List<string> { "Location 4" }, "Salary 4", "Job 4" },
                    { new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3455"), new Guid("7479a49d-e9b1-4179-a2db-6a7d64faa0c7"), "http://company5.com", "We are seeking a talented and motivated Software Engineer to join our growing team. As a Software Engineer at [Company Name], you will have the opportunity to work on cutting-edge projects that impact millions of users worldwide. You will collaborate with cross-functional teams to design, develop, and deploy high-quality software solutions that drive our products forward.", new DateTime(2024, 5, 29, 8, 47, 8, 650, DateTimeKind.Utc).AddTicks(3875), new List<string> { "Location 5" }, "Salary 5", "Job 5" },
                    { new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3456"), new Guid("7479a49d-e9b1-4179-a2db-6a7d64faa0c7"), "http://company3.com", "We are seeking a talented and motivated Software Engineer to join our growing team. As a Software Engineer at [Company Name], you will have the opportunity to work on cutting-edge projects that impact millions of users worldwide. You will collaborate with cross-functional teams to design, develop, and deploy high-quality software solutions that drive our products forward.", new DateTime(2024, 5, 29, 8, 47, 8, 650, DateTimeKind.Utc).AddTicks(3859), new List<string> { "Location 3" }, "Salary 3", "Job 3" },
                    { new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3457"), new Guid("7479a49d-e9b1-4179-a2db-6a7d64faa0c7"), "http://company2.com", "We are seeking a talented and motivated Software Engineer to join our growing team. As a Software Engineer at [Company Name], you will have the opportunity to work on cutting-edge projects that impact millions of users worldwide. You will collaborate with cross-functional teams to design, develop, and deploy high-quality software solutions that drive our products forward.", new DateTime(2024, 5, 29, 8, 47, 8, 650, DateTimeKind.Utc).AddTicks(3849), new List<string> { "Location 2" }, "Salary 2", "Job 2" },
                    { new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3458"), new Guid("7479a49d-e9b1-4179-a2db-6a7d64faa0c7"), "http://company1.com", "We are seeking a talented and motivated Software Engineer to join our growing team. As a Software Engineer at [Company Name], you will have the opportunity to work on cutting-edge projects that impact millions of users worldwide. You will collaborate with cross-functional teams to design, develop, and deploy high-quality software solutions that drive our products forward.", new DateTime(2024, 5, 29, 8, 47, 8, 650, DateTimeKind.Utc).AddTicks(3752), new List<string> { "Location 1" }, "Salary 1", "Job 1" },
                    { new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3488"), new Guid("7479a49d-e9b1-4179-a2db-6a7d64faa0c7"), "http://company9.com", "We are seeking a talented and motivated Software Engineer to join our growing team. As a Software Engineer at [Company Name], you will have the opportunity to work on cutting-edge projects that impact millions of users worldwide. You will collaborate with cross-functional teams to design, develop, and deploy high-quality software solutions that drive our products forward.", new DateTime(2024, 5, 29, 8, 47, 8, 650, DateTimeKind.Utc).AddTicks(3907), new List<string> { "Location 9" }, "Salary 9", "Job 9" }
                });

            migrationBuilder.InsertData(
                table: "JobSkill",
                columns: new[] { "JobId", "SkillId" },
                values: new object[,]
                {
                    { new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3418"), new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3463") },
                    { new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3418"), new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3464") },
                    { new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3418"), new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3465") },
                    { new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3418"), new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3466") },
                    { new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3418"), new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3467") },
                    { new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3418"), new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3468") },
                    { new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3451"), new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3466") },
                    { new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3452"), new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3465") },
                    { new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3453"), new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3464") },
                    { new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3454"), new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3462") },
                    { new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3455"), new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3463") },
                    { new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3456"), new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3461") },
                    { new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3457"), new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3460") },
                    { new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3458"), new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3459") },
                    { new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3488"), new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3467") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyUsers_RoleId",
                table: "CompanyUsers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSkill_SkillId",
                table: "JobSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CompanyId",
                table: "Jobs",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_CompanyUserId",
                table: "Matches",
                column: "CompanyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_PrivateUserId",
                table: "Matches",
                column: "PrivateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateUserSkill_SkillsId",
                table: "PrivateUserSkill",
                column: "SkillsId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateUsers_RoleId",
                table: "PrivateUsers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_JobId",
                table: "Skills",
                column: "JobId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobSkill");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "PrivateUserSkill");

            migrationBuilder.DropTable(
                name: "Swipes");

            migrationBuilder.DropTable(
                name: "PrivateUsers");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "CompanyUsers");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
