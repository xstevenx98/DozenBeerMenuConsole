using Dozen2Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dozen2DL
{
    public class LocationRepositoryDB : ILocationRepository
    {
        private Entities.DBSteveIP0Context context;
        private Mapper mapper;

        public LocationRepositoryDB(Entities.DBSteveIP0Context context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public List<Location> GetLocations()
        {
            var entityLocations = context.Locations.ToList();
            var locations = mapper.ParseLocations(entityLocations);
            return locations;
        }

        public Location GetSpecifiedLocation(int storeCode)
        {
            throw new NotImplementedException();
        }
    }
}
