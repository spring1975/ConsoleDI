using System.Collections.Generic;

namespace Data
{
    public class InMemoryRepo
    {
        private ICollection<int> _ListOfNumbers;

        public InMemoryRepo()
        {
            _ListOfNumbers = new List<int> { 1 };
        }

        public ICollection<int> Get()
        {
            return _ListOfNumbers;
        }

        public void Add()
        {
            var nextNum = _ListOfNumbers.Count + 1;
            _ListOfNumbers.Add(nextNum);
        }
    }
}
