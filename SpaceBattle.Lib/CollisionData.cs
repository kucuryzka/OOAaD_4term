using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace SpaceBattle.Lib;

public class CollisionData
{
    public string ObjId { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public string Shape { get; set; }

    public CollisionData(string objId, int x, int y, int width, int height, string shape = "rectangle")
    {
        ObjId = objId;
        X = x;
        Y = y;
        Width = width;
        Height = height;
        Shape = shape;
    }
}

public class CollisionDataStorage
{
    private readonly string _filename;
    private List<CollisionData> _memory;

    public CollisionDataStorage(string filename = "collision_data.json")
    {
        _filename = filename;
        _memory = new List<CollisionData>();
    }

    // Сохранение в файл
    public void Save(List<CollisionData> objects)
    {
        var json = JsonSerializer.Serialize(objects, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filename, json);
    }

    // Загрузка в память
    public List<CollisionData> Load()
    {
        try
        {
            var json = File.ReadAllText(_filename);
            _memory = JsonSerializer.Deserialize<List<CollisionData>>(json) ?? new List<CollisionData>();
            return _memory;
        }
        catch (FileNotFoundException)
        {
            return new List<CollisionData>();
        }
    }

    // Получить данные из памяти
    public List<CollisionData> GetMemory()
    {
        return _memory;
    }
}