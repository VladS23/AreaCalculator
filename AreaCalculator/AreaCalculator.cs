namespace AreaCalculator
{
    public class AreaCalculator
    {
        double DOUBLE_COMPARISON_ACCURANCY = Math.Pow(10, -12);
        public enum FigureType
        {
            Circle,
            Triangle
        }


        public double CalculateCircleArea(double radius)
        {
            if (CircleIsExist(radius))
            {
                return 2 * Math.PI * radius;
            }
            else
            {
                throw new ArgumentException("Radius must be positive");
            }
        }


        public double CalculateTriangleArea(double a, double b, double c)
        {
            if (TriangleIsExist(a, b, c))
            {
                if (TriangeIsRight(a, b, c))
                {
                    return CalculateRightTriangleArea(a, b, c);
                }
                else
                {
                    return CalculateTrianglAreaOn3Sides(a, b, c);
                }
            }
            else
            {
                throw new ArgumentException("A triangle with such sides does not exist");
            }
        }


        public double CalculateArea(double[] sides, FigureType type)
        {
            switch (type)
            {
                case FigureType.Circle:
                    if (sides.Length == 1)
                    {
                        return CalculateCircleArea(sides[0]);
                    }
                    else
                    {
                        throw new ArgumentException("Incorrect number of sides for a circle");
                    }
                case FigureType.Triangle:
                    if (sides.Length == 3)
                    {
                        return CalculateTriangleArea(sides[0], sides[1], sides[2]);
                    }
                    else
                    {
                        throw new ArgumentException("Incorrect number of sides for a triangle");
                    }
                default:
                    throw new ArgumentException("Incorrect figure type");
            }
        }


        private bool CircleIsExist(double radius)
        {
            return radius > 0;
        }
        private bool TriangleIsExist(double a, double b, double c)
        {
            if (AllTriangeSidesIsPositive(a, b, c))
            {
                double[] sides = { a, b, c };
                Array.Sort(sides);
                if (sides[0] + sides[1] > sides[2])
                {
                    return true;
                }
            }
            return false;
        }


        private bool AllTriangeSidesIsPositive(double a, double b, double c)
        {
            return a > 0 && b > 0 && c > 0;
        }
        

        private bool TriangeIsRight(double a, double b, double c)
        {
            double[] sides = { a, b, c };
            Array.Sort(sides);
            return Math.Abs(Math.Pow(sides[2], 2) - Math.Pow(sides[1], 2) - Math.Pow(sides[0], 2))<=DOUBLE_COMPARISON_ACCURANCY;
        }


        private double CalculateRightTriangleArea(double a, double b, double c)
        {
            double[] sides = { a, b, c };
            Array.Sort(sides);
            double triangleBase = sides[0];
            double TriangleHeight = sides[1];
            return (triangleBase * TriangleHeight) / 2;
        }


        private double CalculateTrianglAreaOn3Sides(double a, double b, double c)
        {
            double halfPerimetr = (a + b + c) / 2;
            return Math.Pow(halfPerimetr * (halfPerimetr - a) * (halfPerimetr - b) * (halfPerimetr - c), 0.5);
        }
    }
}