# Design Patterns Implementation Report

In this report, we will analyze how various design patterns have been implemented in the codebase. The codebase is a C# console application for managing different shapes with different properties. The implemented design patterns include Singleton, Builder, Prototype, and Factory Method.

## Singleton Pattern

### Implementation
The Singleton pattern ensures that there is only one instance of the `ShapeManager` class throughout the application's lifetime.

```csharp
public sealed class ShapeManager
{
    private static ShapeManager _instance = null;

    // Private constructor to prevent external instantiation
    private ShapeManager() { }

    public static ShapeManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ShapeManager();
            }
            return _instance;
        }
    }

    // Other methods for managing shapes...
}
```

## Usage
```csharp
var manager = ShapeManager.Instance;
```
## Builder Pattern
### Implementation
The Builder pattern is used to construct complex `Shape` objects step by step using the `ShapeBuilder` class.
```csharp
public class ShapeBuilder
{
    // Private fields to store shape properties
    private string name;
    private string color;
    private int size;

    // Constructor sets the initial shape name
    public ShapeBuilder(string name)
    {
        this.name = name;
    }

    // Methods to set optional properties
    public ShapeBuilder SetColor(string color)
    {
        this.color = color;
        return this;
    }

    public ShapeBuilder SetSize(int size)
    {
        this.size = size;
        return this;
    }

    // Build method creates a concrete Shape instance
    public Shape Build()
    {
        return new ConcreteShape(name, color, size);
    }
}
```
### Usage
```chsarp
var circle = new ShapeBuilder("Circle")
    .SetColor("Red")
    .SetSize(5)
    .Build();
```
## Prototype Pattern
### Implementation
The Prototype pattern is used to create new shape objects by cloning existing ones. It is implemented in the `Circle` class.
```chsarp
public class Circle : Shape
{
    // Properties specific to Circle
    public int Radius { get; set; }

    public Circle(string name, int radius) : base(name)
    {
        Radius = radius;
    }

    // Clone method creates a new Circle instance with the same properties
    public Circle Clone()
    {
        return new Circle(Name, Radius) { Color = this.Color, Size = this.Size };
    }
}
```
### Usage
```csharp
var circlePrototype = new Circle("Circle", 5);
var newCircle = circlePrototype.Clone();
```
## Factory Method
### Implementation
The Factory Method pattern is used to create shape objects without specifying their concrete classes. It is implemented using an abstract `ShapeFactory` class and a `CircleFactory` subclass.
```csharp
public abstract class ShapeFactory
{
    public abstract Shape CreateShape(string name);
}

public class CircleFactory : ShapeFactory
{
    public override Shape CreateShape(string name)
    {
        return new Circle(name, 0);
    }
}
```
### Usage
```csharp
ShapeFactory circleFactory = new CircleFactory();
var newCircle2 = circleFactory.CreateShape("New Circle");
```
## Conclusion
In this console application, we have successfully implemented the Singleton, Builder, Prototype, and Factory Method design patterns to manage different shapes efficiently. These design patterns promote code reusability, maintainability, and flexibility, making it easier to extend and maintain the application as requirements evolve.
