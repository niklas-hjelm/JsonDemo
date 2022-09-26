namespace JsonDemo;

public class Dog : Animal
{
    public override string Type { get; } = nameof(Dog);

    public string Name { get; set; }
}