namespace SimpleBank
{
    internal class BankAccount
    {
        public string accountNumber;
        private string owner;
        public decimal balance = 0;
        List<Transaction> transactions = new List<Transaction>();



        public BankAccount(string accountNumber, string owner, int balance)
        {
            this.accountNumber = accountNumber;
            this.owner = owner;
            this.balance = balance;

            Console.WriteLine($"帳戶建立成功 : {owner} , 帳號 : {accountNumber} , 餘額 : ${balance}");

        }

        public void Deposit(int amount)
        {
            balance += amount;
            Console.WriteLine($"存款 ${amount} 成功。餘額 : ${balance}");
            Transaction transaction = new Transaction(Action.Deposit, amount, true);
            transactions.Add(transaction);
        }

        public void Withdraw(int amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"提款 ${amount} 成功。餘額 : ${balance}");
                Transaction transaction = new Transaction(Action.Withdraw, amount, true);
                transactions.Add(transaction);
            }
            else
            {
                Console.WriteLine("餘額不足，無法提領輸入之金額");
                Transaction transaction = new Transaction(Action.Withdraw, 0, false);
                transactions.Add(transaction);

            }
        }


        public void TransferTo(BankAccount target, decimal amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
                target.balance += amount;
                Console.WriteLine($"轉帳成功! 從{owner}的帳戶轉帳${amount}至{target.owner}的帳戶\n{owner}的帳戶存款剩餘${balance}");
                Transaction transaction = new Transaction(Action.Transfer, amount, true);
                Transaction transaction2 = new Transaction(Action.Receive, amount, true);
                transactions.Add(transaction);
                target.transactions.Add(transaction2);
            }

            else if (balance < amount)
            {
                Console.WriteLine("餘額不足，轉帳失敗");
                Transaction transaction = new Transaction(Action.Transfer, 0, false);
                transactions.Add(transaction);
            }


        }

        public void PrintAccountInfo(string owner)
        {
            if (this.owner == owner)
            {
                Console.WriteLine($"---帳戶資訊---\n帳號 : {this.accountNumber}\n持有人 : {owner}\n目前餘額 : ${this.balance}");
            }
            else
            {
                Console.WriteLine("持有人名子錯誤，查詢失敗");
            }
        }

        public void PrintTransactionHistory()
        {
            Console.WriteLine($"---{owner}帳戶交易紀錄---");
            foreach (var item in transactions)
            {
                if (item.success)
                    Console.WriteLine($"[{item.type}] ${item.amount} - {item.time}");
                else
                {
                    Console.WriteLine($"[{item.type}失敗] {item.time}");
                }


            }
        }

    }
}
