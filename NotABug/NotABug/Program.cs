using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;

var collection = new AnimalCollection();
await collection.FooAsync(
    entity => entity.Name! == "bar",
    Builders<Hamster>.Update.Set(entity => entity.Name, "foo"));

public abstract record Collection
{
}

public abstract record Collection<T> : Collection
    where T : Document
{
    public Task FooAsync<TDerived>(
        Expression<Func<TDerived, bool>> filter,
        UpdateDefinition<TDerived> updateDefinition)
        where TDerived : T =>
        throw new NotImplementedException();

    public Task FooAsync<TDerived>(
        FilterDefinition<TDerived> filterDefinition,
        UpdateDefinition<TDerived> updateDefinition)
        where TDerived : T =>
        throw new NotImplementedException();
}

public sealed record AnimalCollection : Collection<Animal>
{
}

public abstract class Document
{
}

public abstract class Animal : Document
{
}

public sealed class Hamster : Animal
{
    public string? Name { get; private set; }
}