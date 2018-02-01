using DTO;
using System.Collections.Generic;
using DataStandard;
using LogicService.Interfaces;

namespace LogicService.Services
{
    public class CityService: ICityService
    {
        private LocationsContext _context;

        public CityService(LocationsContext context)
        {
            _context = context;
        }

        public IEnumerable<CitiesDTO> GetCities { get; set; }

        public CitiesDTO AddCity(string name)
        {
            var city = new Cities
            {
                Name = name
            };

            _context.Cities.Add(city);
            _context.SaveChanges();

            var cityDto = new CitiesDTO
            {
                Name = city.Name
            };

            
            return cityDto;
        }
    }
}
