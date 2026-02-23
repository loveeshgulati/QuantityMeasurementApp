using QuantityMeasurementApp.Model;
namespace QuantityMeasurementApp.Interfaces;

    public interface IQuantityLength
    {
        bool CheckEquality(double value1, LengthUnit unit1, double value2, LengthUnit unit2);
    }