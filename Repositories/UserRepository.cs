using JWTPractice.Models;
using System.Collections.Generic;
using System.Linq;

namespace JWTPractice.Repositories
{
    public class UserRepository
    {
        public static UserModel Get(string username, string password)
        {
            var users = new List<UserModel>();
            users.Add(new UserModel { Id = 1, Username = "goku", Password = "***REMOVED***", Role = "manager" });
            users.Add(new UserModel { Id = 2, Username = "vejeta", Password = "***REMOVED***", Role = "employee" });
            users.Add(new UserModel { Id = 3, Username = "kuririn", Password = "***REMOVED***", Role = "tester" });
            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
        }
    }
}
