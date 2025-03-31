using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CuroTec.Domain.Entities;
using CuroTec.Domain.Enums;

namespace CuroTec.Domain.Interfaces
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<Vehicle>> GetAllAsync(int page, int pageSize);
        Task<Vehicle> GetByIdAsync(int id);
        Task<Vehicle> AddAsync(Vehicle vehicle);
        Task<Vehicle> UpdateAsync(Vehicle vehicle);
        Task<Vehicle> GetByTypeAsync(VehicleType type);
        Task<Vehicle> GetByColorAsync(string color);
    }
}