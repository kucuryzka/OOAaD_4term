namespace SpaceBattle.Lib;

public interface IGame
{
    IGameObjectRepository Repository { get; }
    void ExecuteCommand(ICommand command);
}