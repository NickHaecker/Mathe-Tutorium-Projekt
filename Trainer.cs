using System;

namespace Projekt
{
    class Trainer
    {
        public int id { get; set; }
        public Boolean matched { get; set; }

        public int[] favourites = new int[3];

        public int matchedId { get; set; }

        public Trainer(int Id, Boolean Matched, int[] Favourites, int MatchedId)
        {
            id = Id;
            matched = Matched;
            favourites = Favourites;
            matchedId = MatchedId;
        }


    }
}
