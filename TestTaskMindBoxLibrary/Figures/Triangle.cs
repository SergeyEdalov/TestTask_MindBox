using TestTaskMindBoxLibrary.Abstractions;

namespace TestTaskMindBoxLibrary.Figures;

public class Triangle : Figure
{
    public float[] Sides = new float[3];

    public Triangle() { }

    public Triangle(float[] sides)
    {
        Sides = sides;
    }
    public override float CalculateArea()
    {
        if (CheckSides()) { throw new ArgumentException("All sides must be more than zero."); }
        if (isRectangular())
        {
            return Sides[0] * Sides[1] / 2;
        }
        var halfPerimeter = (Sides[0] + Sides[1] + Sides[2]) / 2;
        return (float)Math.Sqrt(halfPerimeter
            * (halfPerimeter - Sides[0])
            * (halfPerimeter - Sides[1])
            * (halfPerimeter - Sides[2]));
    }

    private bool isRectangular()
    {
        float[] copyArraySides = new float[3];

        Array.Copy(Sides, copyArraySides, 3);
        Array.Sort(copyArraySides);

        if (Math.Pow(copyArraySides[2], 2) ==
            Math.Pow(copyArraySides[0], 2) + Math.Pow(copyArraySides[1], 2))
        {
            Array.Copy(copyArraySides, Sides, 3);
            return true;
        }
        return false;
    }

    private bool CheckSides()
    {
        var res = Sides.Any(x => x <= 0);
        return res;
    }
        
}

