using System;
using System.Linq.Expressions;
using MongoDB.Driver;

namespace MongoDatabase
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var Client = new MongoClient("mongodb://localhost:27017");
            
            Console.WriteLine(Client.Cluster.ClusterId.Value);
            
            Console.WriteLine("Works");
            
            Console.ReadLine();
        }
    }
}