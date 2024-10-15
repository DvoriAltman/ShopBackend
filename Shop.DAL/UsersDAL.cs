using Shop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Shop.DAL
{
    public class UsersDAL : IUsersDAL
    {
        //יצירת משתנה לצורך שימוש בקונטקס
        ShopContext _context;

        //בנאי קונסטרקטור לקלאס
        public UsersDAL(ShopContext context)
        {
            _context = context;
        }

        //פונקציה המחזירה את כל היוזרים
        public async Task<List<User>> GetUsers()
        {
            List<User> users = await _context.Users.ToListAsync();
            return users;
        }

        //פונקציה המחזירה יוזר בודד
        public async Task<User> GetUserById(int userId)
        {
            User current = await _context.Users.FindAsync(userId);
            if (current.UserId == userId)
                return current;
            return null;
        }

        //public async Task<User> GetUserById(int id)
        //{
        //    if(id <= 0)
        //    {
        //        throw new ArgumentException("Invalid ID", nameof(id));
        //    }
        //    var user = await _context.Users.FindAsync(id);

        //    if(user == null)
        //    {
        //        throw new ArgumentException("user not found");
        //    }

        //    return user;
        //}


        //פונקציה שמוסיפה יוזר חדש
        public async Task<User> AddUser(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //פונקציה שמוחקת יוזר
        public async Task<bool> RemoveUser(int userId)
        {
            try
            {
                User currentUser = await _context.Users.SingleOrDefaultAsync(item => item.UserId == userId);
                if (currentUser == null)
                {
                    throw new ArgumentException($"{userId} is not found");
                }
                _context.Users.Remove(currentUser);
                await _context.SaveChangesAsync();
                return true;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        //פונקציה מעדכנת שדות של היוזר
        public async Task<User> UpdateUser(User usre, int userId)
        {
            try
            {
                User current = await _context.Users.FirstOrDefaultAsync(item => item.UserId == userId);
                if (current != null)
                {
                    User.ReferenceEquals(current.UserName, usre.UserName);
                    User.ReferenceEquals(current.Email, usre.Email);
                    User.ReferenceEquals(current.Password, usre.Password);

                    _context.Users.Update(current);
                    await _context.SaveChangesAsync();
                    return current;
                }
                else
                    return null;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
