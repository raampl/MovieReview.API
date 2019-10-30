using MovieReview.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieReview.API.Domain.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> ListAsync();

        Task<User> UpdateAsync(int id, float rating);
    }
}
