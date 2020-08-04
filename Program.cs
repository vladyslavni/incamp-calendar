using System;

namespace calendar
{
    class Program
    {
        const string delimeter = "\t";
        const string transferer = "\n";

        static DateTime date = DateTime.Now;

        static void Main(string[] args)
        {
            int year = date.Month;
            int month = date.Month;
            int days = DateTime.DaysInMonth(year, month);
            
            DateTime firstDay = new DateTime(year, month, 1);
            DateTime lastDay = new DateTime(year, month, DateTime.DaysInMonth(year, month));
            String calendar = BuildCalendar(firstDay, lastDay);

            DrawHeader();
            Console.WriteLine(calendar);
        }

        private static String BuildCalendar(DateTime firstDay, DateTime lastDay)
        {
            String calendar = "";

            for (int i = 0; i < (int) firstDay.DayOfWeek; i++)
            {
                calendar += delimeter;
            }


            for (var day = firstDay; day <= lastDay; day = day.AddDays(1)) {
                HighlightDay(day);
                calendar += day.Day;
                calendar += delimeter;            

                if (day.DayOfWeek == DayOfWeek.Saturday) {
                    calendar += transferer;
                }
            }
    

            return calendar;
        }

        private static void DrawHeader()
        {
            Console.WriteLine(date.ToString("MMMM") + " " + date.ToString("yyyy"));
            Console.WriteLine("Mo\tTu\tWe\tTh\tFr\tSa\tSu");
        }

        private static void HighlightDay(DateTime day)
        {
            DateTime current = DateTime.Now;
            
            if (current == day) {
                Console.ForegroundColor = ConsoleColor.Yellow;
            } else if (day.DayOfWeek == DayOfWeek.Saturday | day.DayOfWeek != DayOfWeek.Sunday) {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            } else {
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

    }
}  
