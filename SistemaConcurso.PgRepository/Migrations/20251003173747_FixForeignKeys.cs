using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaConcurso.PgRepository.Migrations
{
    /// <inheritdoc />
    public partial class FixForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_exams_users_userid",
                table: "exams");

            migrationBuilder.DropForeignKey(
                name: "FK_jobroles_exams_examid",
                table: "jobroles");

            migrationBuilder.DropForeignKey(
                name: "FK_lessons_modules_moduleid",
                table: "lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_modules_roadmaps_roadmapid",
                table: "modules");

            migrationBuilder.DropForeignKey(
                name: "FK_questions_lessonassessment_lessonassessmentid",
                table: "questions");

            migrationBuilder.DropForeignKey(
                name: "FK_questions_moduleassessment_moduleassessmentid",
                table: "questions");

            migrationBuilder.DropForeignKey(
                name: "FK_questions_roadmapquestions_roadmapassessmentid",
                table: "questions");

            migrationBuilder.DropForeignKey(
                name: "FK_roadmapquestions_roadmaps_roadmapid",
                table: "roadmapquestions");

            migrationBuilder.DropForeignKey(
                name: "FK_roadmaps_exams_examid",
                table: "roadmaps");

            migrationBuilder.DropForeignKey(
                name: "FK_roadmaps_jobroles_selectedjobroleid",
                table: "roadmaps");

            migrationBuilder.DropTable(
                name: "lessonassessment");

            migrationBuilder.DropTable(
                name: "moduleassessment");

            migrationBuilder.DropIndex(
                name: "IX_roadmaps_examid",
                table: "roadmaps");

            migrationBuilder.DropIndex(
                name: "IX_roadmaps_selectedjobroleid",
                table: "roadmaps");

            migrationBuilder.DropIndex(
                name: "IX_roadmapquestions_roadmapid",
                table: "roadmapquestions");

            migrationBuilder.DropIndex(
                name: "IX_questions_lessonassessmentid",
                table: "questions");

            migrationBuilder.DropIndex(
                name: "IX_questions_moduleassessmentid",
                table: "questions");

            migrationBuilder.DropIndex(
                name: "IX_questions_roadmapassessmentid",
                table: "questions");

            migrationBuilder.DropIndex(
                name: "IX_modules_roadmapid",
                table: "modules");

            migrationBuilder.DropIndex(
                name: "IX_lessons_moduleid",
                table: "lessons");

            migrationBuilder.DropIndex(
                name: "IX_jobroles_examid",
                table: "jobroles");

            migrationBuilder.DropIndex(
                name: "IX_exams_userid",
                table: "exams");

            migrationBuilder.DropColumn(
                name: "examid",
                table: "roadmaps");

            migrationBuilder.DropColumn(
                name: "selectedjobroleid",
                table: "roadmaps");

            migrationBuilder.DropColumn(
                name: "roadmapid",
                table: "roadmapquestions");

            migrationBuilder.DropColumn(
                name: "lessonassessmentid",
                table: "questions");

            migrationBuilder.DropColumn(
                name: "moduleassessmentid",
                table: "questions");

            migrationBuilder.DropColumn(
                name: "roadmapassessmentid",
                table: "questions");

            migrationBuilder.DropColumn(
                name: "roadmapid",
                table: "modules");

            migrationBuilder.DropColumn(
                name: "moduleid",
                table: "lessons");

            migrationBuilder.DropColumn(
                name: "examid",
                table: "jobroles");

            migrationBuilder.DropColumn(
                name: "userid",
                table: "exams");

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "roadmaps",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "noticetitle",
                table: "exams",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "noticedescription",
                table: "exams",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "notice",
                table: "exams",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "lessonassessments",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    retriescount = table.Column<int>(type: "integer", nullable: false),
                    idlesson = table.Column<int>(type: "integer", nullable: false),
                    removed = table.Column<bool>(type: "boolean", nullable: false),
                    registerdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    lastupdatedate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lessonassessments", x => x.id);
                    table.ForeignKey(
                        name: "FK_lessonassessments_lessons_idlesson",
                        column: x => x.idlesson,
                        principalTable: "lessons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "moduleassessments",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    retriescount = table.Column<int>(type: "integer", nullable: false),
                    idmodule = table.Column<int>(type: "integer", nullable: false),
                    removed = table.Column<bool>(type: "boolean", nullable: false),
                    registerdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    lastupdatedate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_moduleassessments", x => x.id);
                    table.ForeignKey(
                        name: "FK_moduleassessments_modules_idmodule",
                        column: x => x.idmodule,
                        principalTable: "modules",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_roadmaps_idexam",
                table: "roadmaps",
                column: "idexam");

            migrationBuilder.CreateIndex(
                name: "IX_roadmaps_idselectedjobrole",
                table: "roadmaps",
                column: "idselectedjobrole");

            migrationBuilder.CreateIndex(
                name: "IX_roadmapquestions_idroadmap",
                table: "roadmapquestions",
                column: "idroadmap");

            migrationBuilder.CreateIndex(
                name: "IX_questions_idlessonassessment",
                table: "questions",
                column: "idlessonassessment");

            migrationBuilder.CreateIndex(
                name: "IX_questions_idmoduleassessment",
                table: "questions",
                column: "idmoduleassessment");

            migrationBuilder.CreateIndex(
                name: "IX_questions_idroadmapassessment",
                table: "questions",
                column: "idroadmapassessment");

            migrationBuilder.CreateIndex(
                name: "IX_modules_idroadmap",
                table: "modules",
                column: "idroadmap");

            migrationBuilder.CreateIndex(
                name: "IX_lessons_idmodule",
                table: "lessons",
                column: "idmodule");

            migrationBuilder.CreateIndex(
                name: "IX_jobroles_idexam",
                table: "jobroles",
                column: "idexam");

            migrationBuilder.CreateIndex(
                name: "IX_exams_iduser",
                table: "exams",
                column: "iduser");

            migrationBuilder.CreateIndex(
                name: "IX_lessonassessments_idlesson",
                table: "lessonassessments",
                column: "idlesson");

            migrationBuilder.CreateIndex(
                name: "IX_moduleassessments_idmodule",
                table: "moduleassessments",
                column: "idmodule");

            migrationBuilder.AddForeignKey(
                name: "FK_exams_users_iduser",
                table: "exams",
                column: "iduser",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_jobroles_exams_idexam",
                table: "jobroles",
                column: "idexam",
                principalTable: "exams",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_lessons_modules_idmodule",
                table: "lessons",
                column: "idmodule",
                principalTable: "modules",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_modules_roadmaps_idroadmap",
                table: "modules",
                column: "idroadmap",
                principalTable: "roadmaps",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_questions_lessonassessments_idlessonassessment",
                table: "questions",
                column: "idlessonassessment",
                principalTable: "lessonassessments",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_questions_moduleassessments_idmoduleassessment",
                table: "questions",
                column: "idmoduleassessment",
                principalTable: "moduleassessments",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_questions_roadmapquestions_idroadmapassessment",
                table: "questions",
                column: "idroadmapassessment",
                principalTable: "roadmapquestions",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_roadmapquestions_roadmaps_idroadmap",
                table: "roadmapquestions",
                column: "idroadmap",
                principalTable: "roadmaps",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_roadmaps_exams_idexam",
                table: "roadmaps",
                column: "idexam",
                principalTable: "exams",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_roadmaps_jobroles_idselectedjobrole",
                table: "roadmaps",
                column: "idselectedjobrole",
                principalTable: "jobroles",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_exams_users_iduser",
                table: "exams");

            migrationBuilder.DropForeignKey(
                name: "FK_jobroles_exams_idexam",
                table: "jobroles");

            migrationBuilder.DropForeignKey(
                name: "FK_lessons_modules_idmodule",
                table: "lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_modules_roadmaps_idroadmap",
                table: "modules");

            migrationBuilder.DropForeignKey(
                name: "FK_questions_lessonassessments_idlessonassessment",
                table: "questions");

            migrationBuilder.DropForeignKey(
                name: "FK_questions_moduleassessments_idmoduleassessment",
                table: "questions");

            migrationBuilder.DropForeignKey(
                name: "FK_questions_roadmapquestions_idroadmapassessment",
                table: "questions");

            migrationBuilder.DropForeignKey(
                name: "FK_roadmapquestions_roadmaps_idroadmap",
                table: "roadmapquestions");

            migrationBuilder.DropForeignKey(
                name: "FK_roadmaps_exams_idexam",
                table: "roadmaps");

            migrationBuilder.DropForeignKey(
                name: "FK_roadmaps_jobroles_idselectedjobrole",
                table: "roadmaps");

            migrationBuilder.DropTable(
                name: "lessonassessments");

            migrationBuilder.DropTable(
                name: "moduleassessments");

            migrationBuilder.DropIndex(
                name: "IX_roadmaps_idexam",
                table: "roadmaps");

            migrationBuilder.DropIndex(
                name: "IX_roadmaps_idselectedjobrole",
                table: "roadmaps");

            migrationBuilder.DropIndex(
                name: "IX_roadmapquestions_idroadmap",
                table: "roadmapquestions");

            migrationBuilder.DropIndex(
                name: "IX_questions_idlessonassessment",
                table: "questions");

            migrationBuilder.DropIndex(
                name: "IX_questions_idmoduleassessment",
                table: "questions");

            migrationBuilder.DropIndex(
                name: "IX_questions_idroadmapassessment",
                table: "questions");

            migrationBuilder.DropIndex(
                name: "IX_modules_idroadmap",
                table: "modules");

            migrationBuilder.DropIndex(
                name: "IX_lessons_idmodule",
                table: "lessons");

            migrationBuilder.DropIndex(
                name: "IX_jobroles_idexam",
                table: "jobroles");

            migrationBuilder.DropIndex(
                name: "IX_exams_iduser",
                table: "exams");

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "roadmaps",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "examid",
                table: "roadmaps",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "selectedjobroleid",
                table: "roadmaps",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "roadmapid",
                table: "roadmapquestions",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "lessonassessmentid",
                table: "questions",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "moduleassessmentid",
                table: "questions",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "roadmapassessmentid",
                table: "questions",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "roadmapid",
                table: "modules",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "moduleid",
                table: "lessons",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "examid",
                table: "jobroles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "noticetitle",
                table: "exams",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "noticedescription",
                table: "exams",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "notice",
                table: "exams",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "userid",
                table: "exams",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "lessonassessment",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lessonid = table.Column<int>(type: "integer", nullable: true),
                    idlesson = table.Column<int>(type: "integer", nullable: false),
                    lastupdatedate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    registerdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    removed = table.Column<bool>(type: "boolean", nullable: false),
                    retriescount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lessonassessment", x => x.id);
                    table.ForeignKey(
                        name: "FK_lessonassessment_lessons_lessonid",
                        column: x => x.lessonid,
                        principalTable: "lessons",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "moduleassessment",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    moduleid = table.Column<int>(type: "integer", nullable: true),
                    idmodule = table.Column<int>(type: "integer", nullable: false),
                    lastupdatedate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    registerdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    removed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_moduleassessment", x => x.id);
                    table.ForeignKey(
                        name: "FK_moduleassessment_modules_moduleid",
                        column: x => x.moduleid,
                        principalTable: "modules",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_roadmaps_examid",
                table: "roadmaps",
                column: "examid");

            migrationBuilder.CreateIndex(
                name: "IX_roadmaps_selectedjobroleid",
                table: "roadmaps",
                column: "selectedjobroleid");

            migrationBuilder.CreateIndex(
                name: "IX_roadmapquestions_roadmapid",
                table: "roadmapquestions",
                column: "roadmapid");

            migrationBuilder.CreateIndex(
                name: "IX_questions_lessonassessmentid",
                table: "questions",
                column: "lessonassessmentid");

            migrationBuilder.CreateIndex(
                name: "IX_questions_moduleassessmentid",
                table: "questions",
                column: "moduleassessmentid");

            migrationBuilder.CreateIndex(
                name: "IX_questions_roadmapassessmentid",
                table: "questions",
                column: "roadmapassessmentid");

            migrationBuilder.CreateIndex(
                name: "IX_modules_roadmapid",
                table: "modules",
                column: "roadmapid");

            migrationBuilder.CreateIndex(
                name: "IX_lessons_moduleid",
                table: "lessons",
                column: "moduleid");

            migrationBuilder.CreateIndex(
                name: "IX_jobroles_examid",
                table: "jobroles",
                column: "examid");

            migrationBuilder.CreateIndex(
                name: "IX_exams_userid",
                table: "exams",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_lessonassessment_lessonid",
                table: "lessonassessment",
                column: "lessonid");

            migrationBuilder.CreateIndex(
                name: "IX_moduleassessment_moduleid",
                table: "moduleassessment",
                column: "moduleid");

            migrationBuilder.AddForeignKey(
                name: "FK_exams_users_userid",
                table: "exams",
                column: "userid",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_jobroles_exams_examid",
                table: "jobroles",
                column: "examid",
                principalTable: "exams",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_lessons_modules_moduleid",
                table: "lessons",
                column: "moduleid",
                principalTable: "modules",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_modules_roadmaps_roadmapid",
                table: "modules",
                column: "roadmapid",
                principalTable: "roadmaps",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_questions_lessonassessment_lessonassessmentid",
                table: "questions",
                column: "lessonassessmentid",
                principalTable: "lessonassessment",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_questions_moduleassessment_moduleassessmentid",
                table: "questions",
                column: "moduleassessmentid",
                principalTable: "moduleassessment",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_questions_roadmapquestions_roadmapassessmentid",
                table: "questions",
                column: "roadmapassessmentid",
                principalTable: "roadmapquestions",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_roadmapquestions_roadmaps_roadmapid",
                table: "roadmapquestions",
                column: "roadmapid",
                principalTable: "roadmaps",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_roadmaps_exams_examid",
                table: "roadmaps",
                column: "examid",
                principalTable: "exams",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_roadmaps_jobroles_selectedjobroleid",
                table: "roadmaps",
                column: "selectedjobroleid",
                principalTable: "jobroles",
                principalColumn: "id");
        }
    }
}
