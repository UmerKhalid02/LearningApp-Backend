﻿
namespace LearningApp.Application.DataTransferObjects.AuthenticationDTO
{
    public class LoginResponseDTO
    {
        public Guid UserId { get; set; }
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
    }
}
