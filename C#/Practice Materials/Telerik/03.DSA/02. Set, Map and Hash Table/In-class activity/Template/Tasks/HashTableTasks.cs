using System;
using System.Collections.Generic;
using System.Linq;

namespace HashTables.InClassActivity
{
    public class HashTableTasks
    {
        /// <summary>
        /// Counts the number of occurrences of a each word in a collection.
        /// </summary>
        /// <param name="words">A collection of words.</param>
        /// <returns>A dictionary of occurrences by word.</returns>
        public static Dictionary<string, int> CountOccurences(string[] words)
        {
            var dictionary = new Dictionary<string, int>();
            //going through string array
            foreach (var word in words)
            {
                //if its a new string we add it with count 1
                if (!dictionary.ContainsKey(word))
                {
                    dictionary.Add(word, 1);
                }
                //if not we increase its count by 1
                else
                {
                    dictionary[word]++;
                }
            }
            return dictionary;
        }

        /// <summary>
        /// Return the indices of the first two numbers that sum to a given number.
        /// </summary>
        /// <param name="numbers">Collection of numbers</param>
        /// <param name="sum">Target sum</param>
        /// <returns>An array containing the indices of the first two numbers that produce the target sum.</returns>
        public static int[] TwoSum(int[] numbers, int sum)
        {

            var dictionary = new Dictionary<int, int>();
            int[] arr = { -1, -1 };
            //going through number array
            for (int i = 0; i < numbers.Length; i++)
            {
                //getting the difference from the sum and the current value
                //which equals the number we are looking for
                int difference = sum - numbers[i];
                //if it contains the difference we get both indexes and put into output
                if (dictionary.ContainsKey(difference))
                {
                    arr[0] = dictionary[difference];
                    arr[1] = i;

                    return arr;
                }
                //adding to dictionary
                dictionary[numbers[i]] = i;
            }
            return arr;
        }

        /// <summary>
        /// Counts how many coins are special.
        /// </summary>
        /// <param name="coins">Coins to check.</param>
        /// <param name="catalogue">The catalogue of special coins.</param>
        /// <returns>The count of special coins</returns>
        public static int SpecialCoins(string coins, string catalogue)
        {
            //coins we found matching
            int coinCount = 0;
            //hashset for the chars we search for
            HashSet<char> coinToSearchFor = new HashSet<char>();
            //adding chars we search for to hashset
            foreach(char i in catalogue)
            {
                coinToSearchFor.Add(i);
            }
            //going through the string of coins and increasing count if mathces
            foreach(char coin in coins)
            {
                if (coinToSearchFor.Contains(coin))
                {
                    coinCount++;
                }
            }
            return coinCount;
        }

        /// <summary>
        /// Determines whether two strings are isomorphic. 
        /// Two strings are considered isomorphic if each character from the first string can map to a character in the seconds string.
        /// </summary>
        /// <param name="s1">The first string.</param>
        /// <param name="s2">The second string.</param>
        /// <returns>True if the two strings are isomorphic; otherwise, false.</returns>
        public static bool AreIsomorphic(string s1, string s2)
        {
            // splitting strings into char arrys
            char[] oneArray = s1.ToCharArray();
            char[] twoArray = s2.ToCharArray();
            //creating dictionary
            var dictionary = new Dictionary<char, char>();
            //index to track foreach
            int index = 0;
            //output
            bool output = true;
            //checking if strings are same length
            if (oneArray.Length != twoArray.Length)
            {
                return false;
            }
            //going through the whole first string
            foreach (var ch in oneArray)
            {
                //if dictionary doesnt have such key or key value it is added
                if (!dictionary.ContainsKey(oneArray[index]) && !dictionary.ContainsValue(twoArray[index]))
                {
                    dictionary.Add(oneArray[index], twoArray[index]);
                }
                else
                {
                    try
                    {
                        //comparing current and already set key value
                        if (dictionary[oneArray[index]] != twoArray[index])
                        {
                            output = false;
                        }
                    }//catch exception if they dont match and there are no repeating chars in 1st word
                    catch(KeyNotFoundException)
                    {
                        output = false;
                    }
                }
                index++;
            }
            return output;
        }
    }
}
