using System;
using System.IO;
using KY.CMD.Model;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using KY.Converter;


namespace KY.CMD
{
    class Program
    {
       
        static  void Main(string[] args)
        {
            Console.ReadKey();
            AddTakeDemo.BC_AddTakeCompleteAdding();
            TryTakeDemo.BC_TryTake();
            FromToAnyDemo.BC_FromToAny();
             ConsumingEnumerableDemo.BC_GetConsumingEnumerable();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            //TestConvert();

        }

        public static void   TestConvert() {
            string basepath = AppContext.BaseDirectory;
            string StudentJson = Path.Combine(basepath, "Json/Student.json");
            if (!Directory.Exists("Json"))
            {
                Directory.CreateDirectory("Json");
            }
            var ss = new Student { ID = 1, Name = "周杰伦" };
            var pp = ss.ConvertDictionary();

            var dd = new { SSID = 1, SName = "周杰伦", SPPID = new[] { 1, 2, 3 }, children = new[] { new { ids = 4, names = "123" }, new { ids = 2, names = "321" }, new { ids = 6, names = "222" } } };
            var json = JsonConvert.SerializeObject(dd);
            var cc = AbstractConverter.abstractConverter.DeserializeJson(json);
            var ccc = cc.ConvertDictionary();
            Dictionary<string, object> Father = new Dictionary<string, object>();
            Father.Add("ID", "PPPP");
            Dictionary<string, object> Teacher = new Dictionary<string, object>();
            Teacher.Add("Code", Guid.NewGuid());
            Father.Add("children", Teacher);
            var json1 = JsonConvert.SerializeObject(Father);
            var ccc1 = json1.DeserializeJson().ConvertDictionary();
            File.WriteAllTextAsync("Json/Student.json", JsonConvert.SerializeObject(Father.ConvertDictionary()));
            Console.WriteLine("Hello World!");
            Console.WriteLine("Json转Dic，Dic转Json，支持层级转换");
        }
    }
}
