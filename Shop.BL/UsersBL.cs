using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shop.DAL;
using Shop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.DTO;
using Shop.DTO.Mapper;


namespace Shop.BL
{
    public class UsersBL : IUsersBL
    {
        IUsersDAL _userDAL;
        IMapper _mapper;

        public UsersBL(IUsersDAL userDAL, IMapper mapper)
        {
            _userDAL = userDAL;
            _mapper = mapper;
        }

        public async Task<List<User>> GetUsers()
        {
            List<User> users = await _userDAL.GetUsers();
            return users;

        }

        public async Task<User> GetUserById(int userId)
        {
            User currentUser = await _userDAL.GetUserById(userId);
            return currentUser;
        }

        public async Task<UserDTO> AddUser(UserDTO user)
        {
            User u = _mapper.Map<User>(user);
            User isAdd = await _userDAL.AddUser(u);
            UserDTO userDTO = _mapper.Map<UserDTO>(isAdd);
            return userDTO;
        }

        public async Task<bool> RemoveUser(int userId)
        {
            int u = _mapper.Map<int>(userId);
            bool isRemove = await _userDAL.RemoveUser(u);
            return isRemove;
        }


        public async Task<UserDTO> UpdateUser(UserDTO usre, int userId)
        {
            User u = _mapper.Map<User>(usre);
            User updateUser = await _userDAL.UpdateUser(u, userId);
            UserDTO userDTO = _mapper.Map<UserDTO>(updateUser);
            return userDTO;
        }

    }
}
