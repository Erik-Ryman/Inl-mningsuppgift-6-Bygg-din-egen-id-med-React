﻿// <auto-generated />
using System;
using System.Collections.Generic;
using JobSwipe_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace JobSwipe_API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240518103450_AlteredSeededPassword")]
    partial class AlteredSeededPassword
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("JobSkill", b =>
                {
                    b.Property<Guid>("JobId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SkillId")
                        .HasColumnType("uuid");

                    b.HasKey("JobId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("JobSkill");

                    b.HasData(
                        new
                        {
                            JobId = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3458"),
                            SkillId = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3459")
                        },
                        new
                        {
                            JobId = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3457"),
                            SkillId = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3460")
                        },
                        new
                        {
                            JobId = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3456"),
                            SkillId = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3461")
                        },
                        new
                        {
                            JobId = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3454"),
                            SkillId = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3462")
                        },
                        new
                        {
                            JobId = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3455"),
                            SkillId = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3463")
                        },
                        new
                        {
                            JobId = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3453"),
                            SkillId = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3464")
                        },
                        new
                        {
                            JobId = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3452"),
                            SkillId = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3465")
                        },
                        new
                        {
                            JobId = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3451"),
                            SkillId = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3466")
                        },
                        new
                        {
                            JobId = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3488"),
                            SkillId = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3467")
                        },
                        new
                        {
                            JobId = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3418"),
                            SkillId = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3468")
                        },
                        new
                        {
                            JobId = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3418"),
                            SkillId = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3467")
                        },
                        new
                        {
                            JobId = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3418"),
                            SkillId = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3466")
                        },
                        new
                        {
                            JobId = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3418"),
                            SkillId = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3465")
                        },
                        new
                        {
                            JobId = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3418"),
                            SkillId = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3464")
                        },
                        new
                        {
                            JobId = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3418"),
                            SkillId = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3463")
                        });
                });

            modelBuilder.Entity("JobSwipe_API.Models.CompanyUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AboutCompany")
                        .HasColumnType("text");

                    b.Property<string>("CompanyName")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<string>>("Location")
                        .HasColumnType("text[]");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("text");

                    b.Property<DateTime>("RefreshTokenExpiry")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.Property<string>("Website")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("CompanyUsers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7479a49d-e9b1-4179-a2db-6a7d64faa0c7"),
                            AboutCompany = "Testing company",
                            CompanyName = "TestCompanyName",
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "company@example.com",
                            Location = new List<string> { "TestLocation" },
                            PasswordHash = "p3ln9clcsffFCYXmkm9XfR2mmyH6XSptR777LC3XinRHPdVMKi0/1ttIZcr+rUC69TrpB3RVuC/MPAbLhnV+xw==",
                            RefreshTokenExpiry = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RoleId = new Guid("d3717c53-1d0e-41cd-81b4-a522925c493a"),
                            Website = "http://website.com"
                        });
                });

            modelBuilder.Entity("JobSwipe_API.Models.DTO.Auth.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("62f24422-c5cf-4468-b4e3-f988a76d90a0"),
                            Name = "Admin"
                        },
                        new
                        {
                            Id = new Guid("d3717c53-1d0e-41cd-81b4-a522925c493a"),
                            Name = "Company"
                        },
                        new
                        {
                            Id = new Guid("db66e303-9b61-49c6-b25b-edd06d1b193a"),
                            Name = "Private"
                        });
                });

            modelBuilder.Entity("JobSwipe_API.Models.Job", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uuid");

                    b.Property<string>("CompanyUrl")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("FinalApplicationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<List<string>>("Location")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("Salary")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Jobs");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3458"),
                            CompanyId = new Guid("7479a49d-e9b1-4179-a2db-6a7d64faa0c7"),
                            CompanyUrl = "http://company1.com",
                            Description = "We are seeking a talented and motivated Software Engineer to join our growing team. As a Software Engineer at [Company Name], you will have the opportunity to work on cutting-edge projects that impact millions of users worldwide. You will collaborate with cross-functional teams to design, develop, and deploy high-quality software solutions that drive our products forward.",
                            FinalApplicationDate = new DateTime(2024, 6, 17, 10, 34, 49, 293, DateTimeKind.Utc).AddTicks(3347),
                            Location = new List<string> { "Location 1" },
                            Salary = "Salary 1",
                            Title = "Job 1"
                        },
                        new
                        {
                            Id = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3457"),
                            CompanyId = new Guid("7479a49d-e9b1-4179-a2db-6a7d64faa0c7"),
                            CompanyUrl = "http://company2.com",
                            Description = "We are seeking a talented and motivated Software Engineer to join our growing team. As a Software Engineer at [Company Name], you will have the opportunity to work on cutting-edge projects that impact millions of users worldwide. You will collaborate with cross-functional teams to design, develop, and deploy high-quality software solutions that drive our products forward.",
                            FinalApplicationDate = new DateTime(2024, 6, 17, 10, 34, 49, 293, DateTimeKind.Utc).AddTicks(3428),
                            Location = new List<string> { "Location 2" },
                            Salary = "Salary 2",
                            Title = "Job 2"
                        },
                        new
                        {
                            Id = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3456"),
                            CompanyId = new Guid("7479a49d-e9b1-4179-a2db-6a7d64faa0c7"),
                            CompanyUrl = "http://company3.com",
                            Description = "We are seeking a talented and motivated Software Engineer to join our growing team. As a Software Engineer at [Company Name], you will have the opportunity to work on cutting-edge projects that impact millions of users worldwide. You will collaborate with cross-functional teams to design, develop, and deploy high-quality software solutions that drive our products forward.",
                            FinalApplicationDate = new DateTime(2024, 6, 17, 10, 34, 49, 293, DateTimeKind.Utc).AddTicks(3435),
                            Location = new List<string> { "Location 3" },
                            Salary = "Salary 3",
                            Title = "Job 3"
                        },
                        new
                        {
                            Id = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3454"),
                            CompanyId = new Guid("7479a49d-e9b1-4179-a2db-6a7d64faa0c7"),
                            CompanyUrl = "http://company4.com",
                            Description = "We are seeking a talented and motivated Software Engineer to join our growing team. As a Software Engineer at [Company Name], you will have the opportunity to work on cutting-edge projects that impact millions of users worldwide. You will collaborate with cross-functional teams to design, develop, and deploy high-quality software solutions that drive our products forward.",
                            FinalApplicationDate = new DateTime(2024, 6, 17, 10, 34, 49, 293, DateTimeKind.Utc).AddTicks(3442),
                            Location = new List<string> { "Location 4" },
                            Salary = "Salary 4",
                            Title = "Job 4"
                        },
                        new
                        {
                            Id = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3455"),
                            CompanyId = new Guid("7479a49d-e9b1-4179-a2db-6a7d64faa0c7"),
                            CompanyUrl = "http://company5.com",
                            Description = "We are seeking a talented and motivated Software Engineer to join our growing team. As a Software Engineer at [Company Name], you will have the opportunity to work on cutting-edge projects that impact millions of users worldwide. You will collaborate with cross-functional teams to design, develop, and deploy high-quality software solutions that drive our products forward.",
                            FinalApplicationDate = new DateTime(2024, 6, 17, 10, 34, 49, 293, DateTimeKind.Utc).AddTicks(3449),
                            Location = new List<string> { "Location 5" },
                            Salary = "Salary 5",
                            Title = "Job 5"
                        },
                        new
                        {
                            Id = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3453"),
                            CompanyId = new Guid("7479a49d-e9b1-4179-a2db-6a7d64faa0c7"),
                            CompanyUrl = "http://company6.com",
                            Description = "We are seeking a talented and motivated Software Engineer to join our growing team. As a Software Engineer at [Company Name], you will have the opportunity to work on cutting-edge projects that impact millions of users worldwide. You will collaborate with cross-functional teams to design, develop, and deploy high-quality software solutions that drive our products forward.",
                            FinalApplicationDate = new DateTime(2024, 6, 17, 10, 34, 49, 293, DateTimeKind.Utc).AddTicks(3455),
                            Location = new List<string> { "Location 6" },
                            Salary = "Salary 6",
                            Title = "Job 6"
                        },
                        new
                        {
                            Id = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3452"),
                            CompanyId = new Guid("7479a49d-e9b1-4179-a2db-6a7d64faa0c7"),
                            CompanyUrl = "http://company7.com",
                            Description = "We are seeking a talented and motivated Software Engineer to join our growing team. As a Software Engineer at [Company Name], you will have the opportunity to work on cutting-edge projects that impact millions of users worldwide. You will collaborate with cross-functional teams to design, develop, and deploy high-quality software solutions that drive our products forward.",
                            FinalApplicationDate = new DateTime(2024, 6, 17, 10, 34, 49, 293, DateTimeKind.Utc).AddTicks(3462),
                            Location = new List<string> { "Location 7" },
                            Salary = "Salary 7",
                            Title = "Job 7"
                        },
                        new
                        {
                            Id = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3451"),
                            CompanyId = new Guid("7479a49d-e9b1-4179-a2db-6a7d64faa0c7"),
                            CompanyUrl = "http://company8.com",
                            Description = "We are seeking a talented and motivated Software Engineer to join our growing team. As a Software Engineer at [Company Name], you will have the opportunity to work on cutting-edge projects that impact millions of users worldwide. You will collaborate with cross-functional teams to design, develop, and deploy high-quality software solutions that drive our products forward.",
                            FinalApplicationDate = new DateTime(2024, 6, 17, 10, 34, 49, 293, DateTimeKind.Utc).AddTicks(3468),
                            Location = new List<string> { "Location 8" },
                            Salary = "Salary 8",
                            Title = "Job 8"
                        },
                        new
                        {
                            Id = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3488"),
                            CompanyId = new Guid("7479a49d-e9b1-4179-a2db-6a7d64faa0c7"),
                            CompanyUrl = "http://company9.com",
                            Description = "We are seeking a talented and motivated Software Engineer to join our growing team. As a Software Engineer at [Company Name], you will have the opportunity to work on cutting-edge projects that impact millions of users worldwide. You will collaborate with cross-functional teams to design, develop, and deploy high-quality software solutions that drive our products forward.",
                            FinalApplicationDate = new DateTime(2024, 6, 17, 10, 34, 49, 293, DateTimeKind.Utc).AddTicks(3475),
                            Location = new List<string> { "Location 9" },
                            Salary = "Salary 9",
                            Title = "Job 9"
                        },
                        new
                        {
                            Id = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3418"),
                            CompanyId = new Guid("7479a49d-e9b1-4179-a2db-6a7d64faa0c7"),
                            CompanyUrl = "http://company10.com",
                            Description = "We are seeking a talented and motivated Software Engineer to join our growing team. As a Software Engineer at [Company Name], you will have the opportunity to work on cutting-edge projects that impact millions of users worldwide. You will collaborate with cross-functional teams to design, develop, and deploy high-quality software solutions that drive our products forward.",
                            FinalApplicationDate = new DateTime(2024, 6, 17, 10, 34, 49, 293, DateTimeKind.Utc).AddTicks(3481),
                            Location = new List<string> { "Location 10" },
                            Salary = "Salary 10",
                            Title = "Job 10"
                        });
                });

            modelBuilder.Entity("JobSwipe_API.Models.Match", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CompanyUserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsMatch")
                        .HasColumnType("boolean");

                    b.Property<Guid>("JobId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("PrivateUserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CompanyUserId");

                    b.HasIndex("PrivateUserId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("JobSwipe_API.Models.PrivateUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AboutMe")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<List<string>>("Location")
                        .HasColumnType("text[]");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("text");

                    b.Property<DateTime>("RefreshTokenExpiry")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("PrivateUsers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d6ff4515-c1cb-4d3d-a268-cdff700f2168"),
                            AboutMe = "A highly motivated and experienced software engineer, I am currently seeking a new role that challenges me and provides opportunities for growth. My background in developing scalable web applications, along with my superior team collaboration and problem-solving skills, makes me a strong candidate for any forward-thinking company.",
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "private@test.com",
                            FirstName = "Private",
                            LastName = "User",
                            Location = new List<string> { "Behind you..." },
                            PasswordHash = "p3ln9clcsffFCYXmkm9XfR2mmyH6XSptR777LC3XinRHPdVMKi0/1ttIZcr+rUC69TrpB3RVuC/MPAbLhnV+xw==",
                            RefreshTokenExpiry = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RoleId = new Guid("db66e303-9b61-49c6-b25b-edd06d1b193a")
                        });
                });

            modelBuilder.Entity("JobSwipe_API.Models.Skill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("JobId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.ToTable("Skills");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3459"),
                            Name = "Skill 1"
                        },
                        new
                        {
                            Id = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3460"),
                            Name = "Skill 2"
                        },
                        new
                        {
                            Id = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3461"),
                            Name = "Skill 3"
                        },
                        new
                        {
                            Id = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3462"),
                            Name = "Skill 4"
                        },
                        new
                        {
                            Id = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3463"),
                            Name = "Skill 5"
                        },
                        new
                        {
                            Id = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3464"),
                            Name = "Skill 6"
                        },
                        new
                        {
                            Id = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3465"),
                            Name = "Skill 7"
                        },
                        new
                        {
                            Id = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3466"),
                            Name = "Skill 8"
                        },
                        new
                        {
                            Id = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3467"),
                            Name = "Skill 9"
                        },
                        new
                        {
                            Id = new Guid("bb4359b0-d8c2-479f-9397-4ce96ecc3468"),
                            Name = "Skill 10"
                        });
                });

            modelBuilder.Entity("PrivateUserSkill", b =>
                {
                    b.Property<Guid>("PrivateUserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SkillsId")
                        .HasColumnType("uuid");

                    b.HasKey("PrivateUserId", "SkillsId");

                    b.HasIndex("SkillsId");

                    b.ToTable("PrivateUserSkill");
                });

            modelBuilder.Entity("JobSkill", b =>
                {
                    b.HasOne("JobSwipe_API.Models.Job", null)
                        .WithMany()
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobSwipe_API.Models.Skill", null)
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JobSwipe_API.Models.CompanyUser", b =>
                {
                    b.HasOne("JobSwipe_API.Models.DTO.Auth.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("JobSwipe_API.Models.Job", b =>
                {
                    b.HasOne("JobSwipe_API.Models.CompanyUser", "Company")
                        .WithMany("Jobs")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("JobSwipe_API.Models.Match", b =>
                {
                    b.HasOne("JobSwipe_API.Models.CompanyUser", null)
                        .WithMany("Matches")
                        .HasForeignKey("CompanyUserId");

                    b.HasOne("JobSwipe_API.Models.PrivateUser", null)
                        .WithMany("Matches")
                        .HasForeignKey("PrivateUserId");
                });

            modelBuilder.Entity("JobSwipe_API.Models.PrivateUser", b =>
                {
                    b.HasOne("JobSwipe_API.Models.DTO.Auth.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("JobSwipe_API.Models.Skill", b =>
                {
                    b.HasOne("JobSwipe_API.Models.Job", null)
                        .WithMany("OptionalSkills")
                        .HasForeignKey("JobId");
                });

            modelBuilder.Entity("PrivateUserSkill", b =>
                {
                    b.HasOne("JobSwipe_API.Models.PrivateUser", null)
                        .WithMany()
                        .HasForeignKey("PrivateUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobSwipe_API.Models.Skill", null)
                        .WithMany()
                        .HasForeignKey("SkillsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JobSwipe_API.Models.CompanyUser", b =>
                {
                    b.Navigation("Jobs");

                    b.Navigation("Matches");
                });

            modelBuilder.Entity("JobSwipe_API.Models.Job", b =>
                {
                    b.Navigation("OptionalSkills");
                });

            modelBuilder.Entity("JobSwipe_API.Models.PrivateUser", b =>
                {
                    b.Navigation("Matches");
                });
#pragma warning restore 612, 618
        }
    }
}
