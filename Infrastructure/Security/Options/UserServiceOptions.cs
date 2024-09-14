using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Infrastructure.Security.Options;

public class UserServiceOptions
{
    public string SecretKey { get; set; }
}
