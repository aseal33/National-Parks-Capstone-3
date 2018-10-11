using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public interface IDispensible
    {
        string Name { get; }

        string Location { get; }

        decimal Price { get; }

        string Type { get; }

        string Consumed(Type type);        
    }
}
