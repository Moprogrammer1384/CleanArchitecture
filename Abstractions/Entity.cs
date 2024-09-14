using Catalog.API.Application.Contracts;

namespace Catalog.API.Abstractions;

public abstract class Entity<TId> : IEntity<TId>
{
    public TId Id { get; set; }
}
