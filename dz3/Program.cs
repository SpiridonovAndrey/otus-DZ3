using System.Linq.Expressions;

namespace dz3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            bool result1 = false;
            bool result2 = false;
            bool result3 = false;
            int b=0; int a=0; int c=0;string str = "";

            Console.WriteLine("a * x^2 + b * x + c = 0");
            do
            {
                result1 = false;
                result2 = false;
                result3 = false;
                str = "";
                try
                {
                    Console.WriteLine("Введите значение a:");
                    var aa = Console.ReadLine();
                    result1 = int.TryParse(aa, out a);
                    Console.WriteLine("Введите значение b:");
                    var bb = Console.ReadLine();
                    result2 = int.TryParse(bb, out b);
                    Console.WriteLine("Введите значение c:");
                    var cc = Console.ReadLine();
                    result3 = int.TryParse(cc, out c);
                    if (!result1) str = "'a'";
                    if (!result2) str += "'b'";
                    if (!result3) str += "'c'";
                    if (!result1 || !result2 || !result3)
                    {
                        var ex = new NotInt(str+" не целое");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                
            } while (!result1 || !result2 || !result3);

            try
            {
                var D = b*b - 4 * a * c;
                if (D < 0) 
                {
                    var ex = new NotPositive("Вещественных значений не найдено");
                }
                else if (D == 0)
                { 
                    var x = (-b + Math.Sqrt(D)) / 2 / a;
                    Console.WriteLine("x = " + x);
                }
                else
                {
                    var x1 = (-b + Math.Sqrt(D)) / 2 / a;
                    var x2 = (-b - Math.Sqrt(D)) / 2 / a;
                    Console.WriteLine("x1 = {0}, x2 = {1}",x1,x2);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        class NotInt : Exception
        {
            public NotInt(string message) : base(message)
            {
                FormatData(message, "Error");
            }
        }
        class NotPositive : Exception
        {
            public NotPositive(string message) : base(message)
            {
                FormatData(message, "Warning");
            }
        }

        public static void FormatData(string message, string Severity)
        {
            if (Severity == "Error")
                Console.BackgroundColor = ConsoleColor.Red;
            else Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.BackgroundColor = ConsoleColor.Black;
        }
        
    }
}