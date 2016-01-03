using EmpMgmtByMongo.Models;
using MongoDB.Driver;

namespace EmpMgmtByMongo.MongoHelper
{
    public class MongoInstance
    {
        private static IMongoCollection<Employee> _employeeCollection;
        public static IMongoCollection<Employee> EmployeeCollection
        {
            get {
                var client = new MongoClient("mongodb://localhost:27017");
                var database = client.GetDatabase("EmpDB"); //Get database if not exist it will create "EmpDB" database
                _employeeCollection = database.GetCollection<Employee>("EmpRecord"); //Get Collection (aka table) from database if not exist it will create "EmpRecord" database
                return _employeeCollection;
                }
        }
    }
}
