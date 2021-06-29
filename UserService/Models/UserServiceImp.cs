using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;


namespace UserService.Models
{
    public class UserServiceImp
    {
        private readonly IMongoCollection<User> _users;

        public UserServiceImp(IUserDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.UserDatabaseName);
            _users = database.GetCollection<User>(settings.UserCollectionName);
        }

        public List<User> GetAllUser()
        {
            List<User> users = _users.Find(user => true).ToList();
            return users;
        }

        public User GetUserById(string id)
        {
            User user = _users.Find<User>(user => user.Id == id).FirstOrDefault();
            return user;
        }

        public User AddUser(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public void UpdateUser(User user)
        {
            _users.ReplaceOne(x => x.Id == user.Id, user);
        }

        public void DeleteUser(string id)
        {
            _users.DeleteOne(x => x.Id == id);
        }
    }
}
