using MovieReview.API.Domain.Models;
using MovieReview.API.Domain.Repositories;
using MovieReview.API.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieReview.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }

        public async Task<User> UpdateAsync(int id, float rating)
        {
            var exisitingUser =  await _userRepository.FindByIdAsync(id);

            if (exisitingUser != null)
            {
                exisitingUser.AverageRating = rating;

                _userRepository.Update(exisitingUser);
            }

            return exisitingUser;
        }
    }
}
