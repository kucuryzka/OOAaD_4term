namespace SpaceBattle.Lib;

public class Game : IGame
{
    public IGameObjectRepository Repository { get; } = new GameObjectRepository();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
    }
}