using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RelA.WebUI.Infrastructure.Abstract
{
    public interface IAuthenticationProvider
    {
        bool Authenticate(string userName, string password);
    }
}