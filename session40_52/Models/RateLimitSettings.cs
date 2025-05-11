namespace session40_52.Models
{
    public class RateLimitSettings
    {
        //map phai giong file json ko la no sai
        public bool Enabled { get; set; }
        public int Window { get; set; } // time trong mấy giây
        public int MaxRequests { get; set; } // tổng số lần request trong một cửa sổ
    }

}