using System;
using System.Collections.Generic;


namespace Projekt
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list of parts.
            List<Pokemon> pokemons = new List<Pokemon>();
            List<Trainer> trainer = new List<Trainer>();
            // Add parts to the list.
            pokemons.Add(new Pokemon(1, false, new int[3] { 2, 1, 3 }, 0));
            pokemons.Add(new Pokemon(2, false, new int[3] { 3, 2, 1 }, 0));
            pokemons.Add(new Pokemon(3, false, new int[3] { 1, 3, 2 }, 0));
            trainer.Add(new Trainer(1, false, new int[3] { 2, 1, 3 }, 0));
            trainer.Add(new Trainer(2, false, new int[3] { 2, 3, 1 }, 0));
            trainer.Add(new Trainer(3, false, new int[3] { 1, 3, 2 }, 0));
            Console.WriteLine(pokemons);
            Console.WriteLine(trainer);



        }
    }
}
