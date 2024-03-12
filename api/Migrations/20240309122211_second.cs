using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequests_Managers_ManagerId",
                table: "LeaveRequests");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequests_Managers_ManagerId",
                table: "LeaveRequests",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequests_Managers_ManagerId",
                table: "LeaveRequests");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequests_Managers_ManagerId",
                table: "LeaveRequests",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
