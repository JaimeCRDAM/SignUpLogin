using Cassandra.Mapping.Attributes;
using GenericTools.Database;

namespace SignUpLogin.Models.DTO
{
    public class SignupRequestDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
