using System;
using System.Globalization;

namespace calendar
{
    class Calendar
    {
        const string delimeter = "\t";
        const string transferer = "\n";
        static DateTime currentDate = DateTime.Now;

        public Calendar() 
        {
            int month = currentDate.Month;
            int year = currentDate.Year;  
            
            String calendar = BuildCalendar(month, year);

            DrawHeader();
            Console.WriteLine(calendar);
        }
        
        public Calendar(string monthName) 
        {
            int month = DateTime.ParseExact(monthName, "MMMM", CultureInfo.InvariantCulture).Month;
            int year = currentDate.Year;

            String calendar = BuildCalendar(month, year);

            DrawHeader();
            Console.WriteLine(calendar);
        }

        public Calendar(string monthName, int year) 
        {
            int month = DateTime.ParseExact(monthName, "MMMM", CultureInfo.InvariantCulture).Month;

            String calendar = BuildCalendar(month, year);

            DrawHeader();
            Console.WriteLine(calendar);
        }
        
        private static String BuildCalendar(int month, int year)
        {
            int days = DateTime.DaysInMonth(year, month);
            String calendar = "";
            
            DateTime firstDay = new DateTime(year, month, 1);
            DateTime lastDay = new DateTime(year, month, days);

            for (int i = 1; i < (int) firstDay.DayOfWeek; i++) {
                calendar += delimeter;
            }

            for (var day = firstDay; day <= lastDay; day = day.AddDays(1)) {
                HighlightDay(day);
                calendar += day.Day;
                calendar += delimeter;            

                if (day.DayOfWeek == DayOfWeek.Sunday) {
                    calendar += transferer;
                }
            }
    
            return calendar;
        }

        private static void DrawHeader()
        {
            Console.WriteLine(currentDate.ToString("MMMM") + " " + currentDate.ToString("yyyy"));
            Console.WriteLine("Mo\tTu\tWe\tTh\tFr\tSa\tSu");
        }

        private static void HighlightDay(DateTime day)
        {   
            if (currentDate == day) {
                Console.ForegroundColor = ConsoleColor.Yellow;
            } else if (day.DayOfWeek == DayOfWeek.Saturday | day.DayOfWeek != DayOfWeek.Sunday) {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            } else {
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}  
