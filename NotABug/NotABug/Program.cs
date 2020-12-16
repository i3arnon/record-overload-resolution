using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;

var collection = new HamsterCollection();
await collection.FooAsync(
    _ => true,
    Builders<Hamster>.Update.Set(entity => entity.Name, "bar"));

public abstract record Collection
{
}

public abstract record Collection<T> : Collection
    where T : Document
{
    public async Task FooAsync<TDerived>(
        Expression<Func<TDerived, bool>> filter,
        UpdateDefinition<TDerived> updateDefinition)
        where TDerived : T =>
        throw new NotImplementedException();

    public async Task FooAsync<TDerived>(
        FilterDefinition<TDerived> filterDefinition,
        UpdateDefinition<TDerived> updateDefinition)
        where TDerived : T =>
        throw new NotImplementedException();
}

public sealed record HamsterCollection : Collection<Hamster>
{
}

public abstract class Document
{
}

public sealed class Hamster : Document
{
    public string Name { get; private set; }
}
