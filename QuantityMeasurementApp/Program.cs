 public class Program
    {
        static void Main(string[] args)
        {
            QuantityMeasurementApp.Feet feet1 = new QuantityMeasurementApp.Feet(1.0);

            QuantityMeasurementApp.Feet feet2 = new QuantityMeasurementApp.Feet(1.0);

            bool result = feet1.Equals(feet2);

            Console.WriteLine("Feet Measurement Equality Check");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Input: 1.0 ft and 1.0 ft");
            Console.WriteLine($"Output: Equal ({result})");

            Console.ReadLine();
        }
    }