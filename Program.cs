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

            Maschine(pokemons, trainer);

        }

        private static void Maschine(List<Pokemon> pokemon, List<Trainer> trainer)
        {
            foreach (Pokemon poke in pokemon)
            {
                poke.matched = false;
                poke.matchedId = 0;
            }
            foreach (Trainer trainee in trainer)
            {
                trainee.matched = false;
                trainee.matchedId = 0;
            }
            int freeTrainer = trainer.Count;
            //  Console.WriteLine("Count: {0}", parts.Count);
            while (freeTrainer > 0)
            {
                // Console.WriteLine("enterung wheil");
                int t;
                for (t = 0; t < trainer.Count; t++)
                {
                    // Console.WriteLine("enterung fhor1");
                    if (trainer[t].matched == true)
                    {
                        // Console.WriteLine("enterung iv");
                        break;
                    }

                    for (int f = 0; f < trainer[t].favourites.Length; f++)
                    {
                        // Console.WriteLine("CountDoku: {0}", t);
                        // Console.WriteLine("Count: {0}", f);
                        // Console.WriteLine("enterung fhor2");
                        int favouritePokemon = trainer[t].favourites[f];
                        // Console.WriteLine("Trainer:{0} ", trainer[t].id);
                        // Console.WriteLine("Fav Pok:{0}", favouritePokemon);
                        // Console.WriteLine("Cut for2");
                        // Console.WriteLine("Count: {0}", parts.Count);
                        if (pokemon[favouritePokemon].matched == false)
                        {
                            trainer[t].matched = true;
                            trainer[t].matchedId = favouritePokemon;
                            pokemon[favouritePokemon].matched = true;
                            pokemon[favouritePokemon].matchedId = trainer[t].id;
                        }
                        // Console.WriteLine("Trainer:", trainer);
                        // Console.WriteLine("Poke", pokemon);
                        // else{

                        // }
                    }
                    // Console.WriteLine("cut for1");
                }
                freeTrainer--;
            }
        }
    }
}
