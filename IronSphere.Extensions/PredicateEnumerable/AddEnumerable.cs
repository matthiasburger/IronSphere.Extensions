using System;
using System.Collections;
using System.Collections.Generic;

namespace IronSphere.Extensions.PredicateEnumerable;

internal class AddEnumerable<T> : IPredicateEnumerable<T>
{
    private IEnumerable<T> _sequence;
    private readonly T _elementToAdd;                           
    private Func<IEnumerable<T>, T, bool>? _expression;

    private bool _ifExecuted;

    public AddEnumerable(IEnumerable<T> sequence, T elementToAdd)
    {
        _sequence = sequence;
        _elementToAdd = elementToAdd;
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

        if (_expression == null || _expression(_sequence, _elementToAdd))
            return (_sequence = _sequence.AddSingleItem(_elementToAdd)).GetEnumerator();
                             
        return _sequence.GetEnumerator();
    }
        
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}