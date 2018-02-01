using DTO;
using System.Collections.Generic;

namespace LogicService.Interfaces
{
    public interface ICityService
    {
        IEnumerable<CitiesDTO> GetCities { get; set; }
        CitiesDTO AddCity(string name);
    }
}