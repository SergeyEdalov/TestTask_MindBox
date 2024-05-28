using TestTaskMindBoxLibrary.Figures;

namespace CalculateAreaTests
{
    [TestFixture]
    public class CircleTest
    {
        Circle _circle;
        float _expected;

        [OneTimeSetUp]
        public void Init()
        {
            _circle = new Circle();
        }
        [Test]
        public async Task CalculateArea_DefaultSuccess()
        {
            //arrage
            _expected = (float)Math.PI * 2.0f * 2.0f;
            _circle.Radius = 2.0f;

            //act
            var actual = await Task.Run(_circle.CalculateArea);

            //accert
            Assert.That(actual, Is.EqualTo(_expected));
        }

        [Test]
        public async Task CalculateArea_NotSuccess_AreaMoreThanExpected()
        {
            //arrage
            _expected = (float)Math.PI * 2.0f * 2.0f;
            _circle.Radius = 3.0f;

            //act
            var actual = await Task.Run(_circle.CalculateArea);

            //accert
            Assert.That(actual > _expected);
        }

        [Test]
        public async Task CalculateArea_NotSuccess_AreaLessThanExpected()
        {
            //arrage
            _expected = (float)Math.PI * 2.0f * 2.0f;
            _circle.Radius = 1.0f;

            //act
            var actual = await Task.Run(_circle.CalculateArea);

            //accert
            Assert.That(actual < _expected);
        }

        [Test]
        public async Task CalculateArea_Success_NegativeRadius()
        {
            //arrage
            _expected = (float)Math.PI * -2.0f * -2.0f;
            _circle.Radius = -2.0f;

            //act
            var actual = await Task.Run(_circle.CalculateArea);

            //accert
            Assert.That(actual, Is.EqualTo(_expected));
        }

        [Test]
        public async Task CalculateArea_NotSuccess_NullableRadius()
        {
            //arrage
            _expected = (float)Math.PI * 0.0f * 0.0f;
            _circle.Radius = 0.0f;

            //act
            var actual = await Task.Run(_circle.CalculateArea);

            //accert
            Assert.That(actual, Is.EqualTo(_expected));
        }
    }
}
