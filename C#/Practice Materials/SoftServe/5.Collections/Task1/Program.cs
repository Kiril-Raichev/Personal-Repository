using System;
using System.Collections.Generic;
namespace Task1
{
    class Program
    {
        class MyUtils
        {
            public static bool ListDictionaryCompare(List<string> list, Dictionary<string,string> dict)
            {

                foreach(var dictEl in dict)
                {
                    if (!list.Contains(dictEl.Value))
                    {
                        return false;
                    }
                }
                foreach(var listEl in list)
                {
                    if (!dict.ContainsValue(listEl))
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        static void Main(string[] args)
        {
            List<string> list = new List<string> { "aa", "bb", "aa", "cc", "aa" };
            Dictionary<string, string> dict = new Dictionary<string, string>()
            {
                ["1"] = "aa",
                ["2"] = "bb",
                ["3"] = "cc",
                ["4"] = "aa",
                ["5"]= "dd",
            };
            Console.WriteLine(MyUtils.ListDictionaryCompare(list,dict));
        }
    }
}
