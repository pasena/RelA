using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RelA.WebUI.Infrastructure.Abstract;
using RelA.Domain.Abstract;
using RelA.Domain.Entities;
using System.Web.Mvc;

namespace RelA.WebUI.Infrastructure
{
    public class RelAAuthentication : IAuthenticationProvider
    {
        private IUserRepository userRepository = null;
        private string authenticationSessionKey = "UserSessionKey";

        public RelAAuthentication(IUserRepository repo)
        {
            this.userRepository = repo;
        }

        bool IAuthenticationProvider.Authenticate(string userName, string password)
        {
            bool result = false;

            User authenticateUser = this.userRepository.GetAll.FirstOrDefault(w => w.Login == userName && w.Password == password);

            if (authenticateUser != null)
            {
                HttpContext.Current.Session.Add(authenticationSessionKey, authenticateUser);
                result = true;
            }

            return result;
        }
    }
}