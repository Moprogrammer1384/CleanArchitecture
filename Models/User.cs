
using Catalog.API.Abstractions;

namespace Catalog.API.Models;

public class User : Entity<int>
{
    public string FullName { get; set; }        
    public string Email { get; set; }
    public string UserName { get; set; }       
    public string Password { get; set; }        
}
