class TwoSum
{


    // public static List<int> twoSumDictionary(List<int> lst,int target){
    //     // Khai báo Dictionary để đánh dấu từng số trong danh sách lst
    //     // Dictionary<int, int> seenNumber = new Dictionary<int, int>();
    //     // for (int i = 0; i < lst.Count; i++)
    //     // {
    //     //     int hieu = target - lst[i];
    //     //     if (seenNumber.ContainsKey(hieu))
    //     //     {
    //     //         return new List<int> { seenNumber[hieu], i };
    //     //     }
    //     //     if (!seenNumber.ContainsKey(lst[i]))
    //     //     {
    //     //         seenNumber.Add(lst[i],i);
    //     //     }
    //     // }
    //     // return null;
    // }


    public static Dictionary<string, int> check(List<string> lst)
    {
        Dictionary<string, int> dic = new Dictionary<string, int>();

        // for (int i = 0; i < lst.Count; i++)
        // {
        //     if(dic.ContainsKey(lst[i])){
        //         dic[lst[i]]++;
        //     }else{
        //         dic[lst[i]] = 1;
        //     }
        // }

        foreach (var item in lst)
        {
            if (dic.ContainsKey(item))
            {
                dic[item]++;
            }
            else
            {
                dic[item] = 1;
            }
        }

        return dic;
    }

}