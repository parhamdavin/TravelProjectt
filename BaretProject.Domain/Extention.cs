using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Domain
{
    public static class Extention
    {
        public static string ToPersian(this DateTime date)
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            try
            {
                return persianCalendar.GetYear(date) + "/" + persianCalendar.GetMonth(date) + "/" +
                       persianCalendar.GetDayOfMonth(date);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
