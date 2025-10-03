using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaConcurso.PgRepository.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "refreshtokens",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "text", nullable: false),
                    tokenhash = table.Column<string>(type: "text", nullable: false),
                    expires = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    revoked = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    replacedbytokenhash = table.Column<string>(type: "text", nullable: false),
                    removed = table.Column<bool>(type: "boolean", nullable: false),
                    registerdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    lastupdatedate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_refreshtokens", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fullname = table.Column<string>(type: "text", nullable: true),
                    username = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    removed = table.Column<bool>(type: "boolean", nullable: false),
                    registerdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    lastupdatedate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "exams",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    noticetitle = table.Column<string>(type: "text", nullable: true),
                    noticedescription = table.Column<string>(type: "text", nullable: true),
                    notice = table.Column<string>(type: "text", nullable: true),
                    iduser = table.Column<int>(type: "integer", nullable: false),
                    userid = table.Column<int>(type: "integer", nullable: true),
                    removed = table.Column<bool>(type: "boolean", nullable: false),
                    registerdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    lastupdatedate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exams", x => x.id);
                    table.ForeignKey(
                        name: "FK_exams_users_userid",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "jobroles",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    idexam = table.Column<int>(type: "integer", nullable: false),
                    examid = table.Column<int>(type: "integer", nullable: false),
                    removed = table.Column<bool>(type: "boolean", nullable: false),
                    registerdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    lastupdatedate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobroles", x => x.id);
                    table.ForeignKey(
                        name: "FK_jobroles_exams_examid",
                        column: x => x.examid,
                        principalTable: "exams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "roadmaps",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    idexam = table.Column<int>(type: "integer", nullable: false),
                    examid = table.Column<int>(type: "integer", nullable: false),
                    idselectedjobrole = table.Column<int>(type: "integer", nullable: true),
                    selectedjobroleid = table.Column<int>(type: "integer", nullable: true),
                    removed = table.Column<bool>(type: "boolean", nullable: false),
                    registerdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    lastupdatedate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roadmaps", x => x.id);
                    table.ForeignKey(
                        name: "FK_roadmaps_exams_examid",
                        column: x => x.examid,
                        principalTable: "exams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_roadmaps_jobroles_selectedjobroleid",
                        column: x => x.selectedjobroleid,
                        principalTable: "jobroles",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "modules",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    idroadmap = table.Column<int>(type: "integer", nullable: false),
                    roadmapid = table.Column<int>(type: "integer", nullable: true),
                    removed = table.Column<bool>(type: "boolean", nullable: false),
                    registerdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    lastupdatedate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modules", x => x.id);
                    table.ForeignKey(
                        name: "FK_modules_roadmaps_roadmapid",
                        column: x => x.roadmapid,
                        principalTable: "roadmaps",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "roadmapquestions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    retriescount = table.Column<int>(type: "integer", nullable: false),
                    idroadmap = table.Column<int>(type: "integer", nullable: false),
                    roadmapid = table.Column<int>(type: "integer", nullable: true),
                    removed = table.Column<bool>(type: "boolean", nullable: false),
                    registerdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    lastupdatedate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roadmapquestions", x => x.id);
                    table.ForeignKey(
                        name: "FK_roadmapquestions_roadmaps_roadmapid",
                        column: x => x.roadmapid,
                        principalTable: "roadmaps",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "lessons",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    done = table.Column<bool>(type: "boolean", nullable: false),
                    idmodule = table.Column<int>(type: "integer", nullable: false),
                    moduleid = table.Column<int>(type: "integer", nullable: true),
                    removed = table.Column<bool>(type: "boolean", nullable: false),
                    registerdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    lastupdatedate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lessons", x => x.id);
                    table.ForeignKey(
                        name: "FK_lessons_modules_moduleid",
                        column: x => x.moduleid,
                        principalTable: "modules",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "moduleassessment",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idmodule = table.Column<int>(type: "integer", nullable: false),
                    moduleid = table.Column<int>(type: "integer", nullable: true),
                    removed = table.Column<bool>(type: "boolean", nullable: false),
                    registerdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    lastupdatedate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "lessonassessment",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    retriescount = table.Column<int>(type: "integer", nullable: false),
                    idlesson = table.Column<int>(type: "integer", nullable: false),
                    lessonid = table.Column<int>(type: "integer", nullable: true),
                    removed = table.Column<bool>(type: "boolean", nullable: false),
                    registerdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    lastupdatedate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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
                name: "questions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    question = table.Column<string>(type: "text", nullable: false),
                    optiona = table.Column<string>(type: "text", nullable: false),
                    optionb = table.Column<string>(type: "text", nullable: false),
                    optionc = table.Column<string>(type: "text", nullable: false),
                    optiond = table.Column<string>(type: "text", nullable: false),
                    order = table.Column<int>(type: "integer", nullable: false),
                    correctoption = table.Column<int>(type: "integer", nullable: false),
                    selectedoption = table.Column<int>(type: "integer", nullable: true),
                    origin = table.Column<int>(type: "integer", nullable: false),
                    idlessonassessment = table.Column<int>(type: "integer", nullable: true),
                    lessonassessmentid = table.Column<int>(type: "integer", nullable: true),
                    idmoduleassessment = table.Column<int>(type: "integer", nullable: true),
                    moduleassessmentid = table.Column<int>(type: "integer", nullable: true),
                    idroadmapassessment = table.Column<int>(type: "integer", nullable: true),
                    roadmapassessmentid = table.Column<int>(type: "integer", nullable: true),
                    removed = table.Column<bool>(type: "boolean", nullable: false),
                    registerdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    lastupdatedate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questions", x => x.id);
                    table.ForeignKey(
                        name: "FK_questions_lessonassessment_lessonassessmentid",
                        column: x => x.lessonassessmentid,
                        principalTable: "lessonassessment",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_questions_moduleassessment_moduleassessmentid",
                        column: x => x.moduleassessmentid,
                        principalTable: "moduleassessment",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_questions_roadmapquestions_roadmapassessmentid",
                        column: x => x.roadmapassessmentid,
                        principalTable: "roadmapquestions",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_exams_userid",
                table: "exams",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_jobroles_examid",
                table: "jobroles",
                column: "examid");

            migrationBuilder.CreateIndex(
                name: "IX_lessonassessment_lessonid",
                table: "lessonassessment",
                column: "lessonid");

            migrationBuilder.CreateIndex(
                name: "IX_lessons_moduleid",
                table: "lessons",
                column: "moduleid");

            migrationBuilder.CreateIndex(
                name: "IX_moduleassessment_moduleid",
                table: "moduleassessment",
                column: "moduleid");

            migrationBuilder.CreateIndex(
                name: "IX_modules_roadmapid",
                table: "modules",
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
                name: "IX_roadmapquestions_roadmapid",
                table: "roadmapquestions",
                column: "roadmapid");

            migrationBuilder.CreateIndex(
                name: "IX_roadmaps_examid",
                table: "roadmaps",
                column: "examid");

            migrationBuilder.CreateIndex(
                name: "IX_roadmaps_selectedjobroleid",
                table: "roadmaps",
                column: "selectedjobroleid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "questions");

            migrationBuilder.DropTable(
                name: "refreshtokens");

            migrationBuilder.DropTable(
                name: "lessonassessment");

            migrationBuilder.DropTable(
                name: "moduleassessment");

            migrationBuilder.DropTable(
                name: "roadmapquestions");

            migrationBuilder.DropTable(
                name: "lessons");

            migrationBuilder.DropTable(
                name: "modules");

            migrationBuilder.DropTable(
                name: "roadmaps");

            migrationBuilder.DropTable(
                name: "jobroles");

            migrationBuilder.DropTable(
                name: "exams");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
