public class TransactionManagement
{
    public int id { get; set; }

    public List<Transaction> transactions;


    public TransactionManagement(int id)
    {

        this.id = id;
        transactions = new List<Transaction>();
    }


    public void showUSerTransaction(int userId)
    {
        foreach (var item in transactions.FindAll(x => x.userId == userId))
        {
            Console.WriteLine(item.infor());
        }

    }

    public Transaction verifyTransaction(bool checking, Transaction transaction)
    {
        if (checking == false)
        {
            Console.WriteLine("Transaction is fail");
            Console.WriteLine("Your banking is not enough money to trade");
            transaction.note = "transaction is not successful, your money is not enough";
            transaction.status = false;
        }
        else
        {
            Console.WriteLine("transaction is successful");
            transaction.note = "transaction successful";
            transaction.status = true;
        }
        return transaction;
    }

    public int getLastId()
    {
        return (transactions.Count == 0) ? 0 : transactions.Max(t => t.id);
    }

}