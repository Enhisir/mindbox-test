namespace MathLib;

public class Circle : Figure
{
    public double Radius { get; }

    public Circle(double radius)
    {
        Radius = radius;
        if (!Validate())
            throw new ArgumentException($"Недопустимый радиус круга: {Radius}");
    }
    
    protected sealed override bool Validate()
    {
        return Radius > 0;
    }

    public override double Square => double.Pi * Radius * Radius;
}