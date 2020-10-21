using System;

namespace Projekt
{
    class Pokemon
    {
        private int id { get; set; }
        private Boolean matched { get; set; }

        private int[] favourites = new int[3];

        private int matchedId { get; set; }

        public Pokemon(int Id, Boolean Matched, int[] Favourites, int MatchedId)
        {
            id = Id;
            matched = Matched;
            favourites = Favourites;
            matchedId = MatchedId;
        }


    }
}
