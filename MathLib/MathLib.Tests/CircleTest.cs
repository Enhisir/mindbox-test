namespace MathLib.Tests;

public class CircleTest
{
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void InvalidCircle_ReturnsFailure(double r)
        => Assert.Throws<ArgumentException>(() => new Circle(r));

    [Theory]
    [InlineData(1)]
    [InlineData(double.Pi)]
    public void ValidCircle_ReturnsSuccess(double r)
    {
        _ = new Circle(r);
    }

    [Theory]
    [InlineData(1, double.Pi)]
    [InlineData(3.14, double.Pi * 3.14 * 3.14)]
    public void Square_ReturnsCorrectAnswer(double r, double correctAnswer)
    {
        const double accuracy = 1e-2;

        var circle = new Circle(r);
        var actualAnswer = circle.Square;
        
        Assert.Equal(correctAnswer, actualAnswer, accuracy);
    }
}