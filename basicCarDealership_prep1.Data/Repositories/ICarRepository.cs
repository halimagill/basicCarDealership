using basicCarDealership_prep.data.Models;
using basicCarDealership_prep.Data.Models;

namespace basicCarDealership_prep.data.Repositories
{
    public interface ICarRepository
    {
        Task<IEnumerable<VehicleSearchViewModel>> FindVehicleByParams();
        Task<IEnumerable<VehicleSearchViewModel>> FindVehicleByParams(VehicleSelectionDto? selection = null);        
    }
}