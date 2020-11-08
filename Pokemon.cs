using System;
using System.Collections.Generic;

namespace Projekt
{
    class Pokemon
    {
        public int id { get; set; }
        public Boolean matched { get; set; }

        public List<int> favourites = new List<int>();

        public int matchedId { get; set; }

        public Pokemon(int Id, Boolean Matched, List<int> Favourites, int MatchedId)
        {
            id = Id;
            matched = Matched;
            favourites = Favourites;
            matchedId = MatchedId;
        }


    }
}
