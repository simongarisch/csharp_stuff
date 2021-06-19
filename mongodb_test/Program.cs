// dotnet run
// https://docs.mongodb.com/drivers/
// Also see https://university.mongodb.com/courses/M220N/about
// https://www.mongodb.com/blog/post/quick-start-csharp-and-mongodb--update-operation
using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;


namespace mongodb_test
{
    class Program
    {
        static void Main()
        {
            MongoClient dbClient = new MongoClient("mongodb://localhost:27017");
            var dbList = dbClient.ListDatabases().ToList();

            Console.WriteLine("The list of databases on this server is: ");
            foreach (var db in dbList)
            {
                Console.WriteLine(db.GetType().Name); // BsonDocument
                Console.WriteLine(db);
            }

            InsertExample();
            ReadExample();
            UpdateExample();
        }

        static async void InsertExample() {
            MongoClient dbClient = new MongoClient("mongodb://localhost:27017");
            var db = dbClient.GetDatabase ("test");
            var collection = db.GetCollection<BsonDocument>("trainers");
            var document = new BsonDocument { {"name", "Mike"}, {"age", 28}, {"city", "Mexico"}};
            collection.InsertOne(document);
            await collection.InsertOneAsync (document); // as an alternative

            var document1 = new BsonDocument { {"name", "Jack"}, {"age", 30}, {"city", "Sydney"}};
            var document2 = new BsonDocument { {"name", "Jill"}, {"age", 30}, {"city", "Sydney"}};
            var documents = new List<BsonDocument> {document1, document2};
            collection.InsertMany(documents);
            await collection.InsertManyAsync(documents);
        }

        static void ReadExample() {
            MongoClient dbClient = new MongoClient("mongodb://localhost:27017");
            var db = dbClient.GetDatabase ("test");
            var collection = db.GetCollection<BsonDocument>("trainers");
            var firstDocument = collection.Find(new BsonDocument()).FirstOrDefault();
            Console.WriteLine(firstDocument.ToString());

            var filter = Builders<BsonDocument>.Filter.Eq("city", "Mexico");
            var document = collection.Find(filter).FirstOrDefault();
            Console.WriteLine(document.ToString());

            // read all
            var documents = collection.Find(new BsonDocument()).ToList();
            foreach(var doc in documents) {
                Console.WriteLine(doc);
            }
            Console.WriteLine("=====");
        }

        static void UpdateExample() {
            MongoClient dbClient = new MongoClient("mongodb://localhost:27017");
            var db = dbClient.GetDatabase ("acme");
            var collection = db.GetCollection<BsonDocument>("posts");

            var id = new MongoDB.Bson.ObjectId("60cc471fac613f4194647045");
            var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
            var update = Builders<BsonDocument>.Update.Set("user", "simonx");
            //collection.UpdateOne(filter, update);
        }
    }
}
