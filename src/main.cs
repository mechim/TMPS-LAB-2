using System;
using System.Collections.Generic;

// Singleton Pattern
public sealed class ShapeManager
{
    private static ShapeManager _instance = null;
    private List<Shape> shapes = new List<Shape>();

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

    public void AddShape(Shape shape)
    {
        shapes.Add(shape);
    }

    public void ListShapes()
    {
        foreach (var shape in shapes)
        {
            Console.WriteLine(shape);
        }
    }
}

public abstract class Shape
{
    public string Name { get; set; }
    public string Color { get; set; }
    public int Size { get; set; }

    public Shape(string name)
    {
        Name = name;
    }
}

// Builder Pattern
public class ShapeBuilder
{
    private string name;
    private string color;
    private int size;

    public ShapeBuilder(string name)
    {
        this.name = name;
    }

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

    public Shape Build()
    {
        return new ConcreteShape(name, color, size);
    }
}

// Prototype Pattern
public class Circle : Shape
{
    public int Radius { get; set; }

    public Circle(string name, int radius) : base(name)
    {
        Radius = radius;
    }

    public Circle Clone()
    {
        return new Circle(Name, Radius) { Color = this.Color, Size = this.Size };
    }

    public override string ToString()
    {
        return $"Circle(Name: {Name}, Radius: {Radius}, Color: {Color}, Size: {Size})";
    }
}

// Concrete Shape
public class ConcreteShape : Shape
{
    public ConcreteShape(string name, string color, int size) : base(name)
    {
        Color = color;
        Size = size;
    }

    public override string ToString()
    {
        return $"ConcreteShape(Name: {Name}, Color: {Color}, Size: {Size})";
    }
}

// Factory Method Pattern
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

class Program
{
    static void Main(string[] args)
    {
        // Singleton Pattern
        var manager = ShapeManager.Instance;

        // Builder Pattern
        var circle = new ShapeBuilder("Circle")
            .SetColor("Red")
            .SetSize(5)
            .Build();

        // Prototype Pattern
        var circlePrototype = new Circle("Circle", 5);
        var newCircle = circlePrototype.Clone();

        // Factory Method Pattern
        ShapeFactory circleFactory = new CircleFactory();
        var newCircle2 = circleFactory.CreateShape("New Circle");

        manager.AddShape(circle);
        manager.AddShape(newCircle);
        manager.AddShape(newCircle2);

        manager.ListShapes();

    }
}

