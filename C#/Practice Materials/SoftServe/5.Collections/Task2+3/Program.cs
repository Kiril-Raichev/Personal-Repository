using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2
{
    class Program
    {
        //TASK3

        //public static Dictionary<string, List<string>> ReverseNotebook(Dictionary<string, string> phonesToNames)
        //{
        //    foreach (var el in phonesToNames)
        //    {
        //        if (el.Value == null || el.Value == string.Empty)
        //        {
        //            phonesToNames[el.Key] = string.Empty;
        //        }
        //    }
        //    Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();
        //    var lookup = phonesToNames.ToLookup(o => o.Value);
        //    foreach (var el in lookup)
        //    {
        //        List<string> numbers = new List<string>();
        //        foreach (var elem in phonesToNames)
        //        {
        //            if (elem.Value == el.Key)
        //            {
        //                numbers.Add(elem.Key);
        //            }
        //
        //        }
        //        result.Add(el.Key, numbers);
        //    }
        //
        //    return result;
        //}

        //TASK2
        public static Lookup<string, string> CreateNotebook(Dictionary<string, string> phonesToNames)
        {
            foreach (var el in phonesToNames)
            {
                if (el.Value == null)
                {
                    phonesToNames[el.Key] = string.Empty;
                }
            }

            List<KeyValuePair<string, string>> result = new List<KeyValuePair<string, string>>();

            foreach (var elem in phonesToNames)
            {
                result.Add(new KeyValuePair<string, string>(elem.Value, elem.Key));
            }
            var look = (Lookup<string, string>)result.ToLookup(x => x.Key, x => x.Value);

            return look;
        }
        static void Main(string[] args)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>()
            {
                ["0967654321"] = "Petro",
                ["0677654321"] = "Petro",
                ["0631234567"] = "Ivan",
                ["0501234567"] = "Ivan",
                ["0970011223"] = "Stephan",
                ["0148242891"] = string.Empty

            };

            var test = CreateNotebook(dict);
            foreach (var el in test)
            {
                foreach (var str in test[el.Key])
                {
                    Console.WriteLine(el.Key + " :" + str);
                }
            }
        }

    }
}
