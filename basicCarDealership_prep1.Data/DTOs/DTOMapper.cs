using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using basicCarDealership_prep.data.Models;

namespace basicCarDealership_prep.Data.DTOs
{
    public static class DTOMapper
    {
        public static VehicleSearchResult ToDTO(this VehicleSearchViewModel searchEntity)
        {
            if (searchEntity == null) return null;

            return new VehicleSearchResult
            {
                _id = searchEntity.CarId,
                Make = searchEntity.MakeName,
                Year = searchEntity.Year,
                Color = searchEntity.ColorName,
                Price = searchEntity.Price,
                HasSunroof = searchEntity.HasSunroof,
                IsFourWheelDrive = searchEntity.IsFourWheelDrive,
                HasLowMiles = searchEntity.HasLowMiles,
                HasPowerWindows = searchEntity.HasPowerWindows,
                HasHeatedSeats = searchEntity.HasHeatedSeats
            };
        }

        public static IEnumerable<VehicleSearchResult> ToDTO(this IEnumerable<VehicleSearchViewModel> searchResults)
        {
            if (searchResults == null) return null;

            var dto = new List<VehicleSearchResult>();

            foreach (var result in searchResults)
            {
                dto.Add(result.ToDTO());
            }

            return dto;
        }
    }
}
