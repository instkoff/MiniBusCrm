using System;
using MiniBusCrm.DataAccess.Contracts.Entities;

namespace MiniBusCrm.Domain.Contracts.Wrappers
{
    public class AuthenticateResponse
    {
        public AuthenticateResponse(UserEntity user, string token)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Username = user.Username;
            Role = user.Role;
            Token = token;
        }

        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Username { get; }
        public string Token { get; }
        public string Role { get; }
    }
}