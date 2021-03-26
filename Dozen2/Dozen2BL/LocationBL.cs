using System.Collections.Generic;
using Dozen2Models;
using Dozen2DL;
using System;
using Dozen2BL;

namespace DozenBL
{
    /// <summary>
    /// business logic for the location class
    /// </summary>
    public class LocationBL : ILocationBL
    {
        private ILocationRepository _repo;
        public LocationBL (ILocationRepository repo)
        {
            _repo = repo;
        }
    
        public List <Location> GetLocations()
        {
            return _repo.GetLocations();
        }

        public Location GetSpecifiedLocation(int storeCode)
        {
            return _repo.GetSpecifiedLocation(storeCode);
        }
    }
}


        // {
        //     Location chosenLocation = null;
        //     bool isSelected = false;
        //     while (!isSelected)
        //     {
        //         Console.WriteLine("All Dozen's Store Locations");
        //         foreach (var item in GetLocations())
        //         {
        //             Console.WriteLine(item.ToString());
        //         }

        //         Console.WriteLine("Enter Store Code: ");
        //         int storeCode = int.Parse(Console.ReadLine());
        //         foreach(var item in _repo.GetLocations())
        //         {
        //             if(item.LocationID == storeCode)
        //             {
        //                 chosenLocation = item;
        //                 isSelected = true;
        //             }
        //         }
        //         if(!isSelected)
        //         {
        //             Console.WriteLine("Store code cannot be found.");
        //             Console.WriteLine("Please Try again.");
        //         }
        //     }
        //         return chosenLocation;
        // }
    
