using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaretProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class bt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("CREATE PROCEDURE [dbo].[GetCustomers] AS BEGIN Select * From Customers END");
            migrationBuilder.GenrateSP();
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
