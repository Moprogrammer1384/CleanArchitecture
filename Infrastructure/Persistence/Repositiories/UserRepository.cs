using Catalog.API.Application.Contract;
using Catalog.API.Models;


namespace Catalog.API.Infrastructure.Persistence.Repositiories;

public class UserRepository : SqlRepository<User, int>, IUserRepository
{
    public UserRepository(CatalogContext context) : base(context)
    {
        
    }

    
}
