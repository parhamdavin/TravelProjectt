using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
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
        public static DateTime PersianToDateTime(this string persianDate)
        {
            if (persianDate.Length != 10)
            {
                throw new ArgumentException(nameof(persianDate));
            }
            PersianCalendar persian = new PersianCalendar();
            int year = Convert.ToInt32(persianDate.Substring(0, 4));
            var convertDate = persian.ToDateTime(year, Convert.ToInt32(persianDate.Substring(5, 2)), Convert.ToInt32(persianDate.Substring(8, 2)), 0, 0, 0, 0); ;

            return convertDate;
        }
        public static List<string> GetAllClassName(this Type type)
        {
            var _lista = new List<Assembly>();
            foreach (string dllPath in Directory.GetFiles(System.AppContext.BaseDirectory, "BaretProject.*.dll"))
            {
                var shadowCopiedAssembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(dllPath);
                _lista.Add(shadowCopiedAssembly);
            }

            return _lista.SelectMany(x => x.GetTypes()).Where(x => type.IsAssignableFrom(x) & !x.IsInterface & !x.IsAbstract).Select(x => x.FullName).ToList();
        }
        public static List<Type> GetAllClassTypes(this Type type)
        {
            var _lista = new List<Assembly>();
            foreach (string dllPath in Directory.GetFiles(System.AppContext.BaseDirectory, "BaretProject.*.dll"))
            {
                var shadowCopiedAssembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(dllPath);
                _lista.Add(shadowCopiedAssembly);
            }

            return _lista.SelectMany(x => x.GetTypes())
                .Where(x => type.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .ToList();
        }
    }

}
