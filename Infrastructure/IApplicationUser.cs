using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreWepAPI.Model;

namespace CoreWepAPI.Infrastructure
{
    public interface IApplicationUser
    {
       //  User Create(User user, string password);
       // SaveRegisration(model);
        
        void UserLogin();
    }
}
