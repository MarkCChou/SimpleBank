namespace SimpleBank
{
    internal class Transaction
    {
        public string type;
        public decimal amount;
        public DateTime time;
        public bool success;


        public Transaction(Action action, decimal amount, bool success)
        {
            switch (action)
            {
                case Action.deposit:
                    this.type = "存款";
                    break;
                case Action.withdraw:
                    this.type = "提款";
                    break;
                case Action.tansfer:
                    this.type = "轉出";
                    break;
                case Action.Receive:
                    this.type = "轉入";
                    break;
            }

            this.amount = amount;
            this.time = DateTime.Now;
            this.success = success;
        }
    }
}
