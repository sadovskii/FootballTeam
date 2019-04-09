using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.DAL.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DisabilityType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisabilityType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalProfession",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProfessionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalProfession", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GeneralInformation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bithday = table.Column<DateTime>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    Height = table.Column<double>(nullable: false),
                    ArterialPressure = table.Column<double>(nullable: false),
                    BloodType = table.Column<string>(nullable: true),
                    PatientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneralInformation_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InjuriesDiseases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateInjuriesOrDiseases = table.Column<DateTime>(nullable: false),
                    ReleasedInMainGroup = table.Column<DateTime>(nullable: false),
                    DisabilityCountDay = table.Column<int>(nullable: false),
                    Diagnosis = table.Column<string>(nullable: true),
                    DrugTherapy = table.Column<string>(nullable: true),
                    PhysiotherapyTreatment = table.Column<string>(nullable: true),
                    Other = table.Column<string>(nullable: true),
                    PatientId = table.Column<int>(nullable: true),
                    DisabilityTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InjuriesDiseases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InjuriesDiseases_DisabilityType_DisabilityTypeId",
                        column: x => x.DisabilityTypeId,
                        principalTable: "DisabilityType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InjuriesDiseases_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicalExamination",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProcedureTime = table.Column<DateTime>(nullable: false),
                    Allowance = table.Column<bool>(nullable: false),
                    PatientId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalExamination", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalExamination_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fluorography",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProcedureTime = table.Column<DateTime>(nullable: false),
                    Information = table.Column<string>(nullable: true),
                    GeneralInformationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluorography", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fluorography_GeneralInformation_GeneralInformationId",
                        column: x => x.GeneralInformationId,
                        principalTable: "GeneralInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SurgicalIntervention",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProcedureTime = table.Column<DateTime>(nullable: false),
                    Diagnosis = table.Column<string>(nullable: true),
                    InterventionType = table.Column<string>(nullable: true),
                    GeneralInformationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurgicalIntervention", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurgicalIntervention_GeneralInformation_GeneralInformationId",
                        column: x => x.GeneralInformationId,
                        principalTable: "GeneralInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VaccinationStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProcedureTime = table.Column<DateTime>(nullable: false),
                    Information = table.Column<string>(nullable: true),
                    GeneralInformationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VaccinationStatus_GeneralInformation_GeneralInformationId",
                        column: x => x.GeneralInformationId,
                        principalTable: "GeneralInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MRI",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Info = table.Column<string>(nullable: true),
                    InjuriesDiseasesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MRI", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MRI_InjuriesDiseases_InjuriesDiseasesId",
                        column: x => x.InjuriesDiseasesId,
                        principalTable: "InjuriesDiseases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BloodChemistryAnalysis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Info = table.Column<string>(nullable: true),
                    MedicalExaminationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodChemistryAnalysis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BloodChemistryAnalysis_MedicalExamination_MedicalExaminationId",
                        column: x => x.MedicalExaminationId,
                        principalTable: "MedicalExamination",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DoctorsDiagnosis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Diagnosis = table.Column<string>(nullable: true),
                    MedicalExaminationId = table.Column<int>(nullable: true),
                    MedicalProfessionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorsDiagnosis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorsDiagnosis_MedicalExamination_MedicalExaminationId",
                        column: x => x.MedicalExaminationId,
                        principalTable: "MedicalExamination",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DoctorsDiagnosis_MedicalProfession_MedicalProfessionId",
                        column: x => x.MedicalProfessionId,
                        principalTable: "MedicalProfession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Electrocardiogram",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Info = table.Column<string>(nullable: true),
                    MedicalExaminationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Electrocardiogram", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Electrocardiogram_MedicalExamination_MedicalExaminationId",
                        column: x => x.MedicalExaminationId,
                        principalTable: "MedicalExamination",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GeneralBloodAnalysis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Info = table.Column<string>(nullable: true),
                    MedicalExaminationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralBloodAnalysis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneralBloodAnalysis_MedicalExamination_MedicalExaminationId",
                        column: x => x.MedicalExaminationId,
                        principalTable: "MedicalExamination",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GeneralUrineAnalysis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Info = table.Column<string>(nullable: true),
                    MedicalExaminationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralUrineAnalysis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneralUrineAnalysis_MedicalExamination_MedicalExaminationId",
                        column: x => x.MedicalExaminationId,
                        principalTable: "MedicalExamination",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HeartUltrasound",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Info = table.Column<string>(nullable: true),
                    MedicalExaminationId = table.Column<int>(nullable: true),
                    InjuriesDiseasesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeartUltrasound", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeartUltrasound_InjuriesDiseases_InjuriesDiseasesId",
                        column: x => x.InjuriesDiseasesId,
                        principalTable: "InjuriesDiseases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HeartUltrasound_MedicalExamination_MedicalExaminationId",
                        column: x => x.MedicalExaminationId,
                        principalTable: "MedicalExamination",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BloodChemistryAnalysis_MedicalExaminationId",
                table: "BloodChemistryAnalysis",
                column: "MedicalExaminationId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorsDiagnosis_MedicalExaminationId",
                table: "DoctorsDiagnosis",
                column: "MedicalExaminationId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorsDiagnosis_MedicalProfessionId",
                table: "DoctorsDiagnosis",
                column: "MedicalProfessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Electrocardiogram_MedicalExaminationId",
                table: "Electrocardiogram",
                column: "MedicalExaminationId");

            migrationBuilder.CreateIndex(
                name: "IX_Fluorography_GeneralInformationId",
                table: "Fluorography",
                column: "GeneralInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralBloodAnalysis_MedicalExaminationId",
                table: "GeneralBloodAnalysis",
                column: "MedicalExaminationId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralInformation_PatientId",
                table: "GeneralInformation",
                column: "PatientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GeneralUrineAnalysis_MedicalExaminationId",
                table: "GeneralUrineAnalysis",
                column: "MedicalExaminationId");

            migrationBuilder.CreateIndex(
                name: "IX_HeartUltrasound_InjuriesDiseasesId",
                table: "HeartUltrasound",
                column: "InjuriesDiseasesId");

            migrationBuilder.CreateIndex(
                name: "IX_HeartUltrasound_MedicalExaminationId",
                table: "HeartUltrasound",
                column: "MedicalExaminationId");

            migrationBuilder.CreateIndex(
                name: "IX_InjuriesDiseases_DisabilityTypeId",
                table: "InjuriesDiseases",
                column: "DisabilityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InjuriesDiseases_PatientId",
                table: "InjuriesDiseases",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalExamination_PatientId",
                table: "MedicalExamination",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_MRI_InjuriesDiseasesId",
                table: "MRI",
                column: "InjuriesDiseasesId");

            migrationBuilder.CreateIndex(
                name: "IX_SurgicalIntervention_GeneralInformationId",
                table: "SurgicalIntervention",
                column: "GeneralInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationStatus_GeneralInformationId",
                table: "VaccinationStatus",
                column: "GeneralInformationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BloodChemistryAnalysis");

            migrationBuilder.DropTable(
                name: "DoctorsDiagnosis");

            migrationBuilder.DropTable(
                name: "Electrocardiogram");

            migrationBuilder.DropTable(
                name: "Fluorography");

            migrationBuilder.DropTable(
                name: "GeneralBloodAnalysis");

            migrationBuilder.DropTable(
                name: "GeneralUrineAnalysis");

            migrationBuilder.DropTable(
                name: "HeartUltrasound");

            migrationBuilder.DropTable(
                name: "MRI");

            migrationBuilder.DropTable(
                name: "SurgicalIntervention");

            migrationBuilder.DropTable(
                name: "VaccinationStatus");

            migrationBuilder.DropTable(
                name: "MedicalProfession");

            migrationBuilder.DropTable(
                name: "MedicalExamination");

            migrationBuilder.DropTable(
                name: "InjuriesDiseases");

            migrationBuilder.DropTable(
                name: "GeneralInformation");

            migrationBuilder.DropTable(
                name: "DisabilityType");

            migrationBuilder.DropTable(
                name: "Patient");
        }
    }
}
