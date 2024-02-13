using LearningApp.Application.Constants;
using LearningApp.Application.DataTransferObjects.AuthenticationDTO;
using LearningApp.Application.DataTransferObjects.Shared;
using LearningApp.Application.Exceptions;
using LearningApp.Data.Entities;
using LearningApp.Data.Entities.UserEntity;
using LearningApp.Data.IRepositories.IAuthenticationRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace LearningApp.Data.Repositories.AuthenticationRepository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly EFDataContext _context;

        public AuthenticationRepository(EFDataContext context)
        {
            _context = context;
        }

        private async Task<string> GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            await Task.Run(() =>
            {
                using var rng = RandomNumberGenerator.Create();
                rng.GetBytes(randomNumber);
            });
            return Convert.ToBase64String(randomNumber);
        }

        private static SecurityTokenDescriptor GetTokenDescriptor(User user, string roleName, DateTime tokenTime)
        {
            var key = Encoding.ASCII.GetBytes(JwtConfig.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimsConstant.UserId, user.UserId.ToString()),
                    new Claim(ClaimsConstant.UserName, user.UserName),
                    new Claim(ClaimsConstant.Email, user.Email),
                    new Claim(ClaimTypes.Role, roleName),
                    new Claim(ClaimsConstant.ProjectScope, ClaimsConstant.ProjectScopeValue),
                }),
                Expires = tokenTime, // expiry time of access token
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenDescriptor;
        }

        private async Task<bool> SaveRefreshToken(string OldRefreshToken, string RefreshToken, Guid userId)
        {
            UserLogin? userLogin = await _context.UserLogin.Where(m => m.RefreshToken == OldRefreshToken && m.UserId == userId).FirstOrDefaultAsync();
            if (userLogin != null)
            {
                userLogin.UserId = userId;
                userLogin.RefreshToken = RefreshToken;
                userLogin.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(25);
                userLogin.Status = "active";
                userLogin.RefreshTokenCreatedAt = DateTime.Now;
                userLogin.RefreshTokenUpdatedAt = DateTime.Now;
            }
            else
            {
                UserLogin obj = new()
                {
                    LogOutAt = DateTime.Now,
                    UserId = userId,
                    RefreshToken = RefreshToken,
                    RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(25),
                    RefreshTokenUpdatedAt = DateTime.Now,
                    RefreshTokenCreatedAt = DateTime.Now,
                    Status = "active"
                };
                await _context.UserLogin.AddAsync(obj);
            }
            await _context.SaveChangesAsync();
            return true;
        }

        // TODO: when access token expires, generate new access token if refresh token is valid (handle this in authorization middleware)
        public async Task<LoginResponseDTO> Authenticate(LoginRequestDTO request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => (x.UserName == request.UserName || x.Email == request.UserName) && x.Password == request.Password && x.IsActive == true && x.DeletedAt == null);

            if (user == null)
                return null;

            var userRole = _context.UserRoles.Include(x => x.Role).FirstOrDefault(x => x.UserId == user.UserId && x.IsActive == true && x.DeletedAt == null);
            var newRefreshToken = GenerateRefreshToken();

            var tokenDescriptor = GetTokenDescriptor(user, userRole.Role.RoleName, DateTime.UtcNow.AddMinutes(1));

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            string refreshToken = await newRefreshToken;

            // save refresh token in database
            await SaveRefreshToken("", refreshToken, user.UserId);

            return new LoginResponseDTO()
            {
                UserId = user.UserId,
                Token = tokenString,
                RefreshToken = refreshToken,
            };
        }

        public async Task<UserLogin> GetUserLoginRecord(Guid userId, string refreshToken)
        {
            var userLogin = await _context.UserLogin.FirstOrDefaultAsync(x => x.UserId == userId && x.RefreshToken == refreshToken && x.Status == "active");
            return userLogin;
        }

        public async Task<string> GenerateAccessToken(Guid userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == userId && x.IsActive == true && x.DeletedAt == null);
            if (user == null)
                return null;
            var userRole = await _context.UserRoles.Include(x => x.Role).FirstOrDefaultAsync(x => x.UserId == user.UserId && x.IsActive == true && x.DeletedAt == null);
            var tokenDescriptor = GetTokenDescriptor(user, userRole.Role.RoleName, DateTime.UtcNow.AddSeconds(30));
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }

        public async Task<bool> Logout(LogoutRequestModel model)
        {
            try
            {
                IList<FluentValidation.Results.ValidationFailure> errorMessages = new List<FluentValidation.Results.ValidationFailure>();
                UserLogin userSession = await _context.UserLogin.Where(m => m.UserId == model.UserId).FirstOrDefaultAsync();
                if (userSession != null)
                {
                    userSession.LogOutAt = DateTime.UtcNow;
                    userSession.Status = "inactive";
                    userSession.RefreshTokenExpiryTime = DateTime.UtcNow;
                    await _context.SaveChangesAsync();
                    return true;
                }

                errorMessages.Add(new FluentValidation.Results.ValidationFailure("UserId", "Incorrect UserId please check!"));
                errorMessages.Add(new FluentValidation.Results.ValidationFailure("Token", "Incorrect token please check!"));
                ErrorModel error = new()
                {
                    latestError = "Incorrect token please check!"
                };

                if (errorMessages.Count > 0) throw new ValidationException(errorMessages);
                return false;
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message);
            }
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            var user = await _context.Users.Where(x => x.Email == email && x.IsActive).FirstOrDefaultAsync();
            return user;
        }

        public async Task<User?> GetUserByUserName(string username)
        {
            var user = await _context.Users.Where(x => x.UserName == username && x.IsActive).FirstOrDefaultAsync();
            return user;
        }

        public async Task<User> AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            return user;
        }

        public async Task<UserRole> AddUserRole(UserRole userRole)
        {
            await _context.UserRoles.AddAsync(userRole);
            return userRole;
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
