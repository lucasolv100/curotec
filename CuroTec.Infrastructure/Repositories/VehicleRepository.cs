using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CuroTec.Domain.Entities;

using CuroTec.Infrastructure;
using CuroTec.Domain.Interfaces;
using CuroTec.Domain.Enums;

namespace CuroTec.Infrastructure.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly CuroTecContext _context;

        public VehicleRepository(CuroTecContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Vehicle>> GetAllAsync(int page, int pageSize)
        {
            return await _context.Vehicles.Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        }

        public async Task<Vehicle> GetByIdAsync(int id)
        {
            return await _context.Vehicles.FindAsync(id);
        }

        public async Task<Vehicle> GetByTypeAsync(VehicleType type)
        {
            return await _context.Vehicles.FirstOrDefaultAsync(t => t.VehicleType == type); 
        }

        public async Task<Vehicle> GetByColorAsync(string color)
        {
            return await _context.Vehicles.FirstOrDefaultAsync(t => t.Color.Contains(color)); 
        }

        public async Task<Vehicle> AddAsync(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();
            return vehicle;
        }

        public async Task<Vehicle> UpdateAsync(Vehicle vehicle)
        {
            _context.Vehicles.Update(vehicle);
            await _context.SaveChangesAsync();
            return vehicle;
        }

        
    }
}
