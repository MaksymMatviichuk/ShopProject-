using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSystem.Models
{
    class Movie
    {
        public string Title { get; private set; }
        public int Duration { get; private set; }
        public int AgeRestriction { get; private set; }

        public Movie(string title, int duration, int ageRestriction)
        {
            Title = title;
            Duration = duration;
            AgeRestriction = ageRestriction;
        }
    }
}
