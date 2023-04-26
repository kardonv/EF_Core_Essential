namespace _008_One_to_Many
{
    internal class Program
    {
        /**
         * Відношення в якому одна сутність зберігає посилання на один об'єкт іншої сутності, а інша, може посилатись на колекцію 
         * об'єктів першої сутності.
         */
        static void Main(string[] args)
        {
            using var db = new ApplicationContext();

            Book book = new Book() { Name = "EF Core in Action" };

            Chapter chapter_1 = new Chapter() { Name = "Introduction", Book = book };
            Chapter chapter_2 = new Chapter() { Name = "Modeling", Book = book };
            Chapter chapter_3 = new Chapter() { Name = "Relational Model. Inheritance", Book = book };
            Chapter chapter_4 = new Chapter() { Name = "LINQ", Book = book };
            Chapter chapter_5 = new Chapter() { Name = "SQL Queries", Book = book };

            db.Chapters.AddRange(chapter_1, chapter_2, chapter_3, chapter_4, chapter_5);
            db.SaveChanges();

            Console.WriteLine("Done!");

            // Delay.
            Console.ReadLine();
        }
    }
}