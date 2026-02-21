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

     [TestClass]
    public class InchesEqualityTests
    {
        [TestMethod]
        public void TestInchesEquality_SameValue()
        {
            var inch1 = new QuantityMeasurementApp.Inches(1.0);
            var inch2 = new QuantityMeasurementApp.Inches(1.0);

            Assert.IsTrue(inch1.Equals(inch2));
        }

        [TestMethod]
        public void TestInchesEquality_DifferentValue()
        {
            var inch1 = new QuantityMeasurementApp.Inches(1.0);
            var inch2 = new QuantityMeasurementApp.Inches(2.0);

            Assert.IsFalse(inch1.Equals(inch2));
        }

        [TestMethod]
        public void TestInchesEquality_NullComparison()
        {
            var inch = new QuantityMeasurementApp.Inches(1.0);

            Assert.IsFalse(inch.Equals(null));
        }

        [TestMethod]
        public void TestInchesEquality_DifferentClass()
        {
            var inch = new QuantityMeasurementApp.Inches(1.0);

            Assert.IsFalse(inch.Equals("Invalid Type"));
        }

        [TestMethod]
        public void TestInchesEquality_SameReference()
        {
            var inch = new QuantityMeasurementApp.Inches(1.0);

            Assert.IsTrue(inch.Equals(inch));
        }
    }
    }
}


