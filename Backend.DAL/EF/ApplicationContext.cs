using Backend.DAL.Entities;
using Backend.DAL.Entities.Common;
using Backend.DAL.Entities.Common.InstrumentalStudies;
using Backend.DAL.Entities.Common.LaboratoryResearch;
using Backend.DAL.Entities.GeneralInformationEntities;
using Backend.DAL.Entities.InjuriesDiseasesEntities;
using Backend.DAL.Entities.MedicalExaminationEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.DAL.EF
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<GeneralInformation> GeneralInformation { get; set; }
        public DbSet<Fluorography> Fluorographies { get; set; }
        public DbSet<VaccinationStatus> VaccinationStatuses { get; set; }
        public DbSet<SurgicalIntervention> SurgicalInterventions { get; set; }
        public DbSet<InjuriesDiseases> InjuriesDiseases { get; set; }
        public DbSet<DisabilityType> DisabilityTypes { get; set; }
        public DbSet<MRI> MRIs { get; set; }
        public DbSet<HeartUltrasound> HeartUltrasounds { get; set; }
        public DbSet<CommonUltrasound> CommonUltrasounds { get; set; }
        public DbSet<MedicalExamination> MedicalExaminations { get; set; }
        public DbSet<DoctorsDiagnosis> DoctorsDiagnoses { get; set; }
        public DbSet<BloodChemistryAnalysis> BloodChemistryAnalyses { get; set; }  
        public DbSet<GeneralBloodAnalysis> GeneralBloodAnalyses { get; set; }
        public DbSet<GeneralUrineAnalysis> GeneralUrineAnalyses { get; set; }
        public DbSet<Electrocardiogram> Electrocardiograms { get; set; }
        public DbSet<Radiography> Radiographies { get; set; }
        public DbSet<MedicalProfession> MedicalProfessions { get; set; }



        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Patient>().ToTable(nameof(Patient))  
                .HasOne(a => a.GeneralInformation)
                .WithOne(t => t.Patient)
                .HasForeignKey<GeneralInformation>(e => e.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<GeneralInformation>().ToTable(nameof(GeneralInformation));
            builder.Entity<Fluorography>().ToTable(nameof(Fluorography));
            builder.Entity<VaccinationStatus>().ToTable(nameof(VaccinationStatus));
            builder.Entity<SurgicalIntervention>().ToTable(nameof(SurgicalIntervention));
            builder.Entity<InjuriesDiseases>().ToTable(nameof(Entities.InjuriesDiseasesEntities.InjuriesDiseases));
            builder.Entity<DisabilityType>().ToTable(nameof(DisabilityType));
            builder.Entity<MRI>().ToTable(nameof(MRI));
            builder.Entity<HeartUltrasound>().ToTable(nameof(HeartUltrasound));
            builder.Entity<MedicalExamination>().ToTable(nameof(MedicalExamination));
            builder.Entity<DoctorsDiagnosis>().ToTable(nameof(DoctorsDiagnosis));
            builder.Entity<BloodChemistryAnalysis>().ToTable(nameof(BloodChemistryAnalysis));
            builder.Entity<GeneralBloodAnalysis>().ToTable(nameof(GeneralBloodAnalysis));
            builder.Entity<GeneralUrineAnalysis>().ToTable(nameof(GeneralUrineAnalysis));
            builder.Entity<Electrocardiogram>().ToTable(nameof(Electrocardiogram));
        }
    }
}