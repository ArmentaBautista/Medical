using Medical.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Domain.Users
{
    public static class UserErrors
    {
        public static Error NotFound = new Error("User.Found", "The User was not found");
        
    }
}
