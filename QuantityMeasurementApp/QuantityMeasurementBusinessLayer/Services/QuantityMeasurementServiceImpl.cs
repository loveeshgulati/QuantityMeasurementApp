using QuantityMeasurementBusinessLayer.Interfaces;
using QuantityMeasurementModelLayer.DTO;
using QuantityMeasurementModelLayer.Entities;
using QuantityMeasurementRepositoryLayer.Interfaces;
using QuantityMeasurementApp.Model;
using QuantityMeasurementModelLayer.Enums;
using QuantityMeasurementModelLayer.Exceptions;
using System.Collections.Generic;

namespace QuantityMeasurementBusinessLayer.Services
{
    public class QuantityMeasurementServiceImpl : IQuantityMeasurementService
    {
        private readonly IQuantityMeasurementRepository _repository;

        public QuantityMeasurementServiceImpl(IQuantityMeasurementRepository repository)
        {
            _repository = repository;
        }


        public double CompareQuantities(QuantityDTO thisQuantity, QuantityDTO thatQuantity)
        {
            if (thisQuantity.MeasurementType != thatQuantity.MeasurementType)
                throw new Exception("Cannot compare different measurement types");

            bool result;

            switch (thisQuantity.MeasurementType.ToUpper())
            {
                case "LENGTH":

                    LengthUnit lengthUnit1 = Enum.Parse<LengthUnit>(thisQuantity.Unit, true);
                    LengthUnit lengthUnit2 = Enum.Parse<LengthUnit>(thatQuantity.Unit, true);

                    QuantityLength lengthq1 = new QuantityLength(thisQuantity.Value, lengthUnit1);
                    QuantityLength lengthq2 = new QuantityLength(thatQuantity.Value, lengthUnit2);

                    result = lengthq1.Equals(lengthq2);

                    break;
                case "VOLUME":

                    VolumeUnit volumeUnit1 = Enum.Parse<VolumeUnit>(thisQuantity.Unit, true);
                    VolumeUnit volumeUnit2 = Enum.Parse<VolumeUnit>(thatQuantity.Unit, true);

                    QuantityVolume volumeq1 = new QuantityVolume(thisQuantity.Value, volumeUnit1);
                    QuantityVolume volumeq2 = new QuantityVolume(thatQuantity.Value, volumeUnit2);

                    result = volumeq1.Equals(volumeq2);

                    break;
                case "WEIGHT":

                    WeightUnit weightUnit1 = Enum.Parse<WeightUnit>(thisQuantity.Unit, true);
                    WeightUnit weightUnit2 = Enum.Parse<WeightUnit>(thatQuantity.Unit, true);

                    QuantityWeight weightq1 = new QuantityWeight(thisQuantity.Value, weightUnit1);
                    QuantityWeight weightq2 = new QuantityWeight(thatQuantity.Value, weightUnit2);

                    result = weightq1.Equals(weightq2);

                    break;

                case "TEMPERATURE":

                    TemperatureUnit t1 = Enum.Parse<TemperatureUnit>(thisQuantity.Unit, true);
                    TemperatureUnit t2 = Enum.Parse<TemperatureUnit>(thatQuantity.Unit, true);

                    double base1 = t1.ConvertToBaseUnit(thisQuantity.Value);
                    double base2 = t2.ConvertToBaseUnit(thatQuantity.Value);

                    result = Math.Abs(base1 - base2) < 0.0001;

                    break;

                default:
                    throw new Exception("Unsupported measurement type");
            }

            double compareResult = result ? 1 : 0;

            _repository.SaveOperation(new QuantityMeasurementEntity(
                thisQuantity.Value,
                thisQuantity.Unit,
                thatQuantity.Value,
                thatQuantity.Unit,
                "COMPARE",
                compareResult,
                thisQuantity.MeasurementType
            ));

            return compareResult;
        }
        public QuantityDTO AddQuantities(QuantityDTO thisQuantity, QuantityDTO thatQuantity)
        {
            if (thisQuantity.MeasurementType != thatQuantity.MeasurementType)
            {
                throw new Exception("Cannot perform operation on different measurement types");
            }

            double result;
            string resultUnit;

            switch (thisQuantity.MeasurementType.ToUpper())
            {
                case "LENGTH":

                    LengthUnit lengthUnit1 = Enum.Parse<LengthUnit>(thisQuantity.Unit, true);
                    LengthUnit lengthUnit2 = Enum.Parse<LengthUnit>(thatQuantity.Unit, true);

                    QuantityLength lengthq1 = new QuantityLength(thisQuantity.Value, lengthUnit1);
                    QuantityLength lengthq2 = new QuantityLength(thatQuantity.Value, lengthUnit2);

                    QuantityLength lengthResult = lengthq1.Add(lengthq2);

                    result = lengthResult.Value;
                    resultUnit = lengthResult.Unit.ToString();

                    break;
                case "VOLUME":

                    VolumeUnit volumeUnit1 = Enum.Parse<VolumeUnit>(thisQuantity.Unit, true);
                    VolumeUnit volumeUnit2 = Enum.Parse<VolumeUnit>(thatQuantity.Unit, true);

                    QuantityVolume volumeq1 = new QuantityVolume(thisQuantity.Value, volumeUnit1);
                    QuantityVolume volumeq2 = new QuantityVolume(thatQuantity.Value, volumeUnit2);

                    QuantityVolume volumeResult = volumeq1.Add(volumeq2);

                    result = volumeResult.Value;
                    resultUnit = volumeResult.Unit.ToString();

                    break;
                case "WEIGHT":

                    WeightUnit weightUnit1 = Enum.Parse<WeightUnit>(thisQuantity.Unit, true);
                    WeightUnit weightUnit2 = Enum.Parse<WeightUnit>(thatQuantity.Unit, true);

                    QuantityWeight weightq1 = new QuantityWeight(thisQuantity.Value, weightUnit1);
                    QuantityWeight weightq2 = new QuantityWeight(thatQuantity.Value, weightUnit2);

                    QuantityWeight weightResult = weightq1.Add(weightq2);

                    result = weightResult.value;
                    resultUnit = weightResult.unit.ToString();

                    break;
                case "TEMPERATURE":

                    TemperatureUnit tUnit =
                        Enum.Parse<TemperatureUnit>(thisQuantity.Unit, true);

                    tUnit.ValidateOperationSupport("ADD");

                    throw new UnsupportedOperationException(
                        "Addition not supported for Temperature");
                    break;

                default:
                    throw new Exception("Unsupported measurement type");
            }

            var entity = new QuantityMeasurementEntity(
                thisQuantity.Value,
                thisQuantity.Unit,
                thatQuantity.Value,
                thatQuantity.Unit,
                "ADD",
                result,
                thisQuantity.MeasurementType
            );

            _repository.SaveOperation(entity);

            return new QuantityDTO(result, resultUnit, thisQuantity.MeasurementType);
        }

