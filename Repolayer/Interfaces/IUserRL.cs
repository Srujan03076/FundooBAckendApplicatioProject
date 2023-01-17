using CommonLayer;
using CommonLayer.Model;
using Repolayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repolayer.Interfaces
{
   public interface IUserRL
    {
    
        public string login(Userlogin userLogin);
        public string ForgetPassword(string email);
       public bool ResetPassword(string email, string password, string confirmpassword);
       public  User Registration(Userregistration user);
    }
}
