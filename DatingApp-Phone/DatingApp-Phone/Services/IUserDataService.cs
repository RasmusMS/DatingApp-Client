using DatingApp_Phone.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp_Phone.Services
{
    public interface IUserDataService
    {
        // Read
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<List<User>> GetUserFeedAsync();
        Task<List<User>> GetBlockedUsersAsync();
        Task<List<Interest>> GetUserInterestsAsync(int id);
        Task<List<Lifestyle>> GetUserLifestylesAsync(int id);
        Task<List<User>> GetUserLikesAsync();
        Task<List<User>> GetUserDislikesAsync();
        Task<List<User>> GetUserMatchesAsync();
        Task<Bio> GetUserBioAsync(int id);
        Task<List<Picture>> GetUserPicturesAsync();

        // Create
        Task CreateUserAsync(User user);
        Task LikeUserAsync(int id);
        Task DislikeUserAsync(int id);
        Task UploadPicture(Picture picture);

        // Update
        Task UpdateUserAsync(User user);
        Task UpdateUserInterestsAsync(List<Interest> interest);
        Task UpdateUserLifestylesAsync(List<Lifestyle> lifestyles);
        Task UpdateUserPreferenceAsync(Preference preference);
        Task UpdateUserBioAsync(Bio bio);

        // Delete
        Task DeleteUserAsync(int id);
    }
}