        public QuantityDTO SubtractQuantities(QuantityDTO thisQuantity, QuantityDTO thatQuantity)
        {
            if (thisQuantity.MeasurementType != thatQuantity.MeasurementType)
                throw new Exception("Cannot perform operation on different measurement types");

            double result;
            string resultUnit;

            switch (thisQuantity.MeasurementType.ToUpper())
            {
                case "LENGTH":

                    LengthUnit lengthUnit1 = Enum.Parse<LengthUnit>(thisQuantity.Unit, true);
                    LengthUnit lengthUnit2 = Enum.Parse<LengthUnit>(thatQuantity.Unit, true);

                    QuantityLength lengthq1 = new QuantityLength(thisQuantity.Value, lengthUnit1);
                    QuantityLength lengthq2 = new QuantityLength(thatQuantity.Value, lengthUnit2);

                    QuantityLength resultQuantity = lengthq1.Subtract(lengthq2);

                    result = resultQuantity.Value;
                    resultUnit = resultQuantity.Unit.ToString();

                    break;
                case "VOLUME":

                    VolumeUnit volumeUnit1 = Enum.Parse<VolumeUnit>(thisQuantity.Unit, true);
                    VolumeUnit volumeUnit2 = Enum.Parse<VolumeUnit>(thatQuantity.Unit, true);

                    QuantityVolume volumeq1 = new QuantityVolume(thisQuantity.Value, volumeUnit1);
                    QuantityVolume volumeq2 = new QuantityVolume(thatQuantity.Value, volumeUnit2);

                    QuantityVolume volumeResult = volumeq1.Subtract(volumeq2);

                    result = volumeResult.Value;
                    resultUnit = volumeResult.Unit.ToString();

                    break;
                case "WEIGHT":

                    WeightUnit weightUnit1 = Enum.Parse<WeightUnit>(thisQuantity.Unit, true);
                    WeightUnit weightUnit2 = Enum.Parse<WeightUnit>(thatQuantity.Unit, true);

                    QuantityWeight weightq1 = new QuantityWeight(thisQuantity.Value, weightUnit1);
                    QuantityWeight weightq2 = new QuantityWeight(thatQuantity.Value, weightUnit2);

                    QuantityWeight weightResult = weightq1.Subtract(weightq2);

                    result = weightResult.value;
                    resultUnit = weightResult.unit.ToString();

                    break;

                case "TEMPERATURE":

                    TemperatureUnit tUnit =
                        Enum.Parse<TemperatureUnit>(thisQuantity.Unit, true);

                    tUnit.ValidateOperationSupport("SUBTRACT");

                    throw new UnsupportedOperationException(
                        "Subtraction not supported for Temperature");

                default:
                    throw new Exception("Unsupported measurement type");
            }

            var entity = new QuantityMeasurementEntity(
                thisQuantity.Value,
                thisQuantity.Unit,
                thatQuantity.Value,
                thatQuantity.Unit,
                "SUBTRACT",
                result,
                thisQuantity.MeasurementType
            );

            _repository.SaveOperation(entity);

            return new QuantityDTO(result, resultUnit, thisQuantity.MeasurementType);
        }
       

