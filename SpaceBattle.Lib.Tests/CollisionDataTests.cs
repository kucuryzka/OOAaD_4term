using Xunit;
using System.IO;
using System.Collections.Generic;

namespace SpaceBattle.Lib.Tests;

public class CollisionDataStorageTests
{
    private readonly string _testFilename = "test_collision.json";
    
    private void DeleteTestFile()
    {
        if (File.Exists(_testFilename))
            File.Delete(_testFilename);
    }

    [Fact]
    public void Save_CreatesFile()
    {
        DeleteTestFile();
        var storage = new CollisionDataStorage(_testFilename);
        var objects = new List<CollisionData>
        {
            new CollisionData("ship1", 10, 20, 30, 40),
            new CollisionData("torpedo1", 50, 60, 10, 10, "circle")
        };
        
        storage.Save(objects);
        
        Assert.True(File.Exists(_testFilename));
        
        DeleteTestFile();
    }

    [Fact]
    public void Load_ReturnsSavedData()
    {
        DeleteTestFile();
        var originalObjects = new List<CollisionData>
        {
            new CollisionData("ship1", 10, 20, 30, 40),
            new CollisionData("torpedo1", 50, 60, 10, 10, "circle")
        };
        
        var storage1 = new CollisionDataStorage(_testFilename);
        storage1.Save(originalObjects);
        
        var storage2 = new CollisionDataStorage(_testFilename);
        var loadedObjects = storage2.Load();
        
        Assert.Equal(2, loadedObjects.Count);
        Assert.Equal("ship1", loadedObjects[0].ObjId);
        Assert.Equal(10, loadedObjects[0].X);
        Assert.Equal(20, loadedObjects[0].Y);
        Assert.Equal(30, loadedObjects[0].Width);
        Assert.Equal(40, loadedObjects[0].Height);
        Assert.Equal("rectangle", loadedObjects[0].Shape);
        Assert.Equal("torpedo1", loadedObjects[1].ObjId);
        Assert.Equal(50, loadedObjects[1].X);
        Assert.Equal(60, loadedObjects[1].Y);
        Assert.Equal(10, loadedObjects[1].Width);
        Assert.Equal(10, loadedObjects[1].Height);
        Assert.Equal("circle", loadedObjects[1].Shape);
        
        DeleteTestFile();
    }

    [Fact]
    public void Load_WhenFileNotExists_ReturnsEmptyList()
    {
        DeleteTestFile();
        var storage = new CollisionDataStorage("nonexistent.json");
        
        var result = storage.Load();
        
        Assert.Empty(result);
    }

    [Fact]
    public void Load_PutsDataInMemory()
    {
        DeleteTestFile();
        var objects = new List<CollisionData>
        {
            new CollisionData("ship1", 10, 20, 30, 40)
        };
        
        var storage1 = new CollisionDataStorage(_testFilename);
        storage1.Save(objects);
        
        var storage2 = new CollisionDataStorage(_testFilename);
        storage2.Load();
        var memory = storage2.GetMemory();
        
        Assert.Single(memory);
        Assert.Equal("ship1", memory[0].ObjId);
        
        DeleteTestFile();
    }

    [Fact]
    public void SaveAndLoad_PreservesAllProperties()
    {
        DeleteTestFile();
        var originalObjects = new List<CollisionData>
        {
            new CollisionData("asteroid1", 100, 200, 50, 50, "rectangle"),
            new CollisionData("torpedo2", 300, 400, 15, 15, "circle")
        };
        
        var storage1 = new CollisionDataStorage(_testFilename);
        storage1.Save(originalObjects);
        
        var storage2 = new CollisionDataStorage(_testFilename);
        var loadedObjects = storage2.Load();
        
        Assert.Equal(originalObjects.Count, loadedObjects.Count);
        for (int i = 0; i < originalObjects.Count; i++)
        {
            Assert.Equal(originalObjects[i].ObjId, loadedObjects[i].ObjId);
            Assert.Equal(originalObjects[i].X, loadedObjects[i].X);
            Assert.Equal(originalObjects[i].Y, loadedObjects[i].Y);
            Assert.Equal(originalObjects[i].Width, loadedObjects[i].Width);
            Assert.Equal(originalObjects[i].Height, loadedObjects[i].Height);
            Assert.Equal(originalObjects[i].Shape, loadedObjects[i].Shape);
        }
        
        DeleteTestFile();
    }
}