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
        var halfPerimeter = (Sides[0] + Sides[1] + Sides[2]) / 2;
        if (isRectangular())
        {
            return (halfPerimeter - Sides[0])
                * halfPerimeter - Sides[1];
        }
        return (float)Math.Sqrt(halfPerimeter
            * (halfPerimeter - Sides[0])
            * (halfPerimeter - Sides[1])
            * (halfPerimeter - Sides[2]));
    }

    private bool isRectangular()
    {
        Array.Sort(Sides);

        return Math.Pow(Sides[2], 2) ==
            Math.Pow(Sides[0], 2) + Math.Pow(Sides[1], 2) ? true : false;
    }
}

