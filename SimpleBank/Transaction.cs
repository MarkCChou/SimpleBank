namespace SimpleBank
{
    internal class Transaction
    {
        public string type;
        public decimal amount;
        public DateTime time;


        public Transaction(string type, decimal amount)
        {
            if (type == "存款")
            {
                this.type = "[存款]";
            }
            else if (type == "提款")
            {
                this.type = "[提款]";
            }
            else if (type == "提款失敗")
            {
                this.type = "[提款失敗]";
            }
            else if (type == "轉帳成功")
            {
                this.type = "[轉帳]";
            }
            else if (type == "轉帳失敗")
            {
                this.type = "[轉帳失敗]";
            }
            else if (type == "接受轉帳")
            {
                this.type = "[接受轉帳]";
            }
            this.amount = amount;
            this.time = DateTime.Now;
        }
    }
}
