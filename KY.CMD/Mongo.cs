using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace KY.CMD
{
    public  class MongoHelp
    {
        public void SaveMong<T>(T t )
        {
            IMongoClient mongo = new MongoClient("mongodb://127.0.0.1:27018");
            IMongoDatabase db = mongo.GetDatabase("xiangsonglin");
            var collection = db.GetCollection<T>("yoyoyo");
            collection.InsertOne(t);
        }

        //public IEnumerable<T> Find<T>(Dictionary<string,object> keyValues)
        //{
        //    IMongoClient mongo = new MongoClient("mongodb://127.0.0.1:27018");
        //    IMongoDatabase db = mongo.GetDatabase("mydata");
        //    var collection = db.GetCollection<T>("yuchun");
        //    var builder = Builders<T>.Filter;
        //    foreach (var item in keyValues)
        //    {

        //    }
        //   return  collection.Find<T>(a=>a.GetType().GetProperty);
        //}

        public void Test() {
            Console.WriteLine("测试");
        }
    }
}
