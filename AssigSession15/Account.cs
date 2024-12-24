class Account
{
    public int id { get; set; }
    public string userName { get; set; }
    public int numberPhone { get; set; }
    public int pin { get; set; }
    public double money { get; set; }


    public string infor()
    {
        return $"userName: {userName}, numberPhone: {numberPhone}, current money: {money}.000 Dong";
    }

    public bool checkingCurrentMoney(double transactionMoney)
    {
        if (money == 0 || 0 >= transactionMoney) return false;

        return (transactionMoney > money) ? false : true;
    }

    public bool checkingPin(int inputPin)
    {
        return (inputPin == pin) ? true : false;
    }

    public bool checkingRegisterPing(int pin, int rePin)
    {
        if (pin != rePin)
        {
            Console.WriteLine("pin and Re pin is not matcing !!!!");
            return false;
        }

        return true;
    }

    public int randomOtpForPhoneNumber()
    {
        return new Random().Next(100, 1000);
    }

}