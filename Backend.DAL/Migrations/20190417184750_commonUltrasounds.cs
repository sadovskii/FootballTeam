using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.DAL.Migrations
{
    public partial class commonUltrasounds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HeartUltrasound_InjuriesDiseases_InjuriesDiseasesId",
                table: "HeartUltrasound");

            migrationBuilder.DropForeignKey(
                name: "FK_HeartUltrasound_MedicalExamination_MedicalExaminationId",
                table: "HeartUltrasound");

            migrationBuilder.DropIndex(
                name: "IX_HeartUltrasound_InjuriesDiseasesId",
                table: "HeartUltrasound");

            migrationBuilder.DropColumn(
                name: "InjuriesDiseasesId",
                table: "HeartUltrasound");

            migrationBuilder.AlterColumn<int>(
                name: "MedicalExaminationId",
                table: "HeartUltrasound",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CommonUltrasounds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Info = table.Column<string>(nullable: true),
                    InjuriesDiseasesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommonUltrasounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommonUltrasounds_InjuriesDiseases_InjuriesDiseasesId",
                        column: x => x.InjuriesDiseasesId,
                        principalTable: "InjuriesDiseases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommonUltrasounds_InjuriesDiseasesId",
                table: "CommonUltrasounds",
                column: "InjuriesDiseasesId");

            migrationBuilder.AddForeignKey(
                name: "FK_HeartUltrasound_MedicalExamination_MedicalExaminationId",
                table: "HeartUltrasound",
                column: "MedicalExaminationId",
                principalTable: "MedicalExamination",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HeartUltrasound_MedicalExamination_MedicalExaminationId",
                table: "HeartUltrasound");

            migrationBuilder.DropTable(
                name: "CommonUltrasounds");

            migrationBuilder.AlterColumn<int>(
                name: "MedicalExaminationId",
                table: "HeartUltrasound",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "InjuriesDiseasesId",
                table: "HeartUltrasound",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HeartUltrasound_InjuriesDiseasesId",
                table: "HeartUltrasound",
                column: "InjuriesDiseasesId");

            migrationBuilder.AddForeignKey(
                name: "FK_HeartUltrasound_InjuriesDiseases_InjuriesDiseasesId",
                table: "HeartUltrasound",
                column: "InjuriesDiseasesId",
                principalTable: "InjuriesDiseases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HeartUltrasound_MedicalExamination_MedicalExaminationId",
                table: "HeartUltrasound",
                column: "MedicalExaminationId",
                principalTable: "MedicalExamination",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
