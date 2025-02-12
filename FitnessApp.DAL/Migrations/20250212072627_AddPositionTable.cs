using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddPositionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacebookUrl",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "InstagramUrl",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "Specialization",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "TwitterUrl",
                table: "Trainers");

            migrationBuilder.AlterColumn<int>(
                name: "Experience",
                table: "Trainers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "Trainers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TrainerPosition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerPosition", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_PositionId",
                table: "Trainers",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainers_TrainerPosition_PositionId",
                table: "Trainers",
                column: "PositionId",
                principalTable: "TrainerPosition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainers_TrainerPosition_PositionId",
                table: "Trainers");

            migrationBuilder.DropTable(
                name: "TrainerPosition");

            migrationBuilder.DropIndex(
                name: "IX_Trainers_PositionId",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "Trainers");

            migrationBuilder.AlterColumn<string>(
                name: "Experience",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "FacebookUrl",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InstagramUrl",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Specialization",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TwitterUrl",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
