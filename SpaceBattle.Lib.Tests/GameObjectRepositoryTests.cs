using Xunit;

namespace SpaceBattle.Lib.Tests;

public class GameObjectRepositoryTests
{
    private class TestObject
    {
        public string Id { get; set; }
        
        public TestObject(string id)
        {
            Id = id;
        }
    }

    [Fact]
    public void AddAndGetById_ReturnsObject()
    {
        var repo = new GameObjectRepository();
        var obj = new TestObject("1");  
        repo.Add(obj);

        var result = repo.GetById("1");
        
        Assert.Equal(obj, result);
    }

    [Fact]
    public void Remove_RemovesObject()
    {
        var repo = new GameObjectRepository();
        var obj = new TestObject("1");  
        repo.Add(obj);
        repo.Remove(obj);

        var result = repo.GetById("1");
        
        Assert.Null(result);
    }
}