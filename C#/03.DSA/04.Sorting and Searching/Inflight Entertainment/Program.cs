using System;
using System.Collections.Generic;
using System.Linq;
namespace Inflight_Entertainment
{
    class Program
    {
        static void Main()
        {
            int flightLengthMins = int.Parse(Console.ReadLine());
            int[] moviesLengthMins = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Console.WriteLine(CheckMovies(moviesLengthMins, flightLengthMins));
        }
        static bool CheckMovies(int[] moviesLengthMins, int flightLengthMins)
        {
            var movieLengthsSeen = new HashSet<int>();
            // 10 30 30 15
            foreach (int firstMovieLength in moviesLengthMins)
            {
                int matchingSecondMovieLength = flightLengthMins - firstMovieLength;
                if (movieLengthsSeen.Contains(matchingSecondMovieLength))
                {
                    return true;
                }
                else
                {
                    movieLengthsSeen.Add(firstMovieLength);
                }
            }

            return false;

        }
    }
}
