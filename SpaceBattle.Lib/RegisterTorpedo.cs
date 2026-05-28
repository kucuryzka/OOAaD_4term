
using App;
using App.Scopes;
namespace SpaceBattle.Lib;

public class RegisterTorpedoDependencies : ICommand
{
    public void Execute()
    {
        Ioc.Resolve<App.ICommand>(
            "IoC.Register",
            "Torpedo.Factory",
            (object[] args) =>
            {
                var game = Ioc.Resolve<IGame>("Game");
                return new TorpedoFactory(game.Repository);
            }
        ).Execute();

        Ioc.Resolve<App.ICommand>(
            "IoC.Register",
            "Commands.FireTorpedo",
            (object[] args) =>
            {
                var ship = (IMovingObject)args[0];
                var rotation = (IRotatingObject)args[1];
                var factory = Ioc.Resolve<ITorpedoFactory>("Torpedo.Factory");
                
                return new FireTorpedoCommand(ship, rotation, factory);
            }
        ).Execute();
    }
}