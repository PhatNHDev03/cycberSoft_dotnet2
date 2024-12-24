class CardPayment : Ipayment
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
        Console.WriteLine("please waiting for checking transaction from Reception");
        Console.WriteLine("Loading ....");
        Thread.Sleep(1000);
        Transaction transaction = new Transaction() { id = uniqueTransactionId, userId = this.userId, transactionMoney = money, note = "transaction is successful", date = DateTime.Now, transactionType = "Card Payment", status = true };
        return (transaction != null) ? transaction : null;
    }
}