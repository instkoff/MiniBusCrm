using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MiniBusCrm.DataAccess.Contracts.Entities
{
    public class UserEntity : BaseEntity
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Role { get; set; }

        [JsonIgnore] public string Password { get; set; }
    }
}