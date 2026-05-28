namespace SpaceBattle.Lib;

public class Torpedo : IMovingObject, IDamagingObject
{
    public string Id { get; }
    public NVector Position { get; set; }
    public NVector Velocity { get; set; }
    public int Damage { get; }
    public bool isActive { get; set; }

    public Torpedo(string id, NVector position, NVector velocity, int damage)
    {
        Id = id;
        Position = position;
        Velocity = velocity;
        Damage = damage;
        isActive = true;
    }
}