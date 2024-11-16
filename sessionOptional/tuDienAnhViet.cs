class TuDienAnhViet
{

    public static void process()
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        int? choice = 0;
        while (choice < 4)
        {
            Console.WriteLine("______________________________________________");
            Console.WriteLine("1.them tu");
            Console.WriteLine("2. Tra tu");
            Console.WriteLine("3. xoa tu");
            Console.WriteLine("4. thoat");
            Console.WriteLine("Mời bạn chọn 1 chức năng:");
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("them tieng anh");
                    string english = Console.ReadLine();
                    Console.WriteLine("them tieng viet");
                    string vietnamese = Console.ReadLine();
                    dic[english] = vietnamese;
                    break;
                case 2:
                    Console.WriteLine("nhap 1 tu de tra");
                    string wordsreach = Console.ReadLine();
                    if (dic.ContainsValue(wordsreach))
                    {
                        foreach (KeyValuePair<string, string> item in dic)
                        {
                            if (item.Value == wordsreach)
                            {
                                Console.WriteLine($"tu nay la {item.Key} : {item.Value}");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("tu nay ko co trong tu dien");
                    }
                    break;
                case 3:
                    Console.WriteLine("moi ban nhap tu can xoa");
                    string deleteKey = Console.ReadLine();
                    if (dic.ContainsKey(deleteKey))
                    {
                        dic.Remove(deleteKey);
                        Console.WriteLine("xoa thanh cong");
                    }
                    else
                    {
                        Console.WriteLine("tu nay ko ton tai");
                    }
                    break;

            }
        }
    }


}