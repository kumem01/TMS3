using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TMS3.Library.Migrations
{
    public partial class Intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JrnCreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JrnCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JrnModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JrnModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonID);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CommentText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ElementCodeID = table.Column<int>(type: "int", nullable: true),
                    IsAllocable = table.Column<bool>(type: "bit", nullable: false),
                    IsOverhead = table.Column<bool>(type: "bit", nullable: false),
                    IsUpdateREquired = table.Column<bool>(type: "bit", nullable: false),
                    JrnCreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JrnCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JrnModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JrnModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaskName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskNumber = table.Column<int>(type: "int", nullable: false),
                    TaskStatusRefrenceTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskID);
                });

            migrationBuilder.CreateTable(
                name: "TaskContact",
                columns: table => new
                {
                    TaskContactID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContactTypeID = table.Column<int>(type: "int", nullable: false),
                    JrnCreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JrnCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JrnModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JrnModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonID = table.Column<int>(type: "int", nullable: true),
                    TaskID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskContact", x => x.TaskContactID);
                    table.ForeignKey(
                        name: "FK_TaskContact_Persons_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Persons",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskContact_Tasks_TaskID",
                        column: x => x.TaskID,
                        principalTable: "Tasks",
                        principalColumn: "TaskID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaskCost",
                columns: table => new
                {
                    TaskCostID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CommentText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpenseTypeReferenceTypeID = table.Column<int>(type: "int", nullable: false),
                    IsEstimate = table.Column<bool>(type: "bit", nullable: false),
                    JrnCreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JrnCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JrnModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JrnModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PONumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentTaskCostID = table.Column<int>(type: "int", nullable: true),
                    PaymentMehtodreferenceTypeID = table.Column<int>(type: "int", nullable: true),
                    TaskID = table.Column<int>(type: "int", nullable: true),
                    VendorTypeReferenceTypeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskCost", x => x.TaskCostID);
                    table.ForeignKey(
                        name: "FK_TaskCost_Tasks_TaskID",
                        column: x => x.TaskID,
                        principalTable: "Tasks",
                        principalColumn: "TaskID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaskDate",
                columns: table => new
                {
                    TaskDateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CommentText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JrnCreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JrnCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JrnModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JrnModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonID = table.Column<int>(type: "int", nullable: true),
                    TaskDateReferenceTypeID = table.Column<int>(type: "int", nullable: false),
                    TaskID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskDate", x => x.TaskDateID);
                    table.ForeignKey(
                        name: "FK_TaskDate_Persons_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Persons",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskDate_Tasks_TaskID",
                        column: x => x.TaskID,
                        principalTable: "Tasks",
                        principalColumn: "TaskID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskContact_PersonID",
                table: "TaskContact",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_TaskContact_TaskID",
                table: "TaskContact",
                column: "TaskID");

            migrationBuilder.CreateIndex(
                name: "IX_TaskCost_TaskID",
                table: "TaskCost",
                column: "TaskID");

            migrationBuilder.CreateIndex(
                name: "IX_TaskDate_PersonID",
                table: "TaskDate",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_TaskDate_TaskID",
                table: "TaskDate",
                column: "TaskID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskContact");

            migrationBuilder.DropTable(
                name: "TaskCost");

            migrationBuilder.DropTable(
                name: "TaskDate");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
