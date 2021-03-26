using Dozen2Models;
 using System.Collections.Generic;
 namespace Dozen2BL
{
     public interface ILocationBL
     {
          List<Location> GetLocations();
          Location GetSpecifiedLocation(int storeCode);
     }
}