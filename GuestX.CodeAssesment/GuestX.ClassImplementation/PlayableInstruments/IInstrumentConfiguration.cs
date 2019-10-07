using System.Collections.Generic;

namespace GuestX.ClassImplementation
{
    interface IInstrumentConfiguration<T>
    {
        IDictionary<int, T> CreateFrets();
    }
}