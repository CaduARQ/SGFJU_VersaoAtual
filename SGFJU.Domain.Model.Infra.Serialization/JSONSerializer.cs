using Newtonsoft.Json;
using SGFJU.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace SGFJU.Domain.Model.Infra.Serialization
{
    public class JSONSerializer : Serializer
    {
        public void Serialize(object objectToSerialize)
        {
            if (objectToSerialize == null)
                throw new SerializationException("Objeto passado para serializar é nulo ");
        }

        public object Deserialized(string stringObjectSerialized)
        {
            return null;
        }

        public string SerializeToJSON(object objectToSerialize)
        {
            if (objectToSerialize == null)
                throw new SerializationException("Objeto passado para serializar é nulo ");

            return JsonConvert.SerializeObject(objectToSerialize);
        }

        public string SerializeConfiguredToWorkWithNHibernateResolver(object objecttoSerialize)
        {
            try
            {
                if (objecttoSerialize == null)
                    throw new SerializationException("Objeto passado para serializar é nulo ");

                var jsonSerializerSettings = new JsonSerializerSettings();
                jsonSerializerSettings.ContractResolver = new NHibernateContractResolver();
                jsonSerializerSettings.NullValueHandling = NullValueHandling.Include;
                jsonSerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

                return JsonConvert.SerializeObject(objecttoSerialize, Formatting.Indented, jsonSerializerSettings);
            }
            catch (Exception exception)
            {
                var exceptionDescriptionMessage = string.Format("{0}.{1}()-{2}", this.GetType().Name, "SerializeToJSON", exception.Message);
                throw new SerializationException(exceptionDescriptionMessage, exception);
            }
        }

        public void SerializeToJSON(object objecttoSerialize, string pathFileToSaveObjectsSerializeds)
        {
            try
            {
                if (objecttoSerialize == null)
                    throw new SerializationException("Objeto passado para serializar é nulo ");

                if (string.IsNullOrEmpty(pathFileToSaveObjectsSerializeds))
                    throw new SerializationException(string.Format("{0}.{1}() - Diretório onde objeto serializado será salvo, deve ser informado!", this.GetType().Name, "SerializeToJSON"));

                var jsonSerializerSettings = new JsonSerializerSettings();
                jsonSerializerSettings.ContractResolver = new NHibernateContractResolver();
                jsonSerializerSettings.NullValueHandling = NullValueHandling.Include;
                jsonSerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                var objectSerialized = JsonConvert.SerializeObject(objecttoSerialize, Formatting.Indented, jsonSerializerSettings);

                File.WriteAllText(pathFileToSaveObjectsSerializeds, objectSerialized);
            }
            catch (Exception exception)
            {
                var exceptionDescriptionMessage = string.Format("{0}.{1}()-{2}", this.GetType().Name, "SerializeToJSON", exception.Message);
                throw new SerializationException(exceptionDescriptionMessage, exception);
            }
        }

        public TTypeToReturn Deserialized<TTypeToReturn>(string pathObjectSerialized) where TTypeToReturn : class
        {
            try
            {
                var objectSerialized = File.ReadAllText(path: pathObjectSerialized);
                return JsonConvert.DeserializeObject<TTypeToReturn>(objectSerialized);
            }
            catch (Exception exception)
            {
                var exceptionDescriptionMessage = string.Format("{0}.{1}()-{2}", this.GetType().Name, "SerializeToJSON", exception.Message);
                throw new SerializationException(exceptionDescriptionMessage, exception);
            }
        }
    }
}
