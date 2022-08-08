using MSA.Phase2.Backend.Models;

namespace MSA.Phase2.Backend.Services
{
    public static class LocationService
    {
        static Dictionary<string, Location> Locations { get; }
        static LocationService()
        {
            Locations = new Dictionary<string, Location>{
                {
                    "University of Auckland",
                    new Location
                    {
                        Name = "University of Auckland",
                        Lat = -36.85219183400027,
                        Lng = 174.76913948480936
                        }
                        },
                {
                    "Hamilton",
                    new Location
                    {
                        Name="Hamilton",
                        Lat = -37.79353652390541,
                        Lng = 175.28538457585492
                    }
                },
            };
        }

        public static List<Location> GetAll() => Locations.Values.ToList();

        public static Location? Get(string name)
        {
            if (Locations.ContainsKey(name))
                return Locations[name];
            else return null;
        }

        public static bool Add(Location location)
        {
            if (!Locations.ContainsKey(location.Name))
            {
                Locations.Add(location.Name, location);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool Update(Location location)
        {
            if (!Locations.ContainsKey(location.Name))
            {
                return false;
            }

            Locations[location.Name] = location;
            return true;
        }

        public static void Delete(string name)
        {
            if (Locations.ContainsKey(name))
            {
                Locations.Remove(name);
            }
        }
    }
}