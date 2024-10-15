using Microsoft.AspNetCore.Mvc;
using Shop.BL;
using Shop.DAL.Entities;
using Shop.DTO.Mapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUsersBL _userBL;

        public UsersController(IUsersBL usersBL)
        {
            _userBL = usersBL;
        }

        //get all

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<List<User>> GetUsers()
        {
            List<User> users = await _userBL.GetUsers();
            return users;

        }

        //get one

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<User> GetUserById(int userId)
        {
            User currentUser = await _userBL.GetUserById(userId);
            return currentUser;
        }

        //add

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult<UserDTO>> AddUser([FromBody] UserDTO userDTO)
        {
            try
            {
                UserDTO isAddUser = await _userBL.AddUser(userDTO);
                return Ok(isAddUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //update

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UserDTO>> UpdateUser([FromBody] UserDTO userDTO, int id)
        {
            try
            {
                UserDTO updateUser = await _userBL.UpdateUser(userDTO, id);
                if (updateUser != null)
                    return Ok(userDTO);
                return BadRequest();

            }
            catch (Exception ex)
            {
                string message = ex.Message + "somthing went wrong";
                throw new Exception(message);
            }
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> RemoveUser([FromBody] int id)
        {
            try
            {
                bool isRemoveUser = await _userBL.RemoveUser(id);
                return isRemoveUser;
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }
    }
}
