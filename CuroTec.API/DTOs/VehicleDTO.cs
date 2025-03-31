using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CuroTec.Domain.Enums;

namespace CuroTec.API.DTOs
{
    record VehicleDto(VehicleType VehicleType, string Color);
}