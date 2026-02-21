namespace QuantityMeasurementAppTests
{
    [TestClass]
    public class QuantityMeasurementAppTests
    {
        [TestMethod]
        public void TestFeetEquality_SameValue()
        {
            var f1 = new QuantityMeasurementApp.Feet(1.0);
            var f2 = new QuantityMeasurementApp.Feet(1.0);

            Assert.IsTrue(f1.Equals(f2));
        }

        [TestMethod]
        public void TestFeetEquality_DifferentValue()
        {
            var f1 = new QuantityMeasurementApp.Feet(1.0);
            var f2 = new QuantityMeasurementApp.Feet(2.0);

            Assert.IsFalse(f1.Equals(f2));
        }

        [TestMethod]
        public void TestFeetEquality_NullComparison()
        {
            var f1 = new QuantityMeasurementApp.Feet(1.0);

            Assert.IsFalse(f1.Equals(null));
        }

        [TestMethod]
        public void TestFeetEquality_DifferentClass()
        {
            var f1 = new QuantityMeasurementApp.Feet(1.0);

            Assert.IsFalse(f1.Equals("Invalid"));
        }

        [TestMethod]
        public void TestFeetEquality_SameReference()
        {
            var f1 = new QuantityMeasurementApp.Feet(1.0);

            Assert.IsTrue(f1.Equals(f1));
        }
    }
}


