namespace Dozen2Models
{
  public class Location
  {
    private string locationName; 
      private int locationID;
      //  private string address;
      private string state;
      public static int numberOfLocations = 0;
        //add a property for location inventory   

      public string LocationName
      {
        get
        {
          return locationName;
        }
        set
        {
          locationName = value;
        }
      }

      public string State
      {
        get
        {
            return state;
        }
        set
        {
          state = value;
        }
      }

      public int LocationID
      {
        get
        {
          return locationID;
        }
        set
        {
          locationID = value;
        }
      }

      public override string ToString()
      {
        return 
        $"Store Information: \n\t Store Code: {this.LocationID} \n\t Store Name: {this.LocationName} \n\t State: {this.State}";
      }

  }
}