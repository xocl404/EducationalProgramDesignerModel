namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Repository<TEntity>
{
    private readonly Dictionary<int, TEntity> _entities = new();

    public void Add(TEntity entity, int id)
    {
        _entities.TryAdd(id, entity);
    }

    public void Remove(int id)
    {
        if (!_entities.ContainsKey(id))
        {
            throw new KeyNotFoundException("Entity not found");
        }

        _entities.Remove(id);
    }

    public TEntity Get(int id)
    {
        if (!_entities.ContainsKey(id))
        {
            throw new KeyNotFoundException("Entity not found");
        }

        return _entities[id];
    }
}