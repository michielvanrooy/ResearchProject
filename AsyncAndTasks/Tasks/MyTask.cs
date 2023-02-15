namespace AsyncAndTasks.Tasks
{
    public class MyTask : IMyTask
    {
        public string Name { get; set; }

        public MyTask(string name)
        {
            Name = name;
        }

        public async Task<string> Execute()
        {
            var random = new Random();

            Console.WriteLine($"---{Name}--- Started");

            await Task.Delay(random.Next(5000));

            Console.WriteLine($"---{Name}--- Finised");

            return $"{Name} Done";
        }
    }
}
