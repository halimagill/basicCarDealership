using basicCarDealership_prep.data;
using basicCarDealership_prep.data.Models;
using basicCarDealership_prep.data.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace basicCarDealership_prep.Test
{
    public class BasicCarDealershipTest : IDisposable
    {
        private readonly ITrellisCarDealershipContext _context;
        private readonly CarRepository _repository;

        public BasicCarDealershipTest()
        {
            var options = new DbContextOptionsBuilder<ITrellisCarDealershipContext>()
                .UseSqlServer("Server=PCSONIC;Database=iTrellisCarDealership;Integrated Security=true;MultipleActiveResultSets=true;TrustServerCertificate=True;")
                .Options;

            _context = new ITrellisCarDealershipContext(options);
            //_context.Database.EnsureDeleted();
            //_context.Database.Migrate();

            _repository = new CarRepository(_context);
        }

        [Fact]
        public void VehicleSearchViewModel_FindVehicleByParams_Test()
        {
            var results = Task.Run(() => _repository.FindVehicleByParams()).Result.ToList();

            bool expectations = results.Count > 0;
            Assert.True(expectations);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}

        
    

