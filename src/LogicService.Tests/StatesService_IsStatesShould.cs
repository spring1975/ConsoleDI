using NUnit.Framework;
using LogicService.Services;
using LogicService.Interfaces;
using System.Linq;

namespace LogicService.Tests
{
    [TestFixture]
    public class StatesService_IsStatesShould
    {
        private readonly IStatesService _statesService;

        public StatesService_IsStatesShould()
        {
            _statesService = new StatesService();            
        }

        [TestCase(0, "Alabama")]
        [TestCase(10, "Hawaii")]
        [TestCase(13, "Indiana")]
        public void ReturnStateById(int stateId, string stateName)
        {
            var result = _statesService.GetState(stateId);

            Assert.AreEqual(stateName, result);
        }

        [Test]
        public void ReturnStateDTOList()
        {
            var result = _statesService.GetStates().ToList();
            var hawaii = result.ElementAt(10);
            Assert.AreEqual("Hawaii", hawaii.Name);
            Assert.AreEqual(11, hawaii.StateId);
        }
    }
}
