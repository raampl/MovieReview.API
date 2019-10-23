using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieReview.API.Domain.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        public string Title { get; set; }

        public int YearOfRelease { get; set; }

        public int RunningTime { get; set; }

        [Range(1, 5)]
        public float AverageRating { get; set; }

        public EGenre Genre { get; set; }

        public IList<User> Users { get; set; } = new List<User>();
    }
}
