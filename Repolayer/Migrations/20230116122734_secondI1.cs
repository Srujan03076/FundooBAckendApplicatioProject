using Microsoft.EntityFrameworkCore.Migrations;

namespace Repolayer.Migrations
{
    public partial class secondI1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CollaborationTable",
                columns: table => new
                {
                    CollabId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollabEmail = table.Column<string>(nullable: true),
                    Id = table.Column<long>(nullable: false),
                    NotesId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollaborationTable", x => x.CollabId);
                    table.ForeignKey(
                        name: "FK_CollaborationTable_UserTable_Id",
                        column: x => x.Id,
                        principalTable: "UserTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CollaborationTable_NoteTable_NotesId",
                        column: x => x.NotesId,
                        principalTable: "NoteTable",
                        principalColumn: "NotesId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "LabelTable",
                columns: table => new
                {
                    LabelId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LabelName = table.Column<string>(nullable: true),
                    NotesId = table.Column<long>(nullable: false),
                    Id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabelTable", x => x.LabelId);
                    table.ForeignKey(
                        name: "FK_LabelTable_UserTable_Id",
                        column: x => x.Id,
                        principalTable: "UserTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LabelTable_NoteTable_NotesId",
                        column: x => x.NotesId,
                        principalTable: "NoteTable",
                        principalColumn: "NotesId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NoteTable_Id",
                table: "NoteTable",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CollaborationTable_Id",
                table: "CollaborationTable",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CollaborationTable_NotesId",
                table: "CollaborationTable",
                column: "NotesId");

            migrationBuilder.CreateIndex(
                name: "IX_LabelTable_Id",
                table: "LabelTable",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_LabelTable_NotesId",
                table: "LabelTable",
                column: "NotesId");

            migrationBuilder.AddForeignKey(
                name: "FK_NoteTable_UserTable_Id",
                table: "NoteTable",
                column: "Id",
                principalTable: "UserTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NoteTable_UserTable_Id",
                table: "NoteTable");

            migrationBuilder.DropTable(
                name: "CollaborationTable");

            migrationBuilder.DropTable(
                name: "LabelTable");

            migrationBuilder.DropIndex(
                name: "IX_NoteTable_Id",
                table: "NoteTable");
        }
    }
}
