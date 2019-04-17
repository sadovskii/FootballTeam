using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.DAL.Migrations
{
    public partial class nullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MedicalExaminationId",
                table: "HeartUltrasound",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "InjuriesDiseasesId",
                table: "HeartUltrasound",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MedicalExaminationId",
                table: "HeartUltrasound",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InjuriesDiseasesId",
                table: "HeartUltrasound",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
