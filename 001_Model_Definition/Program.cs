namespace _001_Model_Definition
{
    /**
     * Для задання відображення даних в об'єктної моделі на реляційну використовуються наступні підходи:
     *      - Conventions
     *      - Data Annotations
     *      - Fluent API
     *      
     * Conventions - неявно задані розробниками бібліотеки правила, як відображувати об'єктну модель і навпаки
     *      - Не виражені явнов коді
     *      - Мають самий низький пріорітет
     *      - Зручні, якщо їх знати
     *      - Незручні, якщо їх не знати
     */
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            using var context = new ApplicationContext();

            Console.WriteLine("Done!");

            // Delay.
            Console.ReadLine();
        }
    }
}