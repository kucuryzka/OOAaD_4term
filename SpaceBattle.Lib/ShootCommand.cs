namespace SpaceBattle.Lib;

public class FireTorpedoCommand : ICommand
{
    private readonly IMovingObject _ship;
    private readonly IRotatingObject _shipRotation;
    private readonly ITorpedoFactory _torpedoFactory;

    public FireTorpedoCommand(
        IMovingObject ship,
        IRotatingObject shipRotation,
        ITorpedoFactory torpedoFactory)
    {
        _ship = ship;
        _shipRotation = shipRotation;
        _torpedoFactory = torpedoFactory;
    }

    public void Execute()
    {
        var direction = AngleToVector(_shipRotation.Angle);
        
        _torpedoFactory.CreateTorpedo(
            _ship.Position,
            direction,
            damage: 100
        );
    }

    private NVector AngleToVector(Angle angle)
    {
        throw new NotImplementedException();
    }
}
