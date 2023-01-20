using BlazorAppTestOgSikkerhed.Models;

namespace BlazorAppTestOgSikkerhed.Services
{
    public interface IUserService
    {
        // Get
        //Users Get(string UserName);
        // List
        List<Users> List();
        // Update
        Users Update(Users user);
        // Delete
        void Delete(Users user);
    }
}