        public QuantityDTO DivideQuantities(QuantityDTO thisQuantity, QuantityDTO thatQuantity)
        {
            if (thisQuantity.MeasurementType != thatQuantity.MeasurementType)
                throw new Exception("Cannot perform operation on different measurement types");

            double result;

            switch (thisQuantity.MeasurementType.ToUpper())
            {
                case "LENGTH":

                    LengthUnit lengthUnit1 = Enum.Parse<LengthUnit>(thisQuantity.Unit, true);
                    LengthUnit lengthUnit2 = Enum.Parse<LengthUnit>(thatQuantity.Unit, true);

                    QuantityLength lengthq1 = new QuantityLength(thisQuantity.Value, lengthUnit1);
                    QuantityLength lengthq2 = new QuantityLength(thatQuantity.Value, lengthUnit2);

                    result = lengthq1.Divide(lengthq2);

                    break;
                case "VOLUME":

                    VolumeUnit volumeUnit1 = Enum.Parse<VolumeUnit>(thisQuantity.Unit, true);
                    VolumeUnit volumeUnit2 = Enum.Parse<VolumeUnit>(thatQuantity.Unit, true);

                    QuantityVolume volumeq1 = new QuantityVolume(thisQuantity.Value, volumeUnit1);
                    QuantityVolume volumeq2 = new QuantityVolume(thatQuantity.Value, volumeUnit2);

                    result = volumeq1.Divide(volumeq2);

                    break;
                case "WEIGHT":

                    WeightUnit weightUnit1 = Enum.Parse<WeightUnit>(thisQuantity.Unit, true);
                    WeightUnit weightUnit2 = Enum.Parse<WeightUnit>(thatQuantity.Unit, true);

                    QuantityWeight weightq1 = new QuantityWeight(thisQuantity.Value, weightUnit1);
                    QuantityWeight weightq2 = new QuantityWeight(thatQuantity.Value, weightUnit2);

                    result = weightq1.Divide(weightq2);

                    break;



                case "TEMPERATURE":

                    TemperatureUnit tUnit =
                        Enum.Parse<TemperatureUnit>(thisQuantity.Unit, true);

                    tUnit.ValidateOperationSupport("DIVIDE");

                    throw new UnsupportedOperationException(
                        "Division not supported for Temperature");

                default:
                    throw new Exception("Unsupported measurement type");
            }

            var entity = new QuantityMeasurementEntity(
                thisQuantity.Value,
                thisQuantity.Unit,
                thatQuantity.Value,
                thatQuantity.Unit,
                "DIVIDE",
                result,
                thisQuantity.MeasurementType
            );

            _repository.SaveOperation(entity);

            return new QuantityDTO(result, thisQuantity.Unit, thisQuantity.MeasurementType);
        }
       

