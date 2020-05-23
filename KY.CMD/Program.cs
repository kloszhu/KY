﻿using System;
using System.IO;
using KY.CMD.Model;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using KY.Converter;
using MongoDB.Bson;
using System.Collections;

namespace KY.CMD
{
    class Program
    {
       
        static  void Main(string[] args)
        {
            Console.ReadKey();
            testBson();
            Console.ReadKey();
            //TestConvert();

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
            var ss = new Student { ID = 1, Name = "周杰伦" };

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
