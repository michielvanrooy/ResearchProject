using System.Threading.Tasks;
using AsyncAndTasks.Tasks;

namespace AsyncAndTasks
{
    public class TaskExecutor
    {

        public async Task<string> ExecuteListOfTasks()
        {
            var tasks = new List<IMyTask>();

            tasks.Add(new MyTask("Task1"));
            tasks.Add(new MyTask("Task2"));
            tasks.Add(new MyTask("Task3"));

            foreach(var task in tasks)
            {
                Console.WriteLine(await task.Execute());
            }

            return "done";
        }

        public async Task<string> ExecuteWhenAllTasks()
        {
            var tasks = new List<Task<string>>();

            tasks.Add(new MyTask("Task1").Execute());
            tasks.Add(new MyTask("Task2").Execute());
            tasks.Add(new MyTask("Task3").Execute());

            var results = await Task.WhenAll(tasks);

            foreach(var result in results)
            {
                Console.WriteLine(result);
            }

            return "done";
        }

        public async Task<List<BankAccount>> ExecuteGetDebits(List<BankAccount> BankAccounts)
        {
            var myBankAccounts = new List<BankAccountTask>();

            foreach(var backAccount in BankAccounts)
            {
                var myBankAccount = new BankAccountTask
                {
                    BankAccount = backAccount
                };
            }

            var results = await Task.WhenAll(myBankAccounts.Select(n => n.ExecuteMe()));


            return myBankAccounts.Select(n => n.BankAccount).ToList();
        }
    }
}
