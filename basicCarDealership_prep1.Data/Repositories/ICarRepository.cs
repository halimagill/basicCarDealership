using basicCarDealership_prep.data.Models;
using basicCarDealership_prep.Data.DTOs;
using basicCarDealership_prep.Data.Models;

namespace basicCarDealership_prep.data.Repositories
{
    public interface ICarRepository
    {
        Task<IEnumerable<VehicleSearchResult?>> FindVehicleByParams();
        Task<IEnumerable<VehicleSearchResult?>> FindVehicleByParams(VehicleSelectionDto selection = null);        
    }
}