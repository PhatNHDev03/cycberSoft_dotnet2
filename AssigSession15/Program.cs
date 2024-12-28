
using Newtonsoft.Json;

public class Program
{
    private static void Main(string[] args)
    {

        TransactionManagement transactionManagement = new TransactionManagement(1);
        Account account = new Account() { id = 1, userName = "Nguyen Hoang A", numberPhone = 12345678, pin = 9999, money = 100.000 };
        Transaction transaction1 = new Transaction() { id = 1, userId = account.id, date = DateTime.Now.AddDays(-2).AddHours(+1), note = "transaction is successful", transactionMoney = 10.000, transactionType = "Card Payment", status = true };
        account.money = account.money - transaction1.transactionMoney;
        Transaction transaction2 = new Transaction() { id = 2, userId = account.id, date = DateTime.Now.AddDays(-1), note = "transaction is not successful, your money is not enough", transactionType = "Card Payment", transactionMoney = 1000.000, status = false };
        transactionManagement.transactions.Add(transaction1);
        transactionManagement.transactions.Add(transaction2);

        var choice = 0;
        do
        {
            Console.WriteLine("___________________________________________________________");
            Console.WriteLine("-------Payment program--------");
            Console.WriteLine("1. Cash payment");
            Console.WriteLine("2. Card payment");
            Console.WriteLine("3. Online payment");
            Console.WriteLine("4. Your History transaction");
            Console.WriteLine("5. Exit");
            Console.WriteLine("Enter your choice:");
            Console.Write("My choice is:");
            choice = int.Parse(Console.ReadLine());
            Console.WriteLine("___________________________________________________________");
            switch (choice)
            {
                case (1):
                    Console.WriteLine("Please enter money transacion: ");
                    var moneytransaction = double.Parse(Console.ReadLine());
                    CashPayment cashPayment = new CashPayment();
                    cashPayment.getUserInfor(transactionManagement.getLastId(), account.id);
                    var newTransaction = cashPayment.payMoney(moneytransaction);
                    var verifiedTransaction = transactionManagement.verifyTransaction(account.checkingCurrentMoney(moneytransaction), newTransaction);
                    if (account.checkingCurrentMoney(moneytransaction) == true)
                    {
                        account.money = account.money - moneytransaction;
                    }
                    verifiedTransaction.transactionType = "CashPayment";
                    transactionManagement.transactions.Add(verifiedTransaction);
                    Console.WriteLine(verifiedTransaction.infor());
                    break;
                case (2):
                    Console.WriteLine("____________OPTIONAL MENU_________");
                    Console.WriteLine($"{account.userName} is  isyour account ?");
                    Console.WriteLine("1. Yes. And i want to continue transaction");
                    Console.WriteLine("2. No, I want register new account");
                    Console.WriteLine("Enter your answer to continue the transaction:");
                    Console.Write("My choice is: ");
                    var optionalChoice = int.Parse(Console.ReadLine());
                    if (optionalChoice == 2)
                    {
                        Console.WriteLine("Enter user name");
                        var newUserName = Console.ReadLine();
                        Console.WriteLine("Enter phone number");
                        var phone = int.Parse(Console.ReadLine());
                        var otp = account.randomOtpForPhoneNumber();
                        Console.WriteLine($"Please enter otp from message (your otp number is {otp})");
                        var inputOtp = int.Parse(Console.ReadLine());
                        if (inputOtp != otp)
                        {
                            Console.WriteLine("Otp number not matching !!!!");
                            break;
                        }
                        Console.WriteLine("Enter new pin number");
                        var newPin = int.Parse(Console.ReadLine());
                        var newMoney = 200.000; // fix cung so tien a.
                        var accountNew = new Account() { id = account.id + 1, userName = newUserName, numberPhone = phone, pin = newPin, money = newMoney };
                        Console.WriteLine("Register account sucessfully !!");
                        account = accountNew;
                        Console.WriteLine(account.infor());
                    }
                    Console.WriteLine("Please enter money transacion: ");
                    moneytransaction = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter your pin to continue the transaction:");
                    var inputPin = int.Parse(Console.ReadLine());
                    if (account.checkingPin(inputPin) == false)
                    {
                        Console.WriteLine("Invalid Pin !!");
                        break;
                    }
                    CardPayment cardPayment = new CardPayment();
                    cardPayment.getUserInfor(transactionManagement.getLastId(), account.id);
                    newTransaction = cardPayment.payMoney(moneytransaction);
                    verifiedTransaction = transactionManagement.verifyTransaction(account.checkingCurrentMoney(moneytransaction), newTransaction);
                    if (account.checkingCurrentMoney(moneytransaction) == true)
                    {

                        account.money = account.money - moneytransaction;
                    }
                    verifiedTransaction.transactionType = "CardPayment";
                    transactionManagement.transactions.Add(verifiedTransaction);
                    Console.WriteLine(verifiedTransaction.infor());
                    break;
                case (3):
                    Console.WriteLine("Please enter money transacion: ");
                    moneytransaction = double.Parse(Console.ReadLine());
                    var otp1 = account.randomOtpForPhoneNumber();
                    Console.WriteLine($"Please enter otp from message (your otp number is {otp1})");
                    var inputOtp1 = int.Parse(Console.ReadLine());
                    if (inputOtp1 != otp1)
                    {
                        Console.WriteLine("Otp number not matching !!!!");
                        break;
                    }
                    OnlinePayment onlinePayment = new OnlinePayment();
                    onlinePayment.getUserInfor(transactionManagement.getLastId(), account.id);
                    newTransaction = onlinePayment.payMoney(moneytransaction);
                    verifiedTransaction = transactionManagement.verifyTransaction(account.checkingCurrentMoney(moneytransaction), newTransaction);
                    if (account.checkingCurrentMoney(moneytransaction) == true)
                    {
                        account.money = account.money - moneytransaction;
                    }
                    verifiedTransaction.transactionType = "OnlinePayment";
                    transactionManagement.transactions.Add(verifiedTransaction);
                    Console.WriteLine(verifiedTransaction.infor());
                    break;
                case (4):
                    Console.WriteLine("_______________________________");
                    Console.WriteLine("1. Save transaction history");
                    Console.WriteLine("2. Show all transaction history");
                    var choiceOptional = int.Parse(Console.ReadLine());
                    if (choiceOptional == 1)
                    {
                        try
                        {
                            // nó ở file bin ạ
                            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), "transactionHistory.json");
                            var findByIdList = transactionManagement.transactions.FindAll(x => x.userId == account.id).ToList();
                            var tranasctionjsonSave = JsonConvert.SerializeObject(findByIdList);
                            File.WriteAllText("transactionHistory.json", tranasctionjsonSave);
                            Console.WriteLine("Save successfully");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error saving file: {ex.Message}");
                        }
                        break;
                    }
                    else
                    {
                        string fullPath = Path.Combine(Directory.GetCurrentDirectory(), "transactionHistory.json");
                        var transactionFromJson = File.ReadAllText(fullPath);
                        var transactionFomart = JsonConvert.DeserializeObject<List<Transaction>>(transactionFromJson);
                        transactionManagement.transactions = transactionFomart;
                        Console.WriteLine(account.infor());
                        transactionManagement.showUSerTransaction(account.id);
                        break;
                    }
                case (5):
                    break;
            }
        }
        while (choice < 5);
    }
}