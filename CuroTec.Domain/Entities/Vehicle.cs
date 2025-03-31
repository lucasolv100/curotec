using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CuroTec.Domain.Enums;

namespace CuroTec.Domain.Entities
{
    public class Vehicle : Base
    {
        public VehicleType VehicleType { get; set; }
        public string Color { get; set; }
        
        public Vehicle(VehicleType vehicleType, string color)
        {
            VehicleType = vehicleType;
            Color = color;
        }

        public void Update(VehicleType vehicleType, string color) {
            VehicleType = vehicleType;
            Color = color;
            LastModifiedDate = DateTime.Now;
        }
        public void Delete() {
            
            DeletedDate = DateTime.Now;
        }
    }
}