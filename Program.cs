using System;

namespace calendar
{
    class Program
    {

        static void Main(string[] args)
        {
            switch (args.Length)
            {
                case 0:
                    new Calendar();
                    break;
                case 1:
                    new Calendar(args[0]);
                    break;
                case 2:
                    new Calendar(args[0], Convert.ToInt32(args[1]));
                    break;
            }
        }
    }
}  
