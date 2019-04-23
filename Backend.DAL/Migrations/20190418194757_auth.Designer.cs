﻿// <auto-generated />
using System;
using Backend.DAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Backend.DAL.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20190418194757_auth")]
    partial class auth
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Backend.DAL.Entities.Common.InstrumentalStudies.CommonUltrasound", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Info");

                    b.Property<int>("InjuriesDiseasesId");

                    b.HasKey("Id");

                    b.HasIndex("InjuriesDiseasesId");

                    b.ToTable("CommonUltrasounds");
                });

            modelBuilder.Entity("Backend.DAL.Entities.Common.InstrumentalStudies.Electrocardiogram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Info");

                    b.Property<int>("MedicalExaminationId");

                    b.HasKey("Id");

                    b.HasIndex("MedicalExaminationId");

                    b.ToTable("Electrocardiogram");
                });

            modelBuilder.Entity("Backend.DAL.Entities.Common.InstrumentalStudies.HeartUltrasound", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Info");

                    b.Property<int>("MedicalExaminationId");

                    b.HasKey("Id");

                    b.HasIndex("MedicalExaminationId");

                    b.ToTable("HeartUltrasound");
                });

            modelBuilder.Entity("Backend.DAL.Entities.Common.InstrumentalStudies.MRI", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Info");

                    b.Property<int>("InjuriesDiseasesId");

                    b.HasKey("Id");

                    b.HasIndex("InjuriesDiseasesId");

                    b.ToTable("MRI");
                });

            modelBuilder.Entity("Backend.DAL.Entities.Common.InstrumentalStudies.Radiography", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Info");

                    b.Property<int>("InjuriesDiseasesId");

                    b.HasKey("Id");

                    b.HasIndex("InjuriesDiseasesId");

                    b.ToTable("Radiographies");
                });

            modelBuilder.Entity("Backend.DAL.Entities.Common.LaboratoryResearch.BloodChemistryAnalysis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Info");

                    b.Property<int>("MedicalExaminationId");

                    b.HasKey("Id");

                    b.HasIndex("MedicalExaminationId");

                    b.ToTable("BloodChemistryAnalysis");
                });

            modelBuilder.Entity("Backend.DAL.Entities.Common.LaboratoryResearch.GeneralBloodAnalysis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Info");

                    b.Property<int>("MedicalExaminationId");

                    b.HasKey("Id");

                    b.HasIndex("MedicalExaminationId");

                    b.ToTable("GeneralBloodAnalysis");
                });

            modelBuilder.Entity("Backend.DAL.Entities.Common.LaboratoryResearch.GeneralUrineAnalysis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Info");

                    b.Property<int>("MedicalExaminationId");

                    b.HasKey("Id");

                    b.HasIndex("MedicalExaminationId");

                    b.ToTable("GeneralUrineAnalysis");
                });

            modelBuilder.Entity("Backend.DAL.Entities.Common.MedicalProfession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProfessionName");

                    b.HasKey("Id");

                    b.ToTable("MedicalProfessions");
                });

            modelBuilder.Entity("Backend.DAL.Entities.GeneralInformationEntities.Fluorography", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GeneralInformationId");

                    b.Property<string>("Information");

                    b.Property<DateTime>("ProcedureTime");

                    b.HasKey("Id");

                    b.HasIndex("GeneralInformationId");

                    b.ToTable("Fluorography");
                });

            modelBuilder.Entity("Backend.DAL.Entities.GeneralInformationEntities.GeneralInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("ArterialPressure");

                    b.Property<DateTime>("Bithday");

                    b.Property<string>("BloodType");

                    b.Property<double>("Height");

                    b.Property<int>("PatientId");

                    b.Property<double>("Weight");

                    b.HasKey("Id");

                    b.HasIndex("PatientId")
                        .IsUnique();

                    b.ToTable("GeneralInformation");
                });

            modelBuilder.Entity("Backend.DAL.Entities.GeneralInformationEntities.SurgicalIntervention", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Diagnosis");

                    b.Property<int>("GeneralInformationId");

                    b.Property<string>("InterventionType");

                    b.Property<DateTime>("ProcedureTime");

                    b.HasKey("Id");

                    b.HasIndex("GeneralInformationId");

                    b.ToTable("SurgicalIntervention");
                });

            modelBuilder.Entity("Backend.DAL.Entities.GeneralInformationEntities.VaccinationStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GeneralInformationId");

                    b.Property<string>("Information");

                    b.Property<DateTime>("ProcedureTime");

                    b.HasKey("Id");

                    b.HasIndex("GeneralInformationId");

                    b.ToTable("VaccinationStatus");
                });

            modelBuilder.Entity("Backend.DAL.Entities.InjuriesDiseasesEntities.DisabilityType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("DisabilityType");
                });

            modelBuilder.Entity("Backend.DAL.Entities.InjuriesDiseasesEntities.InjuriesDiseases", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateInjuriesOrDiseases");

                    b.Property<string>("Diagnosis");

                    b.Property<int>("DisabilityCountDay");

                    b.Property<int>("DisabilityTypeId");

                    b.Property<string>("DrugTherapy");

                    b.Property<string>("Other");

                    b.Property<int>("PatientId");

                    b.Property<string>("PhysiotherapyTreatment");

                    b.Property<DateTime>("ReleasedInMainGroup");

                    b.HasKey("Id");

                    b.HasIndex("DisabilityTypeId");

                    b.HasIndex("PatientId");

                    b.ToTable("InjuriesDiseases");
                });

            modelBuilder.Entity("Backend.DAL.Entities.MedicalExaminationEntities.DoctorsDiagnosis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Diagnosis");

                    b.Property<int>("MedicalExaminationId");

                    b.Property<int>("MedicalProfessionId");

                    b.HasKey("Id");

                    b.HasIndex("MedicalExaminationId");

                    b.HasIndex("MedicalProfessionId");

                    b.ToTable("DoctorsDiagnosis");
                });

            modelBuilder.Entity("Backend.DAL.Entities.MedicalExaminationEntities.MedicalExamination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Allowance");

                    b.Property<int>("PatientId");

                    b.Property<DateTime>("ProcedureTime");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("MedicalExamination");
                });

            modelBuilder.Entity("Backend.DAL.Entities.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("Photo");

                    b.HasKey("Id");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("Backend.DAL.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Backend.DAL.Entities.Common.InstrumentalStudies.CommonUltrasound", b =>
                {
                    b.HasOne("Backend.DAL.Entities.InjuriesDiseasesEntities.InjuriesDiseases", "InjuriesDiseases")
                        .WithMany("CommonUltrasounds")
                        .HasForeignKey("InjuriesDiseasesId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend.DAL.Entities.Common.InstrumentalStudies.Electrocardiogram", b =>
                {
                    b.HasOne("Backend.DAL.Entities.MedicalExaminationEntities.MedicalExamination", "MedicalExamination")
                        .WithMany("Electrocardiograms")
                        .HasForeignKey("MedicalExaminationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend.DAL.Entities.Common.InstrumentalStudies.HeartUltrasound", b =>
                {
                    b.HasOne("Backend.DAL.Entities.MedicalExaminationEntities.MedicalExamination", "MedicalExamination")
                        .WithMany("HeartUltrasounds")
                        .HasForeignKey("MedicalExaminationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend.DAL.Entities.Common.InstrumentalStudies.MRI", b =>
                {
                    b.HasOne("Backend.DAL.Entities.InjuriesDiseasesEntities.InjuriesDiseases", "InjuriesDiseases")
                        .WithMany("MRIs")
                        .HasForeignKey("InjuriesDiseasesId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend.DAL.Entities.Common.InstrumentalStudies.Radiography", b =>
                {
                    b.HasOne("Backend.DAL.Entities.InjuriesDiseasesEntities.InjuriesDiseases", "InjuriesDiseases")
                        .WithMany("Radiographies")
                        .HasForeignKey("InjuriesDiseasesId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend.DAL.Entities.Common.LaboratoryResearch.BloodChemistryAnalysis", b =>
                {
                    b.HasOne("Backend.DAL.Entities.MedicalExaminationEntities.MedicalExamination", "MedicalExamination")
                        .WithMany("BloodChemistryAnalyses")
                        .HasForeignKey("MedicalExaminationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend.DAL.Entities.Common.LaboratoryResearch.GeneralBloodAnalysis", b =>
                {
                    b.HasOne("Backend.DAL.Entities.MedicalExaminationEntities.MedicalExamination", "MedicalExamination")
                        .WithMany("GeneralBloodAnalyses")
                        .HasForeignKey("MedicalExaminationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend.DAL.Entities.Common.LaboratoryResearch.GeneralUrineAnalysis", b =>
                {
                    b.HasOne("Backend.DAL.Entities.MedicalExaminationEntities.MedicalExamination", "MedicalExamination")
                        .WithMany("GeneralUrineAnalyses")
                        .HasForeignKey("MedicalExaminationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend.DAL.Entities.GeneralInformationEntities.Fluorography", b =>
                {
                    b.HasOne("Backend.DAL.Entities.GeneralInformationEntities.GeneralInformation", "GeneralInformation")
                        .WithMany("Fluorographies")
                        .HasForeignKey("GeneralInformationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend.DAL.Entities.GeneralInformationEntities.GeneralInformation", b =>
                {
                    b.HasOne("Backend.DAL.Entities.Patient", "Patient")
                        .WithOne("GeneralInformation")
                        .HasForeignKey("Backend.DAL.Entities.GeneralInformationEntities.GeneralInformation", "PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend.DAL.Entities.GeneralInformationEntities.SurgicalIntervention", b =>
                {
                    b.HasOne("Backend.DAL.Entities.GeneralInformationEntities.GeneralInformation", "GeneralInformation")
                        .WithMany("SurgicalIntervention")
                        .HasForeignKey("GeneralInformationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend.DAL.Entities.GeneralInformationEntities.VaccinationStatus", b =>
                {
                    b.HasOne("Backend.DAL.Entities.GeneralInformationEntities.GeneralInformation", "GeneralInformation")
                        .WithMany("VaccinationStatuses")
                        .HasForeignKey("GeneralInformationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend.DAL.Entities.InjuriesDiseasesEntities.InjuriesDiseases", b =>
                {
                    b.HasOne("Backend.DAL.Entities.InjuriesDiseasesEntities.DisabilityType", "DisabilityType")
                        .WithMany()
                        .HasForeignKey("DisabilityTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Backend.DAL.Entities.Patient", "Patient")
                        .WithMany("InjuriesDiseases")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend.DAL.Entities.MedicalExaminationEntities.DoctorsDiagnosis", b =>
                {
                    b.HasOne("Backend.DAL.Entities.MedicalExaminationEntities.MedicalExamination")
                        .WithMany("DoctorsDiagnoses")
                        .HasForeignKey("MedicalExaminationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Backend.DAL.Entities.Common.MedicalProfession", "MedicalProfession")
                        .WithMany()
                        .HasForeignKey("MedicalProfessionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend.DAL.Entities.MedicalExaminationEntities.MedicalExamination", b =>
                {
                    b.HasOne("Backend.DAL.Entities.Patient", "Patient")
                        .WithMany("MedicalExaminations")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Backend.DAL.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Backend.DAL.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Backend.DAL.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Backend.DAL.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
