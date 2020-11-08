using System;
using System.Collections.Generic;
using System.Collections;

namespace Projekt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pokemon> pokemons = new List<Pokemon>();
            List<Trainer> trainer = new List<Trainer>();

            pokemons.Add(new Pokemon(0, false, new List<int> { 1, 0, 2 }, -1));
            pokemons.Add(new Pokemon(1, false, new List<int> { 2, 1, 0 }, -1));
            pokemons.Add(new Pokemon(2, false, new List<int> { 2, 1, 0 }, -1));
            trainer.Add(new Trainer(0, false, new List<int> { 2, 1, 0 }, -1));
            trainer.Add(new Trainer(1, false, new List<int> { 1, 2, 0 }, -1));
            trainer.Add(new Trainer(2, false, new List<int> { 0, 2, 1 }, -1));

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
                    Console.WriteLine("t" + t);

                    if (trainer[t].matched == false)
                    {
                        int f = 0;
                        int favouritePokemon = trainer[t].favourites[f];
                        Console.WriteLine("Fav Pok id: {0}", favouritePokemon);
                        if (pokemon[favouritePokemon].matched == false)
                        {
                            Console.WriteLine("Matchig erfolgreich! FreeTrainer -1 ");
                            trainer[t].matched = true;
                            trainer[t].matchedId = pokemon[favouritePokemon].id;
                            pokemon[favouritePokemon].matched = true;
                            pokemon[favouritePokemon].matchedId = trainer[t].id;
                            freeTrainer--;

                            Console.WriteLine("Trainer " + trainer[t].id + " Pokemon  = " + trainer[t].matchedId);
                            Console.WriteLine("FreeTrainer:{0} -1", freeTrainer);
                        }
                        else
                        {
                            int matchedTrainer = trainer[pokemon[favouritePokemon].matchedId].id;
                            Console.WriteLine("# Pokemon already matched !");
                            Console.WriteLine("START DDDDUELL !!!");
                            //neuer trainer ist besser als der alte Trainer! Bitte switch mich!
                            if (TrainervsTrainer(pokemon[favouritePokemon].id, trainer[t].id, matchedTrainer, pokemon, trainer) == false)
                            {
                                trainer[matchedTrainer].matchedId = -1;
                                trainer[matchedTrainer].matched = false;

                                trainer[t].matched = true;
                                trainer[t].matchedId = pokemon[favouritePokemon].id;
                                pokemon[favouritePokemon].matchedId = trainer[t].id;
                                pokemon[favouritePokemon].matched = true;
                                Console.WriteLine("Trainer" + trainer[t].id + " Pokemon= " + trainer[t].matchedId);
                            }
                        }
                        Console.WriteLine("gelöscht wird pokemon:" + trainer[t].favourites[f] + " von Trainer:" + trainer[t].id);
                        trainer[t].favourites.RemoveAt(f);

                        Console.WriteLine("-----! Ende Zyklus !------");
                    }
                    else
                    {
                        Console.WriteLine("# Trainer is already matched !");
                    }
                }
            }
            Console.WriteLine("-----End of Loop------");

            Console.WriteLine("#############");
            Console.WriteLine("RESULT OF LOOP");
            Console.WriteLine("#############");

            for (int d = 0; d < trainer.Count; d++)
            {
                if (trainer[d].matched)
                {
                    Console.WriteLine("Trainer " + trainer[d].id + " is matched with Pokemon " + trainer[d].matchedId);
                }
                else
                {
                    Console.WriteLine("Trainer " + trainer[d].id + " is unmatched // MatchedID: " + trainer[d].matchedId);
                }
            }

            for (int d = 0; d < pokemon.Count; d++)
            {
                if (pokemon[d].matched)
                {
                    Console.WriteLine("Pokemon " + pokemon[d].id + " is matched with Trainer " + pokemon[d].matchedId);
                }
                else
                {
                    Console.WriteLine("Pokemon " + pokemon[d].id + " is unmatched // MatchedID: " + pokemon[d].matchedId);
                }
            }

        }
        private static bool TrainervsTrainer(int currentPokemon, int newTrainer, int oldTrainer, List<Pokemon> pokemon, List<Trainer> trainer)
        {
            for (int i = 0; i < trainer.Count; i++)
            {
                if (oldTrainer == pokemon[currentPokemon].favourites[i])
                {
                    Console.WriteLine("Trainer OLD gewinnt! Kein switch!");
                    return true;
                }
                if (newTrainer == pokemon[currentPokemon].favourites[i])
                {
                    Console.WriteLine("Trainer NEW gewinnt! Switch!");
                    return false;
                }
            }
            return true;
        }
    }
}
