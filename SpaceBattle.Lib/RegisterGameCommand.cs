using App;
using App.Scopes;

namespace SpaceBattle.Lib;

public class RegisterGameCommand : ICommand
{
    public void Execute()
    {
        Ioc.Resolve<App.ICommand>(
            "IoC.Register",
            "Game",
            (object[] args) => new Game()
        ).Execute();
    }
}Pymupdf