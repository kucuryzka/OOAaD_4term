namespace SpaceBattle.Lib;

public interface IGameObjectRepository
{
    void Add(object obj);
    void Remove(object obj);
    object? GetById(string id);
}