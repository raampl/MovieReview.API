using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieReview.API.Persistence.Contexts;

namespace MovieReview.API.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
