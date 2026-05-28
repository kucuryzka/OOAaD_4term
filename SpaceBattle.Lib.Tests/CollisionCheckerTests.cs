using System.Windows.Input;
using App;
using App.Scopes;
using Moq;
using SpaceBattle.Lib;
namespace SpaceBattle.Lib.Tests;


public class CollisionCheckerTests
{
    [Fact]
    public void TrajectoriesCross_HaveCollided_ReturnsTrue()
    {
        var obj1 = new Mock<IMovingObject>();
        obj1.SetupGet(o => o.Position).Returns(new NVector(new int[] { 0, 0 }));
        obj1.SetupGet(o => o.Velocity).Returns(new NVector(new int[] { 2, 2 }));

        var obj2 = new Mock<IMovingObject>();
        obj2.SetupGet(o => o.Position).Returns(new NVector(new int[] { 2, 0 }));
        obj2.SetupGet(o => o.Velocity).Returns(new NVector(new int[] { -2, 2 }));

        var checker = new CollisionChecker();

        Assert.True(checker.HaveCollided(obj1.Object, obj2.Object));
    }

    [Fact]
    public void TrajectoriesDoNotCross_HaveCollided_ReturnsFalse()
    {
        var obj1 = new Mock<IMovingObject>();
        obj1.SetupGet(o => o.Position).Returns(new NVector(new int[] { 0, 0 }));
        obj1.SetupGet(o => o.Velocity).Returns(new NVector(new int[] { 1, 0 }));

        var obj2 = new Mock<IMovingObject>();
        obj2.SetupGet(o => o.Position).Returns(new NVector(new int[] { 0, 1 }));
        obj2.SetupGet(o => o.Velocity).Returns(new NVector(new int[] { 1, 0 }));

        var checker = new CollisionChecker();

        Assert.False(checker.HaveCollided(obj1.Object, obj2.Object));
    }

    [Fact]
    public void ParallelTrajectories_HaveCollided_ReturnsFalse()
    {
        var obj1 = new Mock<IMovingObject>();
        obj1.SetupGet(o => o.Position).Returns(new NVector(new int[] { 0, 0 }));
        obj1.SetupGet(o => o.Velocity).Returns(new NVector(new int[] { 1, 0 }));

        var obj2 = new Mock<IMovingObject>();
        obj2.SetupGet(o => o.Position).Returns(new NVector(new int[] { 0, 1 }));
        obj2.SetupGet(o => o.Velocity).Returns(new NVector(new int[] { 1, 0 }));

        var checker = new CollisionChecker();

        Assert.False(checker.HaveCollided(obj1.Object, obj2.Object));
    }
}