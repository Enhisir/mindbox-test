namespace MathLib;

public class Triangle : Figure
{
    private readonly double[] _edges;

    public Triangle(double a, double b, double c)
    {
        _edges = [a, b, c];
        if (!Validate())
            throw new ArgumentException(
                $"Стороны треуголника неверно подобраны: {_edges[0]}, {_edges[1]}, {_edges[1]}");
    }

    /// <summary>
    /// вычисляет площадь по формуле Герона.
    /// <see href="https://clck.ru/3BKara">Подробнее</see>
    /// </summary>
    public override double GetSquare()
    {
        var (a, b, c) = (_edges[0], _edges[1], _edges[1]);
        var p = _edges.Sum() / 2;

        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    public bool IsRectangular()
    {
        const double accuracy = 1e-20; // у чисел с плавающей точкой есть свойство накопительной ошибки
        var hypotenuse = _edges.Max();
        var firstCatheter = _edges.Min();
        var secondCatheter = _edges.Sum() - hypotenuse - firstCatheter;

        return Math.Abs(Math.Pow(hypotenuse, 2) - Math.Pow(firstCatheter, 2) - Math.Pow(secondCatheter, 2)) <= accuracy;
    }

    protected sealed override bool Validate()
    {
        var (a, b, c) = (_edges[0], _edges[1], _edges[1]);
        return a > 0 && b > 0 && c > 0
               && a < b + c
               && b < a + c
               && c < a + b;
    }
}