
namespace QuantityMeasurementApp{
 public class Feet
        {
            private readonly double value;
            public Feet(double value)
            {
                this.value = value;
            }

            public double Value
            {
                get { return value; }
            }

            public override bool Equals(object obj)
            {
            
                if (ReferenceEquals(this, obj))
                    return true;

                if (obj == null)
                    return false;


                if (this.GetType() != obj.GetType())
                    return false;

                Feet other = (Feet)obj;

                return double.Equals(this.value, other.value);
            }

            public override int GetHashCode()
            {
                return value.GetHashCode();
            }
        }
 }