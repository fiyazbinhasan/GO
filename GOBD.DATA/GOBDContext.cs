using System.Configuration;
using GOBD.MODEL;
using MongoDB.Driver;

namespace GOBD.DATA
{
    public class GOBDContext
    {

        public MongoDatabase Database;

        public MongoCollection<Location> Locations
        {
            get { return Database.GetCollection<Location>("Locations"); }
        }

        public GOBDContext()
        {
            var mongoClient = new MongoClient(ConnectionStringName);
            var mongoServer = mongoClient.GetServer();
            Database = mongoServer.GetDatabase(DatabaseName);
        }
        public static string ConnectionStringName
        {
            get
            {
                if (ConfigurationManager.AppSettings["OnlineConnection"] != null)
                {
                    var connectionStringKey = ConfigurationManager.AppSettings["OnlineConnection"];
                    var connectionStringValue = ConfigurationManager.ConnectionStrings[connectionStringKey].ConnectionString;
                    return connectionStringValue;
                }
                if (ConfigurationManager.AppSettings["DefaultConnection"] != null)
                {
                    var connectionStringKey = ConfigurationManager.AppSettings["DefaultConnection"];
                    var connectionStringValue = ConfigurationManager.ConnectionStrings[connectionStringKey].ConnectionString;
                    return connectionStringValue;
                }
                throw new MongoConnectionException("MongoDB connection not found");
            }
        }
        public static string DatabaseName
        {
            get
            {
                if (ConfigurationManager.AppSettings["DatabaseName"] != null)
                {
                    var datbaseNameKey = ConfigurationManager.AppSettings["DatabaseName"];
                    var datbaseNameValue = ConfigurationManager.ConnectionStrings[datbaseNameKey].ConnectionString;
                    return datbaseNameValue;
                }
                throw new MongoConnectionException("No database found");
            }
        }

    }
}
