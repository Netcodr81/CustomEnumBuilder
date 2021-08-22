using System;
using System.Linq;

namespace CustomEnum.Contracts
{
    public interface IEnumeratorType
    {
        bool Equals(object obj);
        int GetHashCode();
        string ToString();

        string DisplayName { get; }
        object Value { get; }
    }
}
