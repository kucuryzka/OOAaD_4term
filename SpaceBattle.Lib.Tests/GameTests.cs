using Moq;
using Xunit;

namespace SpaceBattle.Lib.Tests;

public class GameTests
{
    [Fact]
    public void ExecuteCommand_CallsCommandExecute()
    {
        var game = new Game();
        var mockCommand = new Mock<ICommand>();
        
        game.ExecuteCommand(mockCommand.Object);
        
        mockCommand.Verify(c => c.Execute(), Times.Once);
    }
}