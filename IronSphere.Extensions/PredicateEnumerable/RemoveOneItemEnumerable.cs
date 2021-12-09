using System;
using System.Collections;
using System.Collections.Generic;

namespace IronSphere.Extensions.PredicateEnumerable
{
    internal class RemoveOneItemEnumerable<T> : IPredicateEnumerable<T>
    {
        private IEnumerable<T> _sequence;
        private readonly T _elementToRemove;                           
        private Func<IEnumerable<T>, T, bool>? _expression;

        private bool _ifExecuted;

        public RemoveOneItemEnumerable(IEnumerable<T> sequence, T elementToRemove)
        {
            _sequence = sequence;
            _elementToRemove = elementToRemove;
        }

        public IEnumerable<T> If(Func<IEnumerable<T>, T, bool> expression)
        {
            _expression = expression;
            return this;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (_ifExecuted)
                return _sequence.GetEnumerator();
            
            _ifExecuted = true;

            if (_expression == null || _expression(_sequence, _elementToRemove))
                return (_sequence = _sequence.RemoveSingleItem(_elementToRemove)).GetEnumerator();
                             
            return _sequence.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
