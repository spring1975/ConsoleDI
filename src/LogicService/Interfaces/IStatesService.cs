using DTO;
using System.Collections.Generic;

namespace LogicService.Interfaces
{
    public interface IStatesService
    {
        IEnumerable<StateDTO> GetStates();
        string GetState(int stateId);
    }
}