using Microsoft.EntityFrameworkCore.Migrations;
using System.Globalization;

namespace BaretProject.Infrastructure
{
    public static class ConvertToPersianExtension
    {
        public static string ToPersian(this DateTime date)
        {
            PersianCalendar persianCalendar = new PersianCalendar();

            return persianCalendar.GetYear(date) + "/" + persianCalendar.GetMonth(date) + "/" +
                   persianCalendar.GetDayOfMonth(date);
        }
        public static void GenrateSP(this MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[GetCustomers] AS BEGIN Select * From Customers END";
            var sp2 = "CREATE PROCEDURE GetAllProduct AS Begin Select * From User END";
            migrationBuilder.Sql(sp);
        }
    }
}
