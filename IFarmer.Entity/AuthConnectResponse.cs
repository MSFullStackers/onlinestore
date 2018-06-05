using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace IFarmer.Entity
{
    // TODO : Extend move this to modelview
    public class AuthConnectResponse
    {
        public string Error {get;set;}
        public string ErrorDescription {get;set;}
    }
}