        public QuantityDTO ConvertQuantity(QuantityDTO quantity, string targetUnit)
        {
            double result;

            switch (quantity.MeasurementType.ToUpper())
            {
                case "LENGTH":

                    LengthUnit lengthSource = Enum.Parse<LengthUnit>(quantity.Unit, true);
                    LengthUnit lengthTarget = Enum.Parse<LengthUnit>(targetUnit, true);

                    result = QuantityLength.Convert(quantity.Value, lengthSource, lengthTarget);

                    break;
                case "VOLUME":

                    VolumeUnit sourceVolume = Enum.Parse<VolumeUnit>(quantity.Unit, true);
                    VolumeUnit targetVolume = Enum.Parse<VolumeUnit>(targetUnit, true);

                    QuantityVolume qVolume =
                        new QuantityVolume(quantity.Value, sourceVolume);

                    QuantityVolume convertedVolume =
                        qVolume.ConvertTo(targetVolume);

                    result = convertedVolume.Value;

                    break;
                case "WEIGHT":

                    WeightUnit sourceWeight = Enum.Parse<WeightUnit>(quantity.Unit, true);
                    WeightUnit targetWeight = Enum.Parse<WeightUnit>(targetUnit, true);

                    QuantityWeight qWeight =
                        new QuantityWeight(quantity.Value, sourceWeight);

                    QuantityWeight convertedWeight =
                        qWeight.ConvertTo(targetWeight);

                    result = convertedWeight.value;

                    break;

                case "TEMPERATURE":

                    TemperatureUnit tempSource =
                        Enum.Parse<TemperatureUnit>(quantity.Unit, true);

                    TemperatureUnit tempTarget =
                        Enum.Parse<TemperatureUnit>(targetUnit, true);

                    double baseValue = tempSource.ConvertToBaseUnit(quantity.Value);

                    result = tempTarget.ConvertFromBaseUnit(baseValue);

                    break;

                default:
                    throw new Exception("Unsupported measurement type");
            }

            var entity = new QuantityMeasurementEntity(
                quantity.Value,
                quantity.Unit,
                0,
                targetUnit,
                "CONVERT",
                result,
                quantity.MeasurementType
            );

            _repository.SaveOperation(entity);

            return new QuantityDTO(result, targetUnit, quantity.MeasurementType);
        }
        public List<QuantityMeasurementEntity> GetErroredOperations()
        {
            return _repository.GetAll().FindAll(e => e.Operation.Contains("ERROR"));
        }

        public int GetOperationCount(string operationType)
        {
            return _repository.GetAll().FindAll(e => e.Operation == operationType).Count;
        }
    }
}