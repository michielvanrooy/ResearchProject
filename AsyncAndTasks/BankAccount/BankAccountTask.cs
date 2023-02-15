namespace AsyncAndTasks
{
    internal class BankAccountTask
    {
        public BankAccount BankAccount { get; set; }

        public Task MyDebitTask { get; set; }

        public async Task<string> ExecuteMe()
        {
            var debitDetails = await GetresultFormAPI();
            //and do maping
            this.BankAccount.DebitDetails = debitDetails;

            return "";
        }

        private async Task<List<string>> GetresultFormAPI()
        {
            var random = new Random();

            await Task.Delay(random.Next(5000));

            return new List<string>
            {
                "someResult",
                "dfhsdfdk"
            };
        }
    }
}
