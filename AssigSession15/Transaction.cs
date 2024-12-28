public class Transaction
{
    public int id { get; set; }
    public int userId { get; set; }
    public double transactionMoney { get; set; }
    public DateTime date { get; set; }
    public string note { get; set; }
    public string transactionType { get; set; }
    public bool status { get; set; }
    public string infor()
    {
        var statusText = (status == true) ? "Thành công" : "Thất bại";
        return $"transaction id: {id}, transaction money: {transactionMoney}.000 Dong, date: {date}, note: {note}, type: {transactionType} ,status: {statusText}";
    }



}