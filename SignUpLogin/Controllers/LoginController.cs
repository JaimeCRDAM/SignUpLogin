using Microsoft.AspNetCore.Mvc;
using SignUpLogin.Models.DTO;
using SignUpLogin.Models;
using SignUpLogin.Models.Security;
using SignUpLogin.Repositories;

namespace SignUpLogin.Controllers
{
    public class LoginController : ControllerBase
    {
        private readonly IBaseRepository<User> _repository;
        private JwtController _jwtController;
        public LoginController(SingUpLoginRepository<User> repository, JwtController jwtController)
        {
            _repository = repository;
            _jwtController= jwtController;
        }

        [HttpPost]
        [Route("api/login")]
        public IActionResult Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var user = _repository.Find(x => x.Email == loginRequestDto.Email).FirstOrDefault();

            if (user == null)
            {
                return BadRequest("Email or password incorrect");
            }

            if (!Password.VerifyPassword(loginRequestDto.Password, user.Password))
            {
                return BadRequest("Email or password incorrect");
            }

            var jwt = _jwtController.GenerateToken(user);
            var loginResponseDto = new LoginResponseDto
            {
              Token = jwt
            };

            return Ok();
        }
    }
}
