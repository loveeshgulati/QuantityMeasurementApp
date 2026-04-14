using QuantityMeasurement.QuantityService.Entities;

namespace QuantityMeasurement.QuantityService.Interfaces
{
    public interface IQuantityMeasurementRepository
    {
        void SaveOperation(QuantityMeasurementEntity entity);

        List<QuantityMeasurementEntity> GetAll();
    }
}