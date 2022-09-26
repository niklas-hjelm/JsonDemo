namespace JsonDemo;

public class Cat : Animal
{
    public override string Type { get; } = nameof(Cat);
    public string Name { get; set; }
}