using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Application.Exceptions;

public class UserNameAlreadyResgisteredException : Exception
{
    public UserNameAlreadyResgisteredException(string userName) : 
           base($"UserName {userName} already exists")
    {        
    }
}
