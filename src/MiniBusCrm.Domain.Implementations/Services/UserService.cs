using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MiniBusCrm.DataAccess.Contracts;
using MiniBusCrm.DataAccess.Contracts.Entities;
using MiniBusCrm.Domain.Contracts.Exceptions;
using MiniBusCrm.Domain.Contracts.Models;
using MiniBusCrm.Domain.Contracts.Models.Requests;
using MiniBusCrm.Domain.Contracts.Models.Settings;
using MiniBusCrm.Domain.Contracts.Services;
using MiniBusCrm.Domain.Contracts.Wrappers;
using MiniBusCrm.Domain.Implementations.Helpers;

namespace MiniBusCrm.Domain.Implementations.Services
{
    public class UserService : IUserService
    {
        private readonly IDbRepository _dbRepository;
        private readonly IMapper _mapper;
        private readonly AppSettings _settings;

        public UserService(IOptions<AppSettings> settings, IDbRepository dbRepository, IMapper mapper)
        {
            _settings = settings.Value;
            _dbRepository = dbRepository;
            _mapper = mapper;
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
        {
            var user = await _dbRepository.Get<UserEntity>(x => x.Username == request.Username)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            if (user == null) return null;
            if (!PasswordHasher.Check(user.Password, request.Password)) return null;
            var token = GenerateJwtToken(user);
            return new AuthenticateResponse(user, token);
        }



        public async Task<UserModel> GetById(Guid id)
        {
            var userEntity = await _dbRepository.Get<UserEntity>(x => x.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            var userModel = _mapper.Map<UserModel>(userEntity);
            return userModel;
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            var usersQuery = _dbRepository.Get<UserEntity>();
            var usersCount = await usersQuery.CountAsync();
            var usersCollection = await usersQuery.ToListAsync();
            var userModels = _mapper.Map<List<UserModel>>(usersCollection);
            return userModels;

        }

        public async Task<int> CreateUser(UserModel newUser)
        {
            var user = await _dbRepository.GetAll<UserEntity>().Where(x => x.Username == newUser.Username)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            if (user != null) throw new UniqueUsernameException("Username must be unique!");
            var userEntity = _mapper.Map<UserEntity>(newUser);
            await _dbRepository.Add(userEntity);
            return await _dbRepository.SaveChangesAsync();
        }

        public async Task<int> UpdateUser(UserModel editedUser)
        {
            var userEntity = await _dbRepository.Get<UserEntity>(x => x.Id == editedUser.Id).FirstOrDefaultAsync();
            _mapper.Map(editedUser, userEntity);
            return await _dbRepository.SaveChangesAsync();

        }

        public async Task<int> DeleteUser(Guid id)
        {
            await _dbRepository.Delete<UserEntity>(id);
            return await _dbRepository.SaveChangesAsync();
        }

        private string GenerateJwtToken(UserEntity user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id", user.Id.ToString()),
                    new Claim("role", user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}