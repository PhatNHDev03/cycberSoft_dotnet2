public class UserService
{

    // 1. tao 1 service
    //2. tao 1 state ở dây state là biến current user: và nó chia làm 2 1 private để bảo toàn thông tin còn 2 là pbulic để cprivate có thể nhân
    // được giá trị thông qua biến public
    // 3. mỗi lần gọi 1 hàm trong service thì sẽ phải có 1 hàm notifyStateChanged() ==> để gọi event Oned từu đó tracking được có thay đổi ở service này
    // khi mà đụng tới biến state thì nó sẽ gọi Action đé.ivoke reaload lại service
    //4. đăng kí ervice trong program.cs
    public event Action? Onchanged;
    private string currentUser;

    public string CurrentUser
    {
        get
        {
            return currentUser;
        }
    }


    public void login(string userName)
    {
        currentUser = userName;
        NotifyStateChanged();
    }
    public void logout()
    {
        currentUser = string.Empty;
        NotifyStateChanged();
    }
    //ham check user da dang nhap chua
    public bool IsAuthenticate()
    {
        return !String.IsNullOrEmpty(currentUser);

    }

    // thong bao cho blazor  biet rang data da thay doi
    private void NotifyStateChanged()
    {
        if (Onchanged != null)
        {
            Onchanged.Invoke();
        }

    }
}