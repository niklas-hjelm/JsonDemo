using System.Text.Json;
using JsonDemo;

var animals = new List<Animal>();

animals.Add(new Dog(){Name = "Zoe"});
animals.Add(new Cat(){Name = "Tussan"});

var json = "[";

foreach (var animal in animals)
{
    if (animal is Dog dog)
    {
        Console.WriteLine(dog.Name);
        json += JsonSerializer.Serialize(dog);
    }
    else if (animal is Cat cat)
    {
        Console.WriteLine(cat.Name);
        json += JsonSerializer.Serialize(cat);
    }

    if (animals[^1] != animal)
    {
        json += ",";
    }
}

json += "]";

Console.WriteLine(json);

var deserialisedAnimal = new List<Animal>();
using (var jsonDoc = JsonDocument.Parse(json))
{
    if (jsonDoc.RootElement.ValueKind == JsonValueKind.Array)
    {
        foreach (var jsonElement in jsonDoc.RootElement.EnumerateArray())
        {
            Animal a;
            switch (jsonElement.GetProperty("Type").GetString())
            {
                case nameof(Dog):
                    a = jsonElement.Deserialize<Dog>();
                    deserialisedAnimal.Add(a);
                    break;
                case nameof(Cat):
                    a = jsonElement.Deserialize<Cat>();
                    deserialisedAnimal.Add(a);
                    break;
            }
        }
    }

}

foreach (var animal in deserialisedAnimal)
{
    if (animal is Dog dog)
    {
        Console.WriteLine(dog.Name);
    }
    else if (animal is Cat cat)
    {
        Console.WriteLine(cat.Name);
    }
}