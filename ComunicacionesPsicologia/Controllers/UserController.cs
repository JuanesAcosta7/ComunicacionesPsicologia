using ComunicacionesPsicologia.Model;
using ComunicacionesPsicologia.Services;
using Microsoft.AspNetCore.Mvc;

namespace ComunicacionesPsicologia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarios() => Ok(await _userService.GetAllUsersAsync());
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> CreateUsuario([FromBody] Users usuario)
        {
            await _userService.AddUserAsync(usuario);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, [FromBody] Users usuario)
        {
            usuario.Id = id; // Ensure the ID is set correctly
            await _userService.UpdateUserAsync(usuario); // Pass only the user object
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            await _userService.DeleteUserAsync(id);
            return Ok();
        }
    }
}
