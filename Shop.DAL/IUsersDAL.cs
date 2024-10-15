using Shop.DAL.Entities;

namespace Shop.DAL
{
    public interface IUsersDAL
    {
        public Task<User> AddUser(User user);
        public Task<User> UpdateUser(User usre, int userId);
        public Task<User> GetUserById(int userId);
        public Task<List<User>> GetUsers();
        public Task<bool> RemoveUser(int userId);
    }
}