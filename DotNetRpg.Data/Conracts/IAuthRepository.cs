using DotNetRpg.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNetRpg.Data.Conracts
{
    public interface IAuthRepository
    {
        Task<ServiceResponce<int>> Register(User user, string password);
        Task<ServiceResponce<string>> Login(string username, string password);
        Task<bool> UserExist(string username);
    }
}
