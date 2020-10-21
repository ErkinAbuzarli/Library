using System.Collections.Generic;
using System.Threading.Tasks;
using Library.DTOs;
using Library.Models;

namespace Library.Data
{
    public interface ILogin
    {
        Task<User> Login(LoginDTO login);
        Task<User> AuthenticateUser(LoginDTO loginCredentials);
        Task<User> AddUser(PostUserDTO element);
        
    }
}