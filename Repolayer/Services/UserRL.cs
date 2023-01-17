using CommonLayer;
using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repolayer.Context;
using Repolayer.Entities;
using Repolayer.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Repolayer.Services
{
    public class UserRL : IUserRL
    {
        FundooContext context;
        IConfiguration _config;

        public UserRL(FundooContext _context, IConfiguration _config)
        {
            this.context = _context;
            this._config = _config;
        }

        public User Registration(Userregistration user)
        {
            try
            {
                User userEntity = new User();
                userEntity.FirstName = user.FirstName;
                userEntity.LastName = user.LastName;
                userEntity.Email = user.Email;
                userEntity.Password = this.EncryptPassword(user.Password);
                this.context.Add(userEntity);
                int result = context.SaveChanges();
                if (result > 0)
                    return userEntity;
                else
                    return null;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public string EncryptPassword(string password)
        {
            try
            {
                byte[] encode = new byte[password.Length];
                encode = Encoding.UTF8.GetBytes(password);
                string encryptPass = Convert.ToBase64String(encode);
                return encryptPass;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private string Decryptpass(string encryptpwd)
        {
            string decryptpwd = string.Empty;
            UTF8Encoding encodepwd = new UTF8Encoding();
            Decoder Decode = encodepwd.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encryptpwd);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            decryptpwd = new String(decoded_char);
            return decryptpwd;
        }

        public string login(Userlogin userLogin)
        {
            try
            {
                // if Email and password is empty return null. 
                if (string.IsNullOrEmpty(userLogin.EmailId) || string.IsNullOrEmpty(userLogin.Password))
                {
                    return null;
                }
                var result = context.UserTable.Where(x => x.Email == userLogin.EmailId).FirstOrDefault();
                var dcryptPass = this.Decryptpass(result.Password);
                if (result != null && dcryptPass == userLogin.Password)
                {
                    string token = GenerateSecurityToken(result.Email, result.Id);
                    return token;
                }
                else
                    return null;
            }
            catch (Exception)
            {
                throw;
            }
        }



        private string GenerateSecurityToken(string Email, long Id)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim("EmailId",Email),
                new Claim("Id",Id.ToString())
            };


            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
        _config["Jwt:Issuer"],
        claims,
        expires: DateTime.Now.AddMinutes(10),
        signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public string ForgetPassword(string email)
        {
            try
            {
                var user = context.UserTable.Where(x => x.Email == email).FirstOrDefault();
                if (user != null)
                {
                    var token = GenerateSecurityToken(user.Email, user.Id);
                    new Msmqoperation().Sender(token);
                    return token;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ResetPassword(string email, string password, string confirmpassword)
        {
            try
            {
                if (password.Equals(confirmpassword))
                {
                    var user = context.UserTable.Where(x => x.Email == email).FirstOrDefault();
                    user.Password = confirmpassword;
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
        