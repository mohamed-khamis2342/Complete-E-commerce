using E_commerce.Auth;
using E_commerce.Core.Commends.Auth;
using E_commerce.DTOs;
using E_commerce.DTOs.AuthDTOs;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace E_commerce.Core.Handlers.Auth
{
    public class RefreshTokenHandler : IRequestHandler<RefreshTokenCommend, ApiResponse<LoginResponseDTO>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public RefreshTokenHandler(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            this._userManager = userManager;
            _configuration = configuration;
        }
        public async Task<ApiResponse<LoginResponseDTO>> Handle(RefreshTokenCommend request, CancellationToken cancellationToken)
        {
            var UserFromDb = _userManager.Users.SingleOrDefault(e => e.RefreshTokens.Any(e => e.Token == request.Token));

            if (UserFromDb == null)
            {
                return new ApiResponse<LoginResponseDTO>(400, "Invalid Token");

            }

            var RefreshToken = UserFromDb.RefreshTokens.SingleOrDefault(e => e.Token == request.Token);


            if (!RefreshToken.IsActive)
            {
                return new ApiResponse<LoginResponseDTO>(400, "Invalid Token");
            }

            RefreshToken.RevokedOn = DateTime.UtcNow;

            var UserRoles = await _userManager.GetRolesAsync(UserFromDb);


            var Token = await GeneratJWTtoken(UserFromDb);



            var GenerateRefreshToken = GetRefreshToken();


            var response = new LoginResponseDTO()
            {
                CustomerId = UserFromDb.Id,
                CustomerName = UserFromDb.UserName,
                Email = UserFromDb.Email,
                Token = Token,
                Message = "success",
                PhoneNumber = UserFromDb.PhoneNumber,
                Roles = UserRoles.ToList(),
                RefreshToken = GenerateRefreshToken.Token,
                RefreshTokenExpires = GenerateRefreshToken.ExpiresOn

            };

            UserFromDb.RefreshTokens.Add(GenerateRefreshToken);
            await _userManager.UpdateAsync(UserFromDb);

            return new ApiResponse<LoginResponseDTO>
            {
                StatusCode = 200,
                Success = true,
                Data = response
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
