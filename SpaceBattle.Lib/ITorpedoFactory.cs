namespace SpaceBattle.Lib;

public interface ITorpedoFactory
{
    Torpedo CreateTorpedo(NVector position, NVector velocity, int damage);
}