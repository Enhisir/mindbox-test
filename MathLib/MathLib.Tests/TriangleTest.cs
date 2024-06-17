namespace MathLib.Tests;

public class TriangleTest
{
    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(0, 1, 1)]
    [InlineData(1, 0, 1)]
    [InlineData(1, 1, 0)]
    [InlineData(-1, 1, 1)]
    [InlineData(1, -1, 1)]
    [InlineData(1, 1, -1)]
    [InlineData(2, 1, 1)]
    [InlineData(1, 2, 1)]
    [InlineData(1, 1, 2)]
    public void InvalidTriangle_ReturnsFailure(double a, double b, double c)
        => Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));

    [Theory]
    [InlineData(1, 1, 1)]
    [InlineData(7, 13, 16)]
    [InlineData(11, 8, 12)]
    [InlineData(3, 5, 4)]
    public void ValidTriangle_ReturnsSuccess(double a, double b, double c)
    {
        _ = new Triangle(a, b, c);
    }
    
    [Theory]
    [InlineData(1, 1, 1)]
    [InlineData(7, 13, 16)]
    [InlineData(11, 8, 12)]
    public void IsRectangular_NonRectangularTriangle_ReturnsFalse(double a, double b, double c)
    {
        var triangle = new Triangle(a, b, c);
        
        Assert.False(triangle.IsRectangular());
    }
    
    [Theory]
    [InlineData(3, 5, 4)]
    public void IsRectangular_NonRectangularTriangle_ReturnsTrue(double a, double b, double c)
    {
        var triangle = new Triangle(a, b, c);
        
        Assert.True(triangle.IsRectangular());
    }

    [Theory]
    [InlineData(1, 1, 1,  0.4330127018922193)]
    [InlineData(3, 5, 4,  6)]
    public void Square_ReturnsCorrectAnswer(double a, double b, double c, double correctAnswer)
    {
        const double accuracy = 1e-20;
        
        var triangle = new Triangle(a, b, c);
        
        Assert.Equal(correctAnswer, triangle.Square, accuracy);
    }
}