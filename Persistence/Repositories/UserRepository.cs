using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieReview.API.Domain.Models;
using MovieReview.API.Domain.Repositories;
using MovieReview.API.Persistence.Contexts;

namespace MovieReview.API.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {

        }
        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> FindByIdAsync(int id)
        {
            return await _context.Users.Where(u => u.UserId == id).FirstAsync();
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }
    }
}
