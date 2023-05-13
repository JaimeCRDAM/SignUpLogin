using Cassandra.Mapping.Attributes;
using GenericTools.Database;

namespace SignUpLogin.Models
{
    public class User : BaseEntity
    {
        [Column("username")]
        public string Username { get; set; }
        [Column("email")]
        [SecondaryIndex]
        public string Email { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("createdAt")]
        [SecondaryIndex]
        public DateTime CreatedAt { get; set; }
    }
}
