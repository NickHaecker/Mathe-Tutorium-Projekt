﻿using System;
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
            pokemons.Add(new Pokemon(0, false, new int[3] { 1, 0, 2 }, -1));
            pokemons.Add(new Pokemon(1, false, new int[3] { 2, 1, 0 }, -1));
            pokemons.Add(new Pokemon(2, false, new int[3] { 0, 2, 1 }, -1));
            trainer.Add(new Trainer(0, false, new int[3] { 1, 0, 2 }, -1));
            trainer.Add(new Trainer(1, false, new int[3] { 1, 2, 0 }, -1));
            trainer.Add(new Trainer(2, false, new int[3] { 0, 2, 1 }, -1));
            // Console.WriteLine(pokemons);
            // Console.WriteLine(trainer);

            Maschine(pokemons, trainer);

        }

        private static void Maschine(List<Pokemon> pokemon, List<Trainer> trainer)
        {
            Console.WriteLine("------start-----");
            foreach (Pokemon poke in pokemon)
            {
                poke.matched = false;
                poke.matchedId = -1;
            }
            foreach (Trainer trainee in trainer)
            {
                trainee.matched = false;
                trainee.matchedId = -1;
            }
            int freeTrainer = trainer.Count;
            Console.WriteLine("FreeTrainer:{0}", freeTrainer);
            while (freeTrainer > 0)
            {
                Console.WriteLine("-----start while-----");
                int t;


                for (t = 0; t < trainer.Count; t++)
                {
                    // Console.WriteLine("step3");
                    if (trainer[t].matched == true)
                    {
                        Console.WriteLine("# Trainer already matched! ");
                        break;
                    }

                    for (int f = 0; f < trainer[t].favourites.Length; f++)
                    {
                        // if (trainer[t].favourites[f] == -1)
                        // {

                        int favouritePokemon = trainer[t].favourites[f];
                        Console.WriteLine("Fav Pok id: {0}", favouritePokemon);


                        // if (trainer[t].favourites[f] != -1)
                        // {
                        if (pokemon[favouritePokemon].matched == false)
                        {
                            Console.WriteLine("Matchig erfolgreich! FreeTrainer -1 ");
                            trainer[t].matched = true;
                            trainer[t].matchedId = favouritePokemon;
                            pokemon[favouritePokemon].matched = true;
                            pokemon[favouritePokemon].matchedId = trainer[t].id;
                            freeTrainer--;
                            Console.WriteLine("Trainer {0} " + trainer[t].id + " Pokemon {0} = " + trainer[t].matchedId);
                            Console.WriteLine("FreeTrainer:{0}", freeTrainer);
                            // break;
                        }
                        else
                        {
                            int matchedTrainer = trainer[pokemon[favouritePokemon].matchedId].id;
                            Console.WriteLine("# Pokemon already matched !");
                            Console.WriteLine("START DDDDUELL !!!");

                            if (TrainervsTrainer(pokemon[favouritePokemon].id, trainer[t].id, matchedTrainer, pokemon, trainer) == false) //neuer trainer ist besser als der alte Trainer! Bitte switch mich!
                            {
                                trainer[matchedTrainer].matchedId = -1;
                                trainer[matchedTrainer].matched = false;

                                trainer[t].matched = true;
                                trainer[t].matchedId = pokemon[favouritePokemon].id;
                                pokemon[favouritePokemon].matchedId = trainer[t].id;
                                pokemon[favouritePokemon].matched = true;
                                Console.WriteLine("Trainer {0} " + trainer[t].id + " Pokemon {0} = " + trainer[t].matchedId);

                                Console.WriteLine("-----! Ende Zyklus !------");
                                // break;
                            }
                            // break;
                        }
                        // trainer[t].favourites.SetValue(-1, f);
                        // if (trainer[t].matched == true)
                        // {
                        for (int g = 0; g == f; g++)
                        {
                            trainer[t].favourites.SetValue(-1, g);
                            Console.WriteLine("START PURGE ! :)");
                            // break;

                        }
                        // }

                        // }
                        // for (int g = 0; g <= f; g++)
                        // {
                        // trainer[t].favourites = -1;
                        // break;
                        // }
                        // break;

                    }
                }
            }
            Console.WriteLine("-----End of Loop------");
            Console.WriteLine("-----Ente of Loop------");
        }
        private static bool TrainervsTrainer(int currentPokemon, int newTrainer, int oldTrainer, List<Pokemon> pokemon, List<Trainer> trainer)
        {
            for (int i = 0; i < trainer.Count; i++)
            {
                if (oldTrainer == pokemon[currentPokemon].favourites[i])
                {
                    Console.WriteLine("Trainer OLD gewinnt! Kein switch!");

                    // nein! switch nicht
                    return true;
                }
                if (newTrainer == pokemon[currentPokemon].favourites[i])
                {
                    Console.WriteLine("Trainer NEW gewinnt! Switch!");

                    // ja aber gerne doch
                    return false;
                }
            }
            return false;
        }
    }
}
