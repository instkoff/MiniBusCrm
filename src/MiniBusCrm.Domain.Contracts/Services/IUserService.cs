using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MiniBusCrm.Domain.Contracts.Models;
using MiniBusCrm.Domain.Contracts.Models.Requests;
using MiniBusCrm.Domain.Contracts.Wrappers;

namespace MiniBusCrm.Domain.Contracts.Services
{
    public interface IUserService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);

        Task<UserModel> GetById(Guid id);

        Task<List<UserModel>> GetAllUsers();

        Task<int> CreateUser(UserModel newUser);

        Task<int> UpdateUser(UserModel editedUser);

        Task<int> DeleteUser(Guid id);
    }
}