using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieReview.API.Domain.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        [Range(1, 5)]
        public float AverageRating { get; set; }

        //public IList<Movie> Movies { get; set; } = new List<Movie>();

        public int MovieId { get; set; }

        public Movie Movie { get; set; }
    }
}
