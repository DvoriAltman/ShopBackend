using Shop.DAL.Entities;
using Shop.DTO.Mapper;

namespace Shop.BL
{
    public interface IUsersBL
    {
        public Task<UserDTO> AddUser(UserDTO user);
        public Task<User> GetUserById(int userId);
        public Task<List<User>> GetUsers();
        public Task<bool> RemoveUser(int userId);
        public Task<UserDTO> UpdateUser(UserDTO usre, int userId);
    }
}