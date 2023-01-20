using BlazorAppTestOgSikkerhed.Data;
using BlazorAppTestOgSikkerhed.Models;

namespace BlazorAppTestOgSikkerhed.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _db;

        public UserService(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Delete(Users user)
        {
            throw new NotImplementedException();
        }

        public List<Users> List()
        {
            return _db.Users.ToList();
        }

        public Users Update(Users user)
        {
            throw new NotImplementedException();
        }
    }
}
