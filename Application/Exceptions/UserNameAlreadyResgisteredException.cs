namespace Catalog.API.Application.Exceptions;

public class UserNameAlreadyResgisteredException : Exception
{
    public UserNameAlreadyResgisteredException(string userName) : 
           base($"UserName {userName} already exists")
    {        
    }
}
