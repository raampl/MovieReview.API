using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieReview.API.Domain.Models;

namespace MovieReview.API.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();

        Task<User> FindByIdAsync(int id);
        void Update(User user);
    }
}
