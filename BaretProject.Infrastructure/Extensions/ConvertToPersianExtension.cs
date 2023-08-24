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
    }
}
