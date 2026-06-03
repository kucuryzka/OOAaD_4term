namespace SpaceBattle.Lib;

public class TorpedoFactory : ITorpedoFactory
{
    private readonly IGameObjectRepository _repository;

    public TorpedoFactory(IGameObjectRepository repository)
    {
        _repository = repository;
    }

    public Torpedo CreateTorpedo(NVector position, NVector velocity, int damage)
    {
        var torpedoId = Guid.NewGuid().ToString();
        var torpedo = new Torpedo(torpedoId, position, velocity, damage);
        
        _repository.Add(torpedo);
        
        return torpedo;
    }
}
