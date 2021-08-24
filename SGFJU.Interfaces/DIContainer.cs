using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Interfaces
{
    public interface DIContainer
    {
        void RegisterAbstraction(Type abstraction, Type implementation);
        void RegisterAbstractionForAInstance(Type abstraction, object instanceAbstractionImplementation);
        object GetServiceImplementation(Type abstraction);
        TToType GetServiceImplementationToType<TToType>() where TToType : class;
    }
}
