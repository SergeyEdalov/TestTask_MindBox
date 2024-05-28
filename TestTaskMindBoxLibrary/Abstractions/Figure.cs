namespace TestTaskMindBoxLibrary.Abstractions
{
    public abstract class Figure : ICalculateArea<float>
    {
        public abstract float CalculateArea();
    }
}
