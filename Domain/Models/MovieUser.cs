using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieReview.API.Domain.Models;

namespace MovieReview.API.Domain.Models
{
    public class MovieUser
    {
        public int MovieId { get; set; }

        public Movie Movie { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
