﻿using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetablesAndFlightSchedules.Application.Abstraction;
using TimetablesAndFlightSchedules.Application.ViewModels;
using TimetablesAndFlightSchedules.Infrastructure.Identity;
using TimetablesAndFlightSchedules.Infrastructure.Identity.Enums;

namespace TimetablesAndFlightSchedules.Application.Implementation
{
    public class AccountIdentityService : IAccountService
    {
        UserManager<User> userManager;
        SignInManager<User> sigInManager;

        public AccountIdentityService(UserManager<User> userManager, SignInManager<User> sigInManager)
        {
            this.userManager = userManager;
            this.sigInManager = sigInManager;
        }

        public async Task<bool> Login(LoginViewModel vm)
        {
            var result = await sigInManager.PasswordSignInAsync(vm.Username, vm.Password, true, true);
            return result.Succeeded;
        }

        public Task Logout()
        {
            return sigInManager.SignOutAsync();
        }

        public async Task<string[]> Register(RegisterViewModel vm, Roles role)
        {
            User user = new User()
            {
                UserName = vm.Username,
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                Email = vm.Email,
                PhoneNumber = vm.Phone
            };

            string[]? errors = null;

            var result = await userManager.CreateAsync(user, vm.Password);
            if (result.Succeeded)
            {
                var resultRole = await userManager.AddToRoleAsync(user, role.ToString());

                if (resultRole.Succeeded == false)
                {
                    for (int i = 0; i < result.Errors.Count(); ++i)
                        result.Errors.Append(result.Errors.ElementAt(i));
                }
            }

            if (result.Errors != null && result.Errors.Count() > 0)
            {
                errors = new string[result.Errors.Count()];
                for (int i = 0; i < result.Errors.Count(); ++i)
                {
                    errors[i] = result.Errors.ElementAt(i).Description;
                }
            }

            return errors;
        }
    }
}