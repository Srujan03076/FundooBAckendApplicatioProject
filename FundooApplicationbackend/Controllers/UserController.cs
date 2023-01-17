﻿using Bussiness_Layer;
using CommonLayer;
using CommonLayer.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FundooApplicationbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBL userBL;
        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;
        }
        [HttpPost("Register")]
        public IActionResult Registration(Userregistration user)
        {
            try
            {
                var result = userBL.Registration(user);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Registration Successful", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Registration UnSuccessful" });
                }
            }
                    
            catch (Exception)
            {


                throw;
            }
        }
        [HttpPost("login")]

        public IActionResult login(Userlogin userLogin)
        {
            try
            {
                var result = userBL.login(userLogin);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Login Successful", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Login UnSuccessful" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("forgotpassword")]
        public IActionResult ForgetPassword(string email)
        {
            try
            {
                var result = userBL.ForgetPassword(email);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "mail sent succesfully", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Enter valid email" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut("Resetpassword")]
        public IActionResult ResetPassword(string password, string confirmpassword)
        {
            try
            {
                var email = User.FindFirst(ClaimTypes.Email).Value.ToString();
                var result = userBL.ResetPassword(email,password,confirmpassword);
                if (!result )
                {
                    return this.BadRequest(new { success = false, message = "Enter valid password" });
                }
                else
                {
                    return this.Ok(new { success = true, message = "Reset password is successful" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }



    }
}


        
