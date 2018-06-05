using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace IFarmer.Entity
{
    // TODO : Extend seperate modelveiwe library for API req & res
    public class AuthConnectRequest
    {
        public string Username {get;set;}
        public string Password {get;set;}

    }
}