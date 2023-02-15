using AsyncAndTasks;

var executor = new TaskExecutor();
await executor.ExecuteListOfTasks();
Console.WriteLine("----------------------------");
await executor.ExecuteWhenAllTasks();


