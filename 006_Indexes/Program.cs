namespace _006_Indexes
{
    internal class Program
    {
        /**
         * Індекс - спеціальний об'єкт БД, який створюється для покращення швидкодії пошуку в БД.
         * Може бути заданий за допомогою Data Annotations або Fluent API.
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
}