using QuantityMeasurement.QuantityService.Entities;
using QuantityMeasurement.QuantityService.Data;
using QuantityMeasurement.QuantityService.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace QuantityMeasurement.QuantityService.Repository
{
    public class QuantityMeasurementEFRepository : IQuantityMeasurementRepository
    {
        private readonly QuantityDbContext _context;

        public QuantityMeasurementEFRepository(
            QuantityDbContext context, 
            QuantityMeasurementCacheRepository cacheRepository)
        {
            _context = context;
        }

        
            public void SaveOperation(QuantityMeasurementEntity entity)
{
    _context.QuantityMeasurements.Add(entity);
    _context.SaveChanges(); 
}
        public List<QuantityMeasurementEntity> GetAll()
        {
            return _context.QuantityMeasurements.ToList();
        }
    }
}