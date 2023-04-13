using DatingApp_Phone.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp_Phone.Services
{
    public class UserDataService : IUserDataService
    {
        private readonly IUserRepository _userRepository;

        public UserDataService()
        {
            _userRepository = new UserRepository();
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }


        public async Task CreateUserAsync(User user)
        {
            await _userRepository.CreateUserAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteUserAsync(id);
        }

        public async Task<List<User>> GetBlockedUsersAsync()
        {
            return await _userRepository.GetBlockedUsersAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task<List<User>> GetUserDislikesAsync()
        {
            return await _userRepository.GetUserDislikesAsync();
        }

        public async Task<List<User>> GetUserFeedAsync()
        {
            return await _userRepository.GetUserFeedAsync();
        }

        public async Task<List<Interest>> GetUserInterestsAsync(int id)
        {
            return await _userRepository.GetUserInterestsAsync(id);
        }

        public async Task<List<Lifestyle>> GetUserLifestylesAsync(int id)
        {
            return await _userRepository.GetUserLifestylesAsync(id);
        }

        public async Task<List<User>> GetUserLikesAsync()
        {
            return await _userRepository.GetUserLikesAsync();
        }

        public async Task<List<User>> GetUserMatchesAsync()
        {
            return await _userRepository.GetUserMatchesAsync();
        }

        public async Task<Bio> GetUserBioAsync(int id)
        {
            return await _userRepository.GetUserBioAsync(id);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.UpdateUserAsync(user);
        }

        public Task UpdateUserBioAsync(Bio bio)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateUserInterestsAsync(List<Interest> interest)
        {
            await _userRepository.UpdateUserInterestsAsync(interest);
        }

        public async Task UpdateUserLifestylesAsync(List<Lifestyle> lifestyles)
        {
            await _userRepository.UpdateUserLifestylesAsync(lifestyles);
        }

        public async Task UpdateUserPreferenceAsync(Preference preference)
        {
            await _userRepository.UpdateUserPreferenceAsync(preference);
        }

        public async Task LikeUserAsync(int id)
        {
            await _userRepository.LikeUserAsync(id);
        }

        public async Task DislikeUserAsync(int id)
        {
            await _userRepository.DislikeUserAsync(id);
        }

        public async Task<List<Picture>> GetUserPicturesAsync()
        {
            return await _userRepository.GetUserPicturesAsync();
        }

        public async Task UploadPicture(Picture picture)
        {
            await _userRepository.UploadPicture(picture);
        }
    }
}
