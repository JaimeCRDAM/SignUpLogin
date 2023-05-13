using Microsoft.AspNetCore.Mvc;
using SignUpLogin.Models;
using SignUpLogin.Models.DTO;
using SignUpLogin.Models.Security;
using SignUpLogin.Repositories;

namespace SignUpLogin.Controllers
{
    public class SignUpController : ControllerBase
    {
        private readonly IBaseRepository<User> _repository;
        public SignUpController(SingUpLoginRepository<User> repository) {
            _repository = repository;
        }

        [HttpPost]
        [Route("api/signup")]
        public IActionResult SignUp([FromBody] SignupRequestDto signupRequestDto)
        {
            var exist = _repository.Find(x => x.Email == signupRequestDto.Email).FirstOrDefault();

            if (exist != null)
            {
                return BadRequest("Email already in use");
            }
            var user = new User
            {
                id = Guid.NewGuid(),
                Username = signupRequestDto.Username,
                Email = signupRequestDto.Email,
                Password = Password.HashPassword(signupRequestDto.Password),
            };
            _repository.Add(user);
            return Ok();
        }
    }
}
