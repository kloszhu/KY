using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace KY.Converter
{
    public abstract class AbstractConverter
    {

        public readonly static AbstractConverter abstractConverter= new ConverterDictionary();
      
      
        public abstract string SerializeDictionaryToJsonString<TKey, TValue>(Dictionary<TKey, TValue> dict);
        public abstract object DeserializeJson(string json);
        public abstract Dictionary<string, object> ConvertDictionary(object obj);
    }
    public  class ConverterDictionary : AbstractConverter
    {

        public  override Dictionary<string, object> ConvertDictionary(object obj)
        {
            return Converter.ConvertDictionary(obj);
        }

        public  override object DeserializeJson(string json)
        {
            return Converter.DeserializeJson(json);
        }

        public override string SerializeDictionaryToJsonString<TKey, TValue>(Dictionary<TKey, TValue> dict)
        {
            return Converter.SerializeDictionaryToJsonString(dict);
        }
    }


}
