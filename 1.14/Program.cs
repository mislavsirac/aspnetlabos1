class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Demonstracija Task.WaitAll()...");

        Task task1 = Task.Run(() =>
        {
            Console.WriteLine("Task 1 započinje...");
            Task.Delay(1000).Wait();
            Console.WriteLine("Task 1 završava.");
        });

        Task task2 = Task.Run(() =>
        {
            Console.WriteLine("Task 2 započinje...");
            Task.Delay(1500).Wait();
            Console.WriteLine("Task 2 završava.");
        });

        Task.WaitAll(task1, task2);
        Console.WriteLine("Svi taskovi su završeni.");

        Console.WriteLine("\nDemonstracija Task.WaitAny()...");

        Task task3 = Task.Run(() =>
        {
            Console.WriteLine("Task 3 započinje...");
            Task.Delay(1000).Wait();
            Console.WriteLine("Task 3 završava.");
        });

        Task task4 = Task.Run(() =>
        {
            Console.WriteLine("Task 4 započinje...");
            Task.Delay(1500).Wait();
            Console.WriteLine("Task 4 završava.");
        });

        Task.WaitAny(task3, task4);
        Console.WriteLine("Barem jedan task je završen.");

        Console.WriteLine("\nDemonstracija Async funkcija");

        await SleepF1(400);
    }

    private static async Task SleepF1(int sleep)
    {
        Console.WriteLine("Usao u prvi async task");
        await Task.Delay(sleep);
        await SleepF2(sleep);
        Console.WriteLine("Zavrsio prvi async task");
    }

    private static async Task SleepF2(int sleep)
    {
        Console.WriteLine("Usao u drugi async task");
        await Task.Delay(sleep);
        Console.WriteLine("Zavrsio drugi async task");
    }
}