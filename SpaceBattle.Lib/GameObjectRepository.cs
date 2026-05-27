using System.Collections.Generic;

namespace SpaceBattle.Lib;

public class GameObjectRepository : IGameObjectRepository
{
    private readonly Dictionary<string, object> _objects = new();

    public void Add(object obj)
    {
        var id = obj.GetType().GetProperty("Id")?.GetValue(obj)?.ToString();
        if (id != null) _objects[id] = obj;
    }

    public void Remove(object obj)
    {
        var id = obj.GetType().GetProperty("Id")?.GetValue(obj)?.ToString();
        if (id != null) _objects.Remove(id);
    }

    public object? GetById(string id)
    {
        return _objects.GetValueOrDefault(id);
    }
}