class CashPayment : Ipayment
{
    private int uniqueTransactionId;
    private int userId;
    public void getUserInfor(int idTransactionLast, int userId)
    {
        uniqueTransactionId = idTransactionLast + 1;
        this.userId = userId;
    }

    public Transaction payMoney(double money)
    {
        Console.WriteLine("Please waiting for processing system");
        Console.WriteLine("Loading ....");
        Thread.Sleep(1000);
        Transaction transaction = new Transaction() { id = uniqueTransactionId, userId = this.userId, transactionMoney = money, date = DateTime.Now, transactionType = "Card Payment" };
     
        return (transaction != null) ? transaction : null;
    }
}