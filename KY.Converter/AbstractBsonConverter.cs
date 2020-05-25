using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using Newtonsoft.Json.Bson.Converters;

namespace KY.Converter
{
    public abstract  class AbstractBsonConverter
    {
        public static AbstractBsonConverter BsonConverter = new BsonConverter();
        public abstract string SerializeBson(BsonDocument bsons);
        public abstract BsonDocument DeserializeJson(string json);
        public abstract Dictionary<string, object> Convert(BsonDocument bsons);
        public abstract BsonDocument Convert(Dictionary<string, object> keys);
    }

    public class BsonConverter : AbstractBsonConverter
    {
    

        public override BsonDocument DeserializeJson(string json)
        {
            return  BsonSerializer.Deserialize<BsonDocument>(json);
        }

        public override string SerializeBson(BsonDocument bsons)
        {
            return bsons.ToJson();
        }
        public override Dictionary<string, object> Convert(BsonDocument  bsons)
        {
            return bsons.ToDictionary();
        }

        public override BsonDocument Convert(Dictionary<string, object> keys)
        {
            return keys.ToBsonDocument();
        }

    }
}
