using System.Collections.Generic;

namespace PaddleWrapper;

public sealed class FiltersUndefined : Dictionary<string, object>
{
    public FiltersUndefined() : base() { }
    
    public FiltersUndefined(IDictionary<string, object> dictionary) : base(dictionary) { }
} 