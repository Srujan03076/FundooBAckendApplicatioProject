using CommonLayer;
using CommonLayer.Model;
using Repolayer.Entities;
using Repolayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness_Layer.Services
{
    public class UserBL : IUserBL

    {
        private readonly IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }

        public string ForgetPassword(string email)
        {
            try
            {
                return userRL.ForgetPassword(email);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string login(Userlogin userLogin)
        {
            try
            {
                return userRL.login(userLogin);
            }
            catch (Exception)
            {
                throw;
            }
        }

            public User Registration(Userregistration user)
        {
            try
            {
                return this.userRL.Registration(user);
            }
            catch (Exception)
            {

                throw;
            }
        }

       

       
        

        public bool ResetPassword(ResetPassword reset, string email)
        {
            try
            {
                return this.userRL.ResetPassword(reset,  email);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
