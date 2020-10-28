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
            // Console.WriteLine(pokemons);
            // Console.WriteLine(trainer);

            Maschine(pokemons, trainer);

        }

        private static void Maschine(List<Pokemon> pokemon, List<Trainer> trainer)
        {
            // Console.WriteLine("start");
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
            // Console.WriteLine("trainer:{0}", freeTrainer);
            while (freeTrainer > 0)
            {
                // Console.WriteLine("step2");
                int t;
                for (t = 0; t < trainer.Count; t++)
                {
                    // Console.WriteLine("step3");
                    if (trainer[t].matched == true)
                    {
                        // Console.WriteLine("step4");
                        break;
                    }

                    for (int f = 0; f < trainer[t].favourites.Length; f++)
                    {
                        int favouritePokemon = trainer[t].favourites[f] - 1;
                        // Console.WriteLine("id: {0}", favouritePokemon);

                        if (pokemon[favouritePokemon].matched == false)
                        {
                            // Console.WriteLine("bliblablubbffffff");
                            trainer[t].matched = true;
                            trainer[t].matchedId = favouritePokemon;
                            pokemon[favouritePokemon].matched = true;
                            pokemon[favouritePokemon].matchedId = trainer[t].id;
                            freeTrainer--;
                        }
                        else
                        {
                            int matchedTrainer = trainer[pokemon[favouritePokemon].matchedId].id;
                            // Console.WriteLine("bliblablubb: {0}", matchedTrainer);
                            if (TrainervsTrainer(pokemon[favouritePokemon].id - 1, trainer[t].id, matchedTrainer, pokemon, trainer) == false) //neuer trainer ist besser als der alte Trainer! Bitte switch mich!
                            {
                                trainer[matchedTrainer].matchedId = 0;
                                trainer[matchedTrainer].matched = false;

                                trainer[t].matched = true;
                                trainer[t].matchedId = pokemon[favouritePokemon].id;
                                pokemon[favouritePokemon].matchedId = trainer[t].id;
                                pokemon[favouritePokemon].matched = true;

                                var favouriteList = trainer[matchedTrainer].favourites;

                            }
                        }
                    }
                }
            }
            Console.WriteLine("trainer:", trainer);
            Console.WriteLine("pokemon:", pokemon);
        }
        private static bool TrainervsTrainer(int currentPokemon, int newTrainer, int oldTrainer, List<Pokemon> pokemon, List<Trainer> trainer)
        {
            for (int i = 0; i < trainer.Count; i++)
            {
                if (oldTrainer == pokemon[currentPokemon].favourites[i])
                {
                    // nein! switch nicht
                    return true;
                }
                if (newTrainer == pokemon[currentPokemon].favourites[i])
                {
                    // ja aber gerne doch
                    return false;
                }
            }
            return false;
        }
    }
}
