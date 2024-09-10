using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Application.Contracts;

namespace Catalog.API.Abstractions;

public abstract class Entity<TId> : IEntity<TId>
{
    public TId Id { get; set; }
}
