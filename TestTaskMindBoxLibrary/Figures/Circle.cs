using TestTaskMindBoxLibrary.Abstractions;

namespace TestTaskMindBoxLibrary.Figures
{
    public class Circle : Figure
    {
        public float Radius { get; set; }

        public Circle() { }

        public Circle(float radius) 
        {
            Radius = radius;
        }
        public override float CalculateArea() => 
            ((float)Math.PI) * Radius * Radius;
    }
}
