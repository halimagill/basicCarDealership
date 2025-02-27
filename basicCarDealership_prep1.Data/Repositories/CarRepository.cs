using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using basicCarDealership_prep.data.Models;
using basicCarDealership_prep.Data.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace basicCarDealership_prep.data.Repositories
{
    public class CarRepository : ICarRepository
    {
        private ITrellisCarDealershipContext _context;
        public CarRepository(ITrellisCarDealershipContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VehicleSearchViewModel>> FindVehicleByParams()
        {
            return Task.Run(() => FindVehicleByParams()).Result;
        }

        public async Task<IEnumerable<VehicleSearchViewModel>> FindVehicleByParams(VehicleSelectionDto selection)
        {
            var colorsComma = selection.Colors?.Count > 0 ? string.Join(",", selection.Colors.Select(x => x.ColorName).ToList()) : null;
            var makeComma = selection.Makes?.Count > 0 ? string.Join(",", selection.Makes.Select(x => x.MakeName).ToList()) : null;

            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@Color", string.IsNullOrEmpty(colorsComma) ? (object)DBNull.Value : colorsComma));
            parameter.Add(new SqlParameter("@MinYear", selection.MinYear));
            parameter.Add(new SqlParameter("@MaxYear", selection.MaxYear));
            parameter.Add(new SqlParameter("@Make", string.IsNullOrEmpty(makeComma) ? (object)DBNull.Value : makeComma));
            parameter.Add(new SqlParameter("@MinPrice", selection.MinPrice));
            parameter.Add(new SqlParameter("@MaxPrice", selection.MaxPrice));
            parameter.Add(new SqlParameter("@HasSunroof", selection.HasSunroof ?? (object)DBNull.Value));
            parameter.Add(new SqlParameter("@IsFourWheelDrive", selection.IsFourWheelDrive ?? (object)DBNull.Value));
            parameter.Add(new SqlParameter("@HasLowMiles", selection.HasLowMiles ?? (object)DBNull.Value));
            parameter.Add(new SqlParameter("@HasPowerWindows", selection.HasPowerWindows ?? (object)DBNull.Value));
            parameter.Add(new SqlParameter("@HasNavigation", selection.HasNavigation ?? (object)DBNull.Value));
            parameter.Add(new SqlParameter("@HasHeatedSeats", selection.HasHeatedSeats ?? (object)DBNull.Value));

            var result = await Task.Run(() => _context.Vehicles
           .FromSqlRaw(@"exec dbo.usp_VehicleSearch @Color,@MinYear,@MaxYear,@Make,@MinPrice,@MaxPrice,@HasSunroof,@IsFourWheelDrive,@HasLowMiles,@HasPowerWindows,@HasNavigation,@HasHeatedSeats", parameter.ToArray()));

            return result;
        }
    }
}
