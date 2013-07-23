using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.IO;

namespace InputJSONDataFromFilesInMongo
{
    public static class FileManager
    {
        public static MongoDatabase db
        {
            get
            {
                var connectionstring = "mongodb://localhost";
                MongoServer dbServer = new MongoClient(connectionstring).GetServer();
                MongoDatabase dbConnection = dbServer.GetDatabase("vendor");
                return dbConnection;
            }
        }

        public static void InputJSONData(string directoryPath)
        {
            DirectoryInfo directory = new DirectoryInfo(directoryPath);
            foreach (var file in directory.GetFiles())
            {
                if (file.Extension == ".json")
                {
                    string json = File.ReadAllText(file.DirectoryName);
                    BsonDocument document = BsonSerializer.Deserialize<BsonDocument>(json);
                    db.GetCollection<Product>("reports").Save(document);
                }
            }
        }
    }
}
