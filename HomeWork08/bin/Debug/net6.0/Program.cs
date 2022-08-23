using System.IO;
using System.Text.RegularExpressions;

namespace HomeWork08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "Phone Book.csv";

            string[] content =File.ReadAllLines(filePath);
      
            Console.WriteLine($"Enter search parameter:name,surname,number");

            string search = Console.ReadLine();

            if (search == "name" || search == "surname" || search == "number")
            {
                Console.WriteLine($"Enter {search}");

                string input = Console.ReadLine();

                string regexName = input + @"(;[\w]+;)+([0-9]+)";
                string regexSurname = @"(\w+;)("+ input +";)([0-9]+)";
                string regexNumber = @"([\w]+;)" + input;

                if (search == "name")
                {
                    Print(regexName, content);
                }              
                if (search == "surname")
                {
                    Print(regexSurname, content);
                }              
                if (search == "number")
                {
                    Print(regexNumber, content);
                }
            }
            else
            {
                Console.WriteLine("Incorrect input");
            }

            void Print(string param, string[] data)
            {
                int x  = 0; 
                for (int i = 0; i < data.Length; i++)
                {
                    if (Regex.IsMatch(data[i], param, RegexOptions.IgnoreCase))
                    {
                        Console.WriteLine(data[i]);
                        x++;
                    }
                }
                if (x < 1)
                {
                    Console.WriteLine(@"The subscriber is not in the phone book.");
                }
            }
        }
    }
}

