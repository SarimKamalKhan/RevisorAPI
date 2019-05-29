using RevisorAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisorAPI.Repository.Registration
{
    interface IRegistration
    {
        Task<bool> User_Registration(string email, string password);

        Task<IEnumerable<Register>> CheckUserExistance(string email, string password);

        Task<IEnumerable<Register>> CheckUserExistance(string email);
    }
}
