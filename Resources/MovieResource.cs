using MovieReview.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieReview.API.Resources
{
    public class MovieResource
    {
        public int MovieId { get; set; }

        public string Title { get; set; }

        public int YearOfRelease { get; set; }

        public int RunningTime { get; set; }

        public float AverageRating { get; set; }

        public string Genre { get; set; }
    }
}
