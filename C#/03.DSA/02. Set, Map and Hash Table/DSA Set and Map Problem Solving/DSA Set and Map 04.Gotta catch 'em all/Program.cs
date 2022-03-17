using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DSA_Set_and_Map_03.Gotta_catch__em_all
{
    class Program
    {
        // create repo for pokemons
        private readonly static List<Tuple<string, string, int>> pokemonRepo = new List<Tuple<string, string, int>>();
        private static StringBuilder sb = new StringBuilder();
        static void Main()
        {
            //keep accepting commands until end is typed
            while (true)
            {
                try
                {
                    var input = Console.ReadLine().Split(' ');
                    if (input[0] == "end")
                    {
                        break;
                    }
                    //filter commands
                    switch (input[0])
                    {
                        case "add":
                            AddPokemon(input);
                            break;
                        case "ranklist":
                            RankList(input);
                            break;
                        case "find":
                            Find(input);
                            break;
                        default:
                            throw new Exception($"{input[0]} command does not exist.");

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine(sb.ToString());
        }
        static void AddPokemon(string[] currentCommand)
        {
            string errorMessage = "Pokemon {0} has to be between 1 and 20 characters!";
            if (currentCommand[1].Length > 20 || currentCommand[1].Length < 1)
            {
                throw new Exception(string.Format(errorMessage, "name"));
            }
            if (currentCommand[2].Length > 20 || currentCommand[2].Length < 1)
            {
                throw new Exception(string.Format(errorMessage, "type"));
            }
            if (int.Parse(currentCommand[3]) > 50 || int.Parse(currentCommand[3]) < 10)
            {
                throw new Exception("Pokemon power needs to be between 10 and 50!");
            }
            var pokemon = Tuple.Create(currentCommand[1], currentCommand[2], int.Parse(currentCommand[3]));
            int wantedPosition = int.Parse(currentCommand[4]);
            if (wantedPosition <= pokemonRepo.Count + 1 && wantedPosition > 0)
            {
                if (wantedPosition == pokemonRepo.Count + 1)
                {
                    pokemonRepo.Add(pokemon);
                }
                else
                {
                    pokemonRepo.Insert(wantedPosition - 1, pokemon);
                }
                sb.AppendLine($"Added pokemon {pokemon.Item1} to position {wantedPosition}");
            }
            else
            {
                throw new Exception($"There are {pokemonRepo.Count} pokemon currently in the ranking! " +
                    $"Choose a position between 1 and {pokemonRepo.Count + 1}!");
            }
        }
        static void RankList(string[] currentCommand)
        {
            int start = int.Parse(currentCommand[1]);
            int end = int.Parse(currentCommand[2]);
            int count = 1;
            for (int i = start - 1; i < end; i++)
            {
                if (i == end - 1)
                {
                    sb.AppendLine($"{count}. {pokemonRepo[i].Item1}({pokemonRepo[i].Item3})");
                }
                else
                {
                    sb.Append($"{count}. {pokemonRepo[i].Item1}({pokemonRepo[i].Item3}); ");
                }
                count++;
            }
        }
        static void Find(string[] currentCommand)
        {
            var foundPokemons = pokemonRepo.FindAll(tuple => tuple.Item2 == currentCommand[1]);

            var ordered = foundPokemons
                .OrderBy(pokemon => pokemon.Item1)
                .ThenBy(pokemon => -pokemon.Item3)
                .Take(5);

            sb.Append($"Type {currentCommand[1]}:");
            int count = 0;
            if (foundPokemons.Count != 0)
            {
                foreach (var pok in ordered)
                {
                    count++;
                    if (count == 5 || count == foundPokemons.Count)
                    {
                        sb.AppendLine($" {pok.Item1}({pok.Item3})");
                    }
                    else
                    {
                        sb.Append($" {pok.Item1}({pok.Item3});");
                    }
                }
            }
            else
            {
                sb.AppendLine(" ");
            }

        }
    }
}