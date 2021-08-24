using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Interfaces
{
    public interface Serializer
    {
        void Serialize(object objectToSerialize);
        TTypeDeserialized Deserialized<TTypeDeserialized>(string pathFileThatContainsObjects) where TTypeDeserialized : class;
        object Deserialized(string stringObjectSerialized);
    }
}
