namespace SpaceBattle.Lib;

public interface IDamagingObject
{
    
    int Damage { get; }
    bool isActive { get; set; }
}