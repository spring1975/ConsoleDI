using System.Collections.Generic;
using DTO;
using LogicService.Interfaces;
using System.Linq;

namespace LogicService.Services
{
    public class StatesService : IStatesService
    {
        private List<string> _states = new List<string> {
            "Alabama","Alaska","Arizona","Arkansas","California","Colorado","Connecticut","Delaware","Florida",
            "Georgia","Hawaii","Idaho","Illinois ","Indiana","Iowa","Kansas","Kentucky","Louisiana","Maine",
            "Maryland","Massachusetts","Michigan","Minnesota","Mississippi","Missouri","Montana","Nebraska",
            "Nevada","New Hampshire","New Jersey","New Mexico","New York","North Carolina","North Dakota",
            "Ohio","Oklahoma","Oregon","Pennsylvania","Rhode Island","South Carolina","South Dakota","Tennessee",
            "Texas","Utah","Vermont","Virginia","Washington","West Virginia","Wisconsin","Wyoming"};
        public IEnumerable<StateDTO> GetStates() {
            var states = new List<StateDTO>();

            int i = 1;
            _states.ForEach(x => states.Add(new StateDTO { StateId = i++, Name = x }));

            return states;
        }

        public string GetState(int stateId)
        {
            return _states[stateId];
        }
    }
}
