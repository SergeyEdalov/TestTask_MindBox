using TestTaskMindBoxLibrary.Figures;

namespace CalculateAreaTests
{
    [TestFixture]
    public class TriangleTest
    {
        Triangle _triangle;
        float _expected;

        [OneTimeSetUp]
        public void Init()
        {
            _triangle = new Triangle();

        }

        [Test]
        public async Task CalculateArea_DefaultSuccess()
        {
            //arrage
            _triangle.Sides = [3.0f, 5.0f, 7.0f];
            var halfPerimeter = (3.0f + 5.0f + 7.0f) / 2;
            _expected = (float)Math.Sqrt(halfPerimeter
            * (halfPerimeter - 3.0f)
            * (halfPerimeter - 5.0f)
            * (halfPerimeter - 7.0f));

            //act
            var actual = await Task.Run(_triangle.CalculateArea);

            //accert
            Assert.That(actual, Is.EqualTo(_expected));
        }

        [Test]
        public async Task CalculateArea_Success_RectangularTriangle()
        {
            //arrage
            _triangle.Sides = [5.0f, 3.0f, 4.0f];
            _expected = 3.0f * 4.0f / 2;

            //act
            var actual = await Task.Run(_triangle.CalculateArea);

            //accert
            Assert.That(actual, Is.EqualTo(_expected));
        }

        [Test]
        public void CalculateArea_NotSuccess_OneSideIsZero()
        {
            //arrage
            _triangle.Sides = [3.0f, 0.0f, 7.0f];

            //act
            var actual = Assert.ThrowsAsync<ArgumentException>(async () => await Task.Run(_triangle.CalculateArea));

            //accert
            Assert.That(actual.Message, Is.EqualTo("All sides must be more than zero."));
        }

        [Test]
        public void CalculateArea_NotSuccess_OneSideIsNegative()
        {
            //arrage
            _triangle.Sides = [3.0f, -5.0f, 7.0f];

            //act
            var actual = Assert.ThrowsAsync<ArgumentException>(async() => await Task.Run(_triangle.CalculateArea));

            //accert
            Assert.That(actual.Message, Is.EqualTo("All sides must be more than zero."));
        }
    }
}
