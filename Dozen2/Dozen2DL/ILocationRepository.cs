using Dozen2Models;
using System.Collections.Generic;

namespace Dozen2DL
{
    public interface ILocationRepository
    {
         List<Location> GetLocations();

         Location GetSpecifiedLocation (int storeCode);
    }
}