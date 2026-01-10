using E_commerce.Auth;
using E_commerce.Core.Commends.Auth;
using E_commerce.DTOs;
using E_commerce.DTOs.AuthDTOs;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace E_commerce.Core.Handlers.Auth
{
    public class LoginHandler : IRequestHandler<LoginCommend, ApiResponse<LoginResponseDTO>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public LoginHandler(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }


        public async Task<ApiResponse<LoginResponseDTO>> Handle(LoginCommend request, CancellationToken cancellationToken)
        {
            var UserFromDB = await _userManager.FindByEmailAsync(request.Email);

            if (UserFromDB is null)
            {

                return new ApiResponse<LoginResponseDTO>(404, "UnAuthorized");

            }

            var found = await _userManager.CheckPasswordAsync(UserFromDB, request.Password);

            if (!found)
            {
                return new ApiResponse<LoginResponseDTO>(404, "UnAuthorized");
            }


            var token =await GeneratJWTtoken(UserFromDB);
            var UserRoles = await _userManager.GetRolesAsync(UserFromDB);

            var loginResponse = new LoginResponseDTO
            {
                CustomerId = UserFromDB.Id,
                CustomerName = UserFromDB.UserName,
                PhoneNumber = UserFromDB.PhoneNumber,
                Email = UserFromDB.Email,

                Token =  token,
                Roles = UserRoles.ToList(),
                Message = "Loged in Succssfully"


            };
          
            if (UserFromDB.RefreshTokens.Any(e => e.IsActive))
            {
                var refreshToken = UserFromDB.RefreshTokens.SingleOrDefault(e => e.IsActive);
                loginResponse.RefreshToken = refreshToken.Token;
                loginResponse.RefreshTokenExpires = refreshToken.ExpiresOn;

            }
            else
            {
                var createRefreshToken = GetRefreshToken();
                loginResponse.RefreshToken = createRefreshToken.Token;
                loginResponse.RefreshTokenExpires = createRefreshToken.ExpiresOn;

                UserFromDB.RefreshTokens.Add(createRefreshToken);
                await _userManager.UpdateAsync(UserFromDB);


            }


            return new ApiResponse<LoginResponseDTO>
            {
                StatusCode = 200,
                Success = true,

                Data = loginResponse

            };
        }




        private async Task<string> GeneratJWTtoken(ApplicationUser _applicationUser)
        {
            List<Claim> claims = new List<Claim>
                        {
                            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                                new Claim("UserName", _applicationUser.UserName),
                                new Claim("UserID", _applicationUser.Id)
                        };
            var userRoles = await _userManager.GetRolesAsync(_applicationUser);
            foreach (var claim in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, claim));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));

            var sincrdt = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: sincrdt

                );
            string TokenHandeld = new JwtSecurityTokenHandler().WriteToken(token);

            return TokenHandeld;
        }
        private RefreshToken GetRefreshToken()
        {
            var randomNumber = new byte[32];

            using var generator = RandomNumberGenerator.Create();
            generator.GetBytes(randomNumber);

            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomNumber),
                ExpiresOn = DateTime.UtcNow.AddDays(7),
                CreatedOn = DateTime.UtcNow,

            };
        }



    }
}
