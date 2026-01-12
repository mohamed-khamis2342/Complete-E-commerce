using E_commerce.Auth;
using E_commerce.Core.Commends.Auth;
using E_commerce.DTOs;
using E_commerce.DTOs.AuthDTOs;
using E_commerce.Entities;
using E_commerce.Infrastructure.AppContext;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Core.Handlers.Auth
{
    public class RegisterHandler : IRequestHandler<RegisterCommend, ApiResponse<RegisterResponseDTO>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _dbContext;
        public RegisterHandler(UserManager<ApplicationUser>userManager,  ApplicationDbContext dbContext)
        {
            this._userManager = userManager;
            this._dbContext = dbContext;
        }
        public async Task<ApiResponse<RegisterResponseDTO>> Handle(RegisterCommend request, CancellationToken cancellationToken)
        {
            var UserFromDb = await _userManager.FindByEmailAsync(request.Email);
            if (UserFromDb != null) 
                return new ApiResponse<RegisterResponseDTO>(400,"Email is already exists");
            await using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var USer = new ApplicationUser
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    UserName = $"{request.FirstName}_{request.LastName}",
                    PhoneNumber = request.PhoneNumber,
                    DateOfBirth = request.DateOfBirth,
                };

                var result = await _userManager.CreateAsync(USer, request.Password);

                if (!result.Succeeded)
                {
                    var Errors = result.Errors.Select(e => e.Description).ToList();
                    return new ApiResponse<RegisterResponseDTO>()
                    {
                        StatusCode = 400,
                        Errors = Errors

                    };

                }
                var role = await _userManager.AddToRoleAsync(USer, "Customer");


                var customer = new Customer
                {
                    ApplicationUserId = USer.Id,

                };
                _dbContext.Customers.Add(customer);
                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();



                var response = new RegisterResponseDTO
                {
                    Id = USer.Id,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    DateOfBirth = request.DateOfBirth,
                    PhoneNumber = request.PhoneNumber,


                };



                return new ApiResponse<RegisterResponseDTO>
                {
                    StatusCode = 200,
                    Success = true,
                    Data = response,

                };


            }



            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return new ApiResponse<RegisterResponseDTO>(500, $"Registration failed: {ex.Message}");
            }

        }
    }
}
