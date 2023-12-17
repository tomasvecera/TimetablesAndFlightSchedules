using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetablesAndFlightSchedules.Application.ViewModels;
using TimetablesAndFlightSchedules.Infrastructure.Identity.Enums;

namespace TimetablesAndFlightSchedules.Application.Abstraction
{
    public interface IAccountService
    {
        Task<string[]> Register(RegisterViewModel vm, Roles role);
        Task<bool> Login(LoginViewModel vm);
        Task Logout();
    }
}
