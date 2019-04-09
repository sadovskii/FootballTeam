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
    [Migration("20190407091006_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Backend.DAL.Entities.Common.InstrumentalStudies.Electrocardiogram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Info");

                    b.Property<int?>("MedicalExaminationId");

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

                    b.Property<int?>("InjuriesDiseasesId");

                    b.Property<int?>("MedicalExaminationId");

                    b.HasKey("Id");

                    b.HasIndex("InjuriesDiseasesId");

                    b.HasIndex("MedicalExaminationId");

                    b.ToTable("HeartUltrasound");
                });

            modelBuilder.Entity("Backend.DAL.Entities.Common.InstrumentalStudies.MRI", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Info");

                    b.Property<int?>("InjuriesDiseasesId");

                    b.HasKey("Id");

                    b.HasIndex("InjuriesDiseasesId");

                    b.ToTable("MRI");
                });

            modelBuilder.Entity("Backend.DAL.Entities.Common.LaboratoryResearch.BloodChemistryAnalysis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Info");

                    b.Property<int?>("MedicalExaminationId");

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

                    b.Property<int?>("MedicalExaminationId");

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

                    b.Property<int?>("MedicalExaminationId");

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

                    b.ToTable("MedicalProfession");
                });

            modelBuilder.Entity("Backend.DAL.Entities.GeneralInformationEntities.Fluorography", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GeneralInformationId");

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

                    b.Property<int?>("GeneralInformationId");

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

                    b.Property<int?>("GeneralInformationId");

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

                    b.Property<int?>("DisabilityTypeId");

                    b.Property<string>("DrugTherapy");

                    b.Property<string>("Other");

                    b.Property<int?>("PatientId");

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

                    b.Property<int?>("MedicalExaminationId");

                    b.Property<int?>("MedicalProfessionId");

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

                    b.Property<int?>("PatientId");

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

            modelBuilder.Entity("Backend.DAL.Entities.Common.InstrumentalStudies.Electrocardiogram", b =>
                {
                    b.HasOne("Backend.DAL.Entities.MedicalExaminationEntities.MedicalExamination", "MedicalExamination")
                        .WithMany("Electrocardiograms")
                        .HasForeignKey("MedicalExaminationId");
                });

            modelBuilder.Entity("Backend.DAL.Entities.Common.InstrumentalStudies.HeartUltrasound", b =>
                {
                    b.HasOne("Backend.DAL.Entities.InjuriesDiseasesEntities.InjuriesDiseases")
                        .WithMany("HeartUltrasounds")
                        .HasForeignKey("InjuriesDiseasesId");

                    b.HasOne("Backend.DAL.Entities.MedicalExaminationEntities.MedicalExamination", "MedicalExamination")
                        .WithMany("HeartUltrasounds")
                        .HasForeignKey("MedicalExaminationId");
                });

            modelBuilder.Entity("Backend.DAL.Entities.Common.InstrumentalStudies.MRI", b =>
                {
                    b.HasOne("Backend.DAL.Entities.InjuriesDiseasesEntities.InjuriesDiseases", "InjuriesDiseases")
                        .WithMany("MRIs")
                        .HasForeignKey("InjuriesDiseasesId");
                });

            modelBuilder.Entity("Backend.DAL.Entities.Common.LaboratoryResearch.BloodChemistryAnalysis", b =>
                {
                    b.HasOne("Backend.DAL.Entities.MedicalExaminationEntities.MedicalExamination", "MedicalExamination")
                        .WithMany("BloodChemistryAnalyses")
                        .HasForeignKey("MedicalExaminationId");
                });

            modelBuilder.Entity("Backend.DAL.Entities.Common.LaboratoryResearch.GeneralBloodAnalysis", b =>
                {
                    b.HasOne("Backend.DAL.Entities.MedicalExaminationEntities.MedicalExamination", "MedicalExamination")
                        .WithMany("GeneralBloodAnalyses")
                        .HasForeignKey("MedicalExaminationId");
                });

            modelBuilder.Entity("Backend.DAL.Entities.Common.LaboratoryResearch.GeneralUrineAnalysis", b =>
                {
                    b.HasOne("Backend.DAL.Entities.MedicalExaminationEntities.MedicalExamination", "MedicalExamination")
                        .WithMany("GeneralUrineAnalyses")
                        .HasForeignKey("MedicalExaminationId");
                });

            modelBuilder.Entity("Backend.DAL.Entities.GeneralInformationEntities.Fluorography", b =>
                {
                    b.HasOne("Backend.DAL.Entities.GeneralInformationEntities.GeneralInformation", "GeneralInformation")
                        .WithMany("Fluorographies")
                        .HasForeignKey("GeneralInformationId");
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
                        .HasForeignKey("GeneralInformationId");
                });

            modelBuilder.Entity("Backend.DAL.Entities.GeneralInformationEntities.VaccinationStatus", b =>
                {
                    b.HasOne("Backend.DAL.Entities.GeneralInformationEntities.GeneralInformation", "GeneralInformation")
                        .WithMany("VaccinationStatuses")
                        .HasForeignKey("GeneralInformationId");
                });

            modelBuilder.Entity("Backend.DAL.Entities.InjuriesDiseasesEntities.InjuriesDiseases", b =>
                {
                    b.HasOne("Backend.DAL.Entities.InjuriesDiseasesEntities.DisabilityType", "DisabilityType")
                        .WithMany("InjuriesDiseases")
                        .HasForeignKey("DisabilityTypeId");

                    b.HasOne("Backend.DAL.Entities.Patient", "Patient")
                        .WithMany("InjuriesDiseases")
                        .HasForeignKey("PatientId");
                });

            modelBuilder.Entity("Backend.DAL.Entities.MedicalExaminationEntities.DoctorsDiagnosis", b =>
                {
                    b.HasOne("Backend.DAL.Entities.MedicalExaminationEntities.MedicalExamination", "MedicalExamination")
                        .WithMany("DoctorsDiagnoses")
                        .HasForeignKey("MedicalExaminationId");

                    b.HasOne("Backend.DAL.Entities.Common.MedicalProfession", "MedicalProfession")
                        .WithMany("DoctorsDiagnosis")
                        .HasForeignKey("MedicalProfessionId");
                });

            modelBuilder.Entity("Backend.DAL.Entities.MedicalExaminationEntities.MedicalExamination", b =>
                {
                    b.HasOne("Backend.DAL.Entities.Patient", "Patient")
                        .WithMany("MedicalExaminations")
                        .HasForeignKey("PatientId");
                });
#pragma warning restore 612, 618
        }
    }
}
