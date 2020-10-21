using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;




namespace Library.Data 
{
    public class Jwt : ILogin
    {

        private readonly IConfiguration _config;
        private readonly LibraryContext _context;
        private readonly IMapper _mapper;

        public Jwt(IConfiguration config, LibraryContext context, IMapper mapper)
        {
            _config = config;
            _context = context;
            _mapper = mapper;
        }

        [AllowAnonymous]
        public async Task<User> Login(LoginDTO login)
        {
            if (login == null) return null;
            User user = await AuthenticateUser(login);
            if (user == null) return null;
            
            var tokenString = GenerateJWTToken(user);
            
            user.JWTtoken = tokenString;
            await _context.SaveChangesAsync();
            return user;
        }


        public async Task<User> AddUser(PostUserDTO element)
        {
            var NewUser = _mapper.Map <User> (element);
            if (NewUser == null) throw new ArgumentNullException(nameof(NewUser));

            NewUser.UserRole = "User";
            NewUser.JWTtoken = null;

            _context.Users.Add(NewUser);
            await _context.SaveChangesAsync();

            return await Login(_mapper.Map <LoginDTO> (NewUser));

        }

        

        private string GenerateJWTToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Surname),
                new Claim("Name", userInfo.Name.ToString()),
                new Claim("Id_", userInfo.Id.ToString()),
                new Claim("role", userInfo.UserRole),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public async Task<User> AuthenticateUser(LoginDTO loginCredentials)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Username == loginCredentials.Username && x.Password == loginCredentials.Password);
        }

    }
}