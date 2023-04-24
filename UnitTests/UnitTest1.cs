using System;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        double COMPRASSION_ACCURANCY = Math.Pow(10, -12);
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4.00001)]
        [InlineData(0.001)]
        [InlineData(1000000000000)]
        public void CircleTest(double radius)
        {
            AreaCalculator.AreaCalculator ac = new AreaCalculator.AreaCalculator();
            double expected = 2 * Math.PI * radius;
            double actual = ac.CalculateCircleArea(radius);
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-10000)]
        [InlineData(-0.001)]
        [InlineData(-4.0001)]
        public void NotExistCircleTest(double radius)
        {
            AreaCalculator.AreaCalculator ac = new AreaCalculator.AreaCalculator();
            Assert.Throws<ArgumentException>(() => ac.CalculateCircleArea(radius));
        }
        [Theory]
        [InlineData(3, 4, 5, 6)]
        [InlineData(3.003, 4.004, 5.005, 6.012006)]
        [InlineData(6, 8, 10, 24)]
        [InlineData(65, 72, 97, 2340)]
        public void RightTriangleCalculatingTest(double a, double b, double c, double expected)
        {
            AreaCalculator.AreaCalculator ac = new AreaCalculator.AreaCalculator();
            double actual = ac.CalculateTriangleArea(a, b, c);
            bool sufficientAccurancy = Math.Abs(actual - expected) < COMPRASSION_ACCURANCY;
            Assert.True(sufficientAccurancy);
        }
        [Theory]
        [InlineData(2, 2, 3, 1.984313483298443)]
        [InlineData(1, 1, 1, 0.4330127018922193)]
        [InlineData(2, 2, 2, 1.7320508075688772)]
        [InlineData(5, 7, 10, 16.24807680927192)]
        [InlineData(7, 5, 10, 16.24807680927192)]
        public void TriangleCalculatingTest(double a, double b, double c, double expected)
        {
            AreaCalculator.AreaCalculator ac = new AreaCalculator.AreaCalculator();
            double actual = ac.CalculateTriangleArea(a, b, c);
            bool sufficientAccurancy = Math.Abs(actual - expected) < COMPRASSION_ACCURANCY;
            Assert.True(sufficientAccurancy);
        }
        [Theory]
        [InlineData(2, 2, 5)]
        [InlineData(2, 5, 2)]
        [InlineData(5, 2, 2)]
        [InlineData(20, 10, 9)]
        public void NotExistTriangleTest(double a, double b, double c)
        {
            AreaCalculator.AreaCalculator ac = new AreaCalculator.AreaCalculator();
            Assert.Throws<ArgumentException>(() => ac.CalculateTriangleArea(a, b, c));
        }
        [Theory]
        [InlineData(-3, -7, -9)]
        [InlineData(-1, -1, -1)]
        [InlineData(-1, 1, 1)]
        [InlineData(1, -1, 1)]
        [InlineData(1, 1, -1)]
        [InlineData(0, 0, 0)]
        [InlineData(0, 1, 1)]
        [InlineData(1, 0, 1)]
        [InlineData(1, 1, 0)]
        [InlineData(-1, -1, 0)]
        public void NotPositiveSidesTriangleTest(double a, double b, double c)
        {
            AreaCalculator.AreaCalculator ac = new AreaCalculator.AreaCalculator();
            Assert.Throws<ArgumentException>(() => ac.CalculateTriangleArea(a, b, c));
        }
        [Theory]
        [InlineData(new double[1] { 3 }, AreaCalculator.AreaCalculator.FigureType.Circle, 2 * Math.PI * 3)]
        [InlineData(new double[1] { 4.00001 }, AreaCalculator.AreaCalculator.FigureType.Circle, 2 * Math.PI * 4.00001)]
        [InlineData(new double[1] { 0.001 }, AreaCalculator.AreaCalculator.FigureType.Circle, 2 * Math.PI * 0.001)]
        [InlineData(new double[3] { 3, 4, 5 }, AreaCalculator.AreaCalculator.FigureType.Triangle, 6)]
        [InlineData(new double[3] { 3.003, 4.004, 5.005 }, AreaCalculator.AreaCalculator.FigureType.Triangle, 6.012006)]
        [InlineData(new double[3] { 2, 2, 2 }, AreaCalculator.AreaCalculator.FigureType.Triangle, 1.7320508075688772)]
        [InlineData(new double[3] { 5, 7, 10  }, AreaCalculator.AreaCalculator.FigureType.Triangle, 16.24807680927192)]
        public void CorrectRunTimeFigureTypeAreaTest(double[] sides, AreaCalculator.AreaCalculator.FigureType type, double expected)
        {
            AreaCalculator.AreaCalculator ac = new AreaCalculator.AreaCalculator();
            double actual = ac.CalculateArea(sides, type);
            bool sufficientAccurancy = Math.Abs(actual - expected) < COMPRASSION_ACCURANCY;
            Assert.True(sufficientAccurancy);
        }
        [Theory]
        [InlineData(new double[0] {}, AreaCalculator.AreaCalculator.FigureType.Circle)]
        [InlineData(new double[2] { 1, 1 }, AreaCalculator.AreaCalculator.FigureType.Circle)]
        [InlineData(new double[3] { 1, 1, 1}, AreaCalculator.AreaCalculator.FigureType.Circle)]
        [InlineData(new double[2] { 1, 1 }, AreaCalculator.AreaCalculator.FigureType.Triangle)]
        [InlineData(new double[4] { 1, 1, 1, 1 }, AreaCalculator.AreaCalculator.FigureType.Triangle)]
        public void UnCorrectRunTimeFigureTypeAreaTest(double[] sides, AreaCalculator.AreaCalculator.FigureType type)
        {
            AreaCalculator.AreaCalculator ac = new AreaCalculator.AreaCalculator();
            Assert.Throws<ArgumentException>(() => ac.CalculateArea(sides, type));
        }
    }
}