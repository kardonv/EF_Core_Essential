using System.ComponentModel.DataAnnotations;

namespace _005_Keys
{
    internal class Program
    {
        /**
         * Первинний ключ - використовується для унікальної ідентифікації сутності.
         * Згідно конвенції ім'я ключа буде - PK_{ClassName}.
         * Ключ можу бути складеним, та може бути зконфігурованим всіма трьома спсобами.
         * 
         * Альтернативний ключ - альтернативний варіант ідентифікації сутності, який використовується у зв'язуванні сутностей.
         * Згідно конвенції ім'я ключа буде - AK_{ClassName}_{PropertyName}
         * Ключ можу бути складеним. Конфігурується через Fluent API.
         */
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            using var db = new ApplicationContext();

            Console.WriteLine("Done!");

            // Delay.
            Console.ReadLine();
        }
    }

    public class User
    {
        public int Id { get; set; }
        //public int UserId { get; set; }
        //[Key]
        // public int Identifier { get; set; }
        public string Name { get; set; }
        public string PassportNumber { get; set; }
        public string INN { get; set; }
        public int Age { get; set; }
    }
}