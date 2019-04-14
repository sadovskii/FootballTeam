using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.DAL.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BloodChemistryAnalysis_MedicalExamination_MedicalExaminationId",
                table: "BloodChemistryAnalysis");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorsDiagnosis_MedicalExamination_MedicalExaminationId",
                table: "DoctorsDiagnosis");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorsDiagnosis_MedicalProfession_MedicalProfessionId",
                table: "DoctorsDiagnosis");

            migrationBuilder.DropForeignKey(
                name: "FK_Electrocardiogram_MedicalExamination_MedicalExaminationId",
                table: "Electrocardiogram");

            migrationBuilder.DropForeignKey(
                name: "FK_Fluorography_GeneralInformation_GeneralInformationId",
                table: "Fluorography");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralBloodAnalysis_MedicalExamination_MedicalExaminationId",
                table: "GeneralBloodAnalysis");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralUrineAnalysis_MedicalExamination_MedicalExaminationId",
                table: "GeneralUrineAnalysis");

            migrationBuilder.DropForeignKey(
                name: "FK_HeartUltrasound_MedicalExamination_MedicalExaminationId",
                table: "HeartUltrasound");

            migrationBuilder.DropForeignKey(
                name: "FK_InjuriesDiseases_DisabilityType_DisabilityTypeId",
                table: "InjuriesDiseases");

            migrationBuilder.DropForeignKey(
                name: "FK_InjuriesDiseases_Patient_PatientId",
                table: "InjuriesDiseases");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalExamination_Patient_PatientId",
                table: "MedicalExamination");

            migrationBuilder.DropForeignKey(
                name: "FK_MRI_InjuriesDiseases_InjuriesDiseasesId",
                table: "MRI");

            migrationBuilder.DropForeignKey(
                name: "FK_SurgicalIntervention_GeneralInformation_GeneralInformationId",
                table: "SurgicalIntervention");

            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationStatus_GeneralInformation_GeneralInformationId",
                table: "VaccinationStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalProfession",
                table: "MedicalProfession");

            migrationBuilder.RenameTable(
                name: "MedicalProfession",
                newName: "medicalProfessions");

            migrationBuilder.AlterColumn<int>(
                name: "GeneralInformationId",
                table: "VaccinationStatus",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GeneralInformationId",
                table: "SurgicalIntervention",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InjuriesDiseasesId",
                table: "MRI",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "MedicalExamination",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "InjuriesDiseases",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DisabilityTypeId",
                table: "InjuriesDiseases",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MedicalExaminationId",
                table: "HeartUltrasound",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MedicalExaminationId",
                table: "GeneralUrineAnalysis",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MedicalExaminationId",
                table: "GeneralBloodAnalysis",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GeneralInformationId",
                table: "Fluorography",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MedicalExaminationId",
                table: "Electrocardiogram",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MedicalProfessionId",
                table: "DoctorsDiagnosis",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MedicalExaminationId",
                table: "DoctorsDiagnosis",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MedicalExaminationId",
                table: "BloodChemistryAnalysis",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_medicalProfessions",
                table: "medicalProfessions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Radiographies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Info = table.Column<string>(nullable: true),
                    InjuriesDiseasesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radiographies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Radiographies_InjuriesDiseases_InjuriesDiseasesId",
                        column: x => x.InjuriesDiseasesId,
                        principalTable: "InjuriesDiseases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Radiographies_InjuriesDiseasesId",
                table: "Radiographies",
                column: "InjuriesDiseasesId");

            migrationBuilder.AddForeignKey(
                name: "FK_BloodChemistryAnalysis_MedicalExamination_MedicalExaminationId",
                table: "BloodChemistryAnalysis",
                column: "MedicalExaminationId",
                principalTable: "MedicalExamination",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorsDiagnosis_MedicalExamination_MedicalExaminationId",
                table: "DoctorsDiagnosis",
                column: "MedicalExaminationId",
                principalTable: "MedicalExamination",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorsDiagnosis_medicalProfessions_MedicalProfessionId",
                table: "DoctorsDiagnosis",
                column: "MedicalProfessionId",
                principalTable: "medicalProfessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Electrocardiogram_MedicalExamination_MedicalExaminationId",
                table: "Electrocardiogram",
                column: "MedicalExaminationId",
                principalTable: "MedicalExamination",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluorography_GeneralInformation_GeneralInformationId",
                table: "Fluorography",
                column: "GeneralInformationId",
                principalTable: "GeneralInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralBloodAnalysis_MedicalExamination_MedicalExaminationId",
                table: "GeneralBloodAnalysis",
                column: "MedicalExaminationId",
                principalTable: "MedicalExamination",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralUrineAnalysis_MedicalExamination_MedicalExaminationId",
                table: "GeneralUrineAnalysis",
                column: "MedicalExaminationId",
                principalTable: "MedicalExamination",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HeartUltrasound_MedicalExamination_MedicalExaminationId",
                table: "HeartUltrasound",
                column: "MedicalExaminationId",
                principalTable: "MedicalExamination",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InjuriesDiseases_DisabilityType_DisabilityTypeId",
                table: "InjuriesDiseases",
                column: "DisabilityTypeId",
                principalTable: "DisabilityType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InjuriesDiseases_Patient_PatientId",
                table: "InjuriesDiseases",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalExamination_Patient_PatientId",
                table: "MedicalExamination",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MRI_InjuriesDiseases_InjuriesDiseasesId",
                table: "MRI",
                column: "InjuriesDiseasesId",
                principalTable: "InjuriesDiseases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SurgicalIntervention_GeneralInformation_GeneralInformationId",
                table: "SurgicalIntervention",
                column: "GeneralInformationId",
                principalTable: "GeneralInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VaccinationStatus_GeneralInformation_GeneralInformationId",
                table: "VaccinationStatus",
                column: "GeneralInformationId",
                principalTable: "GeneralInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BloodChemistryAnalysis_MedicalExamination_MedicalExaminationId",
                table: "BloodChemistryAnalysis");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorsDiagnosis_MedicalExamination_MedicalExaminationId",
                table: "DoctorsDiagnosis");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorsDiagnosis_medicalProfessions_MedicalProfessionId",
                table: "DoctorsDiagnosis");

            migrationBuilder.DropForeignKey(
                name: "FK_Electrocardiogram_MedicalExamination_MedicalExaminationId",
                table: "Electrocardiogram");

            migrationBuilder.DropForeignKey(
                name: "FK_Fluorography_GeneralInformation_GeneralInformationId",
                table: "Fluorography");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralBloodAnalysis_MedicalExamination_MedicalExaminationId",
                table: "GeneralBloodAnalysis");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralUrineAnalysis_MedicalExamination_MedicalExaminationId",
                table: "GeneralUrineAnalysis");

            migrationBuilder.DropForeignKey(
                name: "FK_HeartUltrasound_MedicalExamination_MedicalExaminationId",
                table: "HeartUltrasound");

            migrationBuilder.DropForeignKey(
                name: "FK_InjuriesDiseases_DisabilityType_DisabilityTypeId",
                table: "InjuriesDiseases");

            migrationBuilder.DropForeignKey(
                name: "FK_InjuriesDiseases_Patient_PatientId",
                table: "InjuriesDiseases");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalExamination_Patient_PatientId",
                table: "MedicalExamination");

            migrationBuilder.DropForeignKey(
                name: "FK_MRI_InjuriesDiseases_InjuriesDiseasesId",
                table: "MRI");

            migrationBuilder.DropForeignKey(
                name: "FK_SurgicalIntervention_GeneralInformation_GeneralInformationId",
                table: "SurgicalIntervention");

            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationStatus_GeneralInformation_GeneralInformationId",
                table: "VaccinationStatus");

            migrationBuilder.DropTable(
                name: "Radiographies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_medicalProfessions",
                table: "medicalProfessions");

            migrationBuilder.RenameTable(
                name: "medicalProfessions",
                newName: "MedicalProfession");

            migrationBuilder.AlterColumn<int>(
                name: "GeneralInformationId",
                table: "VaccinationStatus",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "GeneralInformationId",
                table: "SurgicalIntervention",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "InjuriesDiseasesId",
                table: "MRI",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "MedicalExamination",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "InjuriesDiseases",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DisabilityTypeId",
                table: "InjuriesDiseases",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MedicalExaminationId",
                table: "HeartUltrasound",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MedicalExaminationId",
                table: "GeneralUrineAnalysis",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MedicalExaminationId",
                table: "GeneralBloodAnalysis",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "GeneralInformationId",
                table: "Fluorography",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MedicalExaminationId",
                table: "Electrocardiogram",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MedicalProfessionId",
                table: "DoctorsDiagnosis",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MedicalExaminationId",
                table: "DoctorsDiagnosis",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MedicalExaminationId",
                table: "BloodChemistryAnalysis",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalProfession",
                table: "MedicalProfession",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BloodChemistryAnalysis_MedicalExamination_MedicalExaminationId",
                table: "BloodChemistryAnalysis",
                column: "MedicalExaminationId",
                principalTable: "MedicalExamination",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorsDiagnosis_MedicalExamination_MedicalExaminationId",
                table: "DoctorsDiagnosis",
                column: "MedicalExaminationId",
                principalTable: "MedicalExamination",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorsDiagnosis_MedicalProfession_MedicalProfessionId",
                table: "DoctorsDiagnosis",
                column: "MedicalProfessionId",
                principalTable: "MedicalProfession",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Electrocardiogram_MedicalExamination_MedicalExaminationId",
                table: "Electrocardiogram",
                column: "MedicalExaminationId",
                principalTable: "MedicalExamination",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluorography_GeneralInformation_GeneralInformationId",
                table: "Fluorography",
                column: "GeneralInformationId",
                principalTable: "GeneralInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralBloodAnalysis_MedicalExamination_MedicalExaminationId",
                table: "GeneralBloodAnalysis",
                column: "MedicalExaminationId",
                principalTable: "MedicalExamination",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralUrineAnalysis_MedicalExamination_MedicalExaminationId",
                table: "GeneralUrineAnalysis",
                column: "MedicalExaminationId",
                principalTable: "MedicalExamination",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HeartUltrasound_MedicalExamination_MedicalExaminationId",
                table: "HeartUltrasound",
                column: "MedicalExaminationId",
                principalTable: "MedicalExamination",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InjuriesDiseases_DisabilityType_DisabilityTypeId",
                table: "InjuriesDiseases",
                column: "DisabilityTypeId",
                principalTable: "DisabilityType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InjuriesDiseases_Patient_PatientId",
                table: "InjuriesDiseases",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalExamination_Patient_PatientId",
                table: "MedicalExamination",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MRI_InjuriesDiseases_InjuriesDiseasesId",
                table: "MRI",
                column: "InjuriesDiseasesId",
                principalTable: "InjuriesDiseases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurgicalIntervention_GeneralInformation_GeneralInformationId",
                table: "SurgicalIntervention",
                column: "GeneralInformationId",
                principalTable: "GeneralInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VaccinationStatus_GeneralInformation_GeneralInformationId",
                table: "VaccinationStatus",
                column: "GeneralInformationId",
                principalTable: "GeneralInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
