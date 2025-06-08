namespace SimpleBank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //建立帳戶並存款 10000
            BankAccount bankAccount = new BankAccount("A001", "史努比", 10000);


            //存款 2000
            bankAccount.Deposit(2000);


            ///嘗試提領超過存款之金額
            bankAccount.Withdraw(13000);


            //提領 10000
            bankAccount.Withdraw(10000);


            //用帳戶持有人名子查詢帳戶
            bankAccount.PrintAccountInfo("史努比");
            //查詢失敗
            bankAccount.PrintAccountInfo("小明");


            //建立第2個帳戶
            BankAccount bankAccount2 = new BankAccount("A002", "查理布朗", 30000);

            //嘗試轉帳失敗
            bankAccount.TransferTo(bankAccount2, 20000);

            //轉帳成功
            bankAccount.TransferTo(bankAccount2, 200);

            //列印所有交易紀錄
            bankAccount.PrintTransactionHistory();
            bankAccount2.PrintTransactionHistory();

            Console.ReadLine();





        }
    }
}
