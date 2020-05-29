using System;
using System.IO;
using KY.CMD.Model;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using KY.Converter;
using MongoDB.Bson;
using System.Collections;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using KY.RuntimeEntity;
using System.Reflection;

namespace KY.CMD
{
    class Program
    {
        public class test {
           public  MyType type { get; set; } 
        }
        static  void Main(string[] args)
        {
            string types = "System.Int32";
            Type type = Type.GetType("int");
            var data = new { type1 = "Int32" };
            string json = "{\"type\":\"Nullable\"}";
           
          var json1=JsonConvert.DeserializeObject<test>(json);
            Console.WriteLine(json);
            //Console.ReadKey();
            //SaveMong();
            //testBson();
            //SaveDynamic();
            Console.ReadKey();
            //TestConvert();

        }
        static void Get() {

            IMongoClient mongo = new MongoClient("mongodb://127.0.0.1:27018");
            IMongoDatabase db = mongo.GetDatabase("mydata");
            var collection = db.GetCollection<BsonDocument>("mytest");
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(GetData());
            var BsonCollection = AbstractBsonConverter.BsonConverter.DeserializeJson(json);
           
       

            var builder = Builders<BsonDocument>.Filter.Eq("id", 123);
            var data=  collection.Find(builder).First();
 
        
        }
        static void SaveDynamic() {
           
          

            AutoAssembly assembly = new AutoAssembly();
            var list = new List<MyProerty>();
            list.Add(new MyProerty { ProertyName = "ID", PropertyType = typeof(int) });
            list.Add(new MyProerty { ProertyName = "IDS", PropertyType = typeof(int) });
            list.Add(new MyProerty { ProertyName = "IDSS", PropertyType = typeof(int) });
            list.Add(new MyProerty { ProertyName = "IDSSS", PropertyType = typeof(int) });
            list.Add(new MyProerty { ProertyName = "IDSSSS", PropertyType = typeof(int) });
            list.Add(new MyProerty { ProertyName = "IDSSSSS", PropertyType = typeof(int) });
            assembly.DefineAssembly("myCustomerAssembly").DefineModule("CustomerAssembly").DefineType("Students").SetProerties(list).Save();
            var data = assembly.resultType;
            object o1 = Activator.CreateInstance(data);
            int i = 0;
            foreach (var item in o1.GetType().GetProperties())
            {
                i++;
                item.SetValue(o1,i);
            }
            MongoHelp mongoHelp = new MongoHelp();
            var method = mongoHelp.GetType().GetMethod("SaveMong").MakeGenericMethod(data);
           var collections=  method.Invoke(mongoHelp, new[] {o1 });
            Console.WriteLine(JsonConvert.SerializeObject(o1));
          
        }

        static void SaveMong() {
            IMongoClient mongo = new MongoClient("mongodb://127.0.0.1:27018");
            IMongoDatabase db =  mongo.GetDatabase("mydata");
            var collection = db.GetCollection<BsonDocument>("mytest");
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(GetData());
            var BsonCollection = AbstractBsonConverter.BsonConverter.DeserializeJson(json);
            collection.InsertOne(BsonCollection);
        }

        public static object GetData() {
            return new
            {
                id = 123,
                childrenid = new int[] { 123, 1234, 5443 },
                children = new ArrayList { new { ids = "234", data = "4234234" }, new { ids = "134", data = "24324" } }
            };
        }

        public static void testBson() {
            var data = new { id = 123, childrenid = new int[] { 123, 1234, 5443 },
                children = new ArrayList{ new{ ids = "234",data="4234234" },new   { ids = "134", data = "24324" } } };
            var json=  JsonConvert.SerializeObject(data);
            BsonDocument result = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonDocument>(json);
            var eee = result.ToJson();
            var dd= Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }

        public static void BC_AddTakeCompleteAdding() {
            AddTakeDemo.BC_AddTakeCompleteAdding();
            TryTakeDemo.BC_TryTake();
            FromToAnyDemo.BC_FromToAny();
            ConsumingEnumerableDemo.BC_GetConsumingEnumerable();
            Console.WriteLine("Press any key to exit.");
        }

        public static void   TestConvert() {
            string basepath = AppContext.BaseDirectory;
            string StudentJson = Path.Combine(basepath, "Json/Student.json");
            if (!Directory.Exists("Json"))
            {
                Directory.CreateDirectory("Json");
            }
           // var ss = new Student { ID = 1, Name = "周杰伦" };

            var dd = new { SSID = 1, SName = "周杰伦", SPPID = new[] { 1, 2, 3 }, children = new[] { new { ids = 4, names = "123" }, new { ids = 2, names = "321" }, new { ids = 6, names = "222" } } };
            var json = JsonConvert.SerializeObject(dd);
            var cc = AbstractJsonConverter.Converter.DeserializeJson(json);
            Dictionary<string, object> Father = new Dictionary<string, object>();
            Father.Add("ID", "PPPP");
            Dictionary<string, object> Teacher = new Dictionary<string, object>();
            Teacher.Add("Code", Guid.NewGuid());
            Father.Add("children", Teacher);
            var json1 = JsonConvert.SerializeObject(Father);
            Console.WriteLine("Hello World!");
            Console.WriteLine("Json转Dic，Dic转Json，支持层级转换");
        }
    }
}
