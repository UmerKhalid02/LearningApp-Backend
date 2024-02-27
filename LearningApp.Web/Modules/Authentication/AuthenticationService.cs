using AutoMapper;
using LearningApp.Application.DataTransferObjects.AuthenticationDTO;
using LearningApp.Application.Enums;
using LearningApp.Application.Exceptions;
using LearningApp.Application.Wrappers;
using LearningApp.Data.Entities.UserEntity;
using LearningApp.Data.IRepositories.IAuthenticationRepository;

namespace LearningApp.Web.Modules.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly IMapper _mapper;

        public AuthenticationService(IAuthenticationRepository authenticationRepository, IMapper mapper)
        {
            _authenticationRepository = authenticationRepository;
            _mapper = mapper;
        }

        public async Task<Response<LoginResponseDTO>> Authenticate(LoginRequestDTO request)
        {
            var result = await _authenticationRepository.Authenticate(request);

            if (result == null) {
                throw new BadRequestException(GeneralMessages.UserLoginFail);
            }

            JwtTokenRequestDTO refreshTokenRequestModel = new()
            {
                JwtToken = result.Token,
                RefreshToken = result.RefreshToken
            };

            return new Response<LoginResponseDTO>(true, result, GeneralMessages.UserLoggedInSuccessMessage);
        }

        public async Task<Response<RefreshTokenResponseDTO>> Refresh(RefreshTokenRequestDTO request, string refreshToken)
        {
            // get user login record
            var userLogin = await _authenticationRepository.GetUserLoginRecord(request.UserId, refreshToken);
            if (userLogin == null) {
                throw new UnauthorizedAccessException(GeneralMessages.UnauthorizedAccess);
            }

            // generate new access token
            var token = await _authenticationRepository.GenerateAccessToken(request.UserId);
            JwtTokenRequestDTO refreshTokenRequestModel = new()
            {
                JwtToken = token,
                RefreshToken = refreshToken
            };

            var refreshResponse = new RefreshTokenResponseDTO
            {
                Token = token,
            };

            return new Response<RefreshTokenResponseDTO>(true, refreshResponse, null);
        }

        public async Task<Response<bool>> LogoutService(LogoutRequestModel model)
        {
            dynamic result = await _authenticationRepository.Logout(model);
            if (result)
            {
                return new Response<bool>(true, true, GeneralMessages.UserLogoutSuccessMessage);
            }
            else
            {
                throw new Exception(GeneralMessages.UserLogoutFailMessage);
            }
        }

        public async Task<Response<bool>> Register(RegisterRequestDTO request)
        {
            // check if password and confirm password match
            if (request.Password != request.ConfirmPassword)
                throw new BadRequestException(GeneralMessages.PasswordMatchError);

            // check if user with username already exists
            var userWithUsername = await _authenticationRepository.GetUserByUserName(request.UserName);
            if (userWithUsername != null)
                throw new ConflictException(GeneralMessages.UsernameExists);

            // check if user with email already exists
            var userWithEmail = await _authenticationRepository.GetUserByEmail(request.Email);
            if (userWithEmail != null)
                throw new ConflictException(GeneralMessages.UsernameExists);

            // check if role is correct
            if (!request.Role.Equals(RolesKey.Student, StringComparison.OrdinalIgnoreCase) &&
                !request.Role.Equals(RolesKey.Teacher, StringComparison.OrdinalIgnoreCase))
            {
                throw new BadRequestException(GeneralMessages.InvalidRole);
            }

            var user = _mapper.Map<User>(request);
            user.UserId = Guid.NewGuid();
            user.IsActive = true;
            user.CreatedAt = DateTime.UtcNow;
           
            // add the user in database
            await _authenticationRepository.AddUser(user);
            await _authenticationRepository.SaveChanges();

            Guid roleId;
            if (request.Role.Equals(RolesKey.Student, StringComparison.OrdinalIgnoreCase))
                roleId = RolesKey.StudentRoleId;
            else
                roleId = RolesKey.TeacherRoleId;

            UserRole userRole = new UserRole
            {
                UserId = user.UserId,
                RoleId = roleId,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
            };

            // add user role for that user in the database
            await _authenticationRepository.AddUserRole(userRole);
            await _authenticationRepository.SaveChanges();

            return new Response<bool>(true, true, GeneralMessages.RegisterationSuccessful);
        }
    }
}
