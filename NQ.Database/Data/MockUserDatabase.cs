using NQ.Database.Interfaces;
using NQ.Database.Models;
using System.Collections.Generic;

namespace NQ.Database.Data
{
    public class MockUserDatabase : IUsersDatabase
    {
        List<User> _users;

        public MockUserDatabase(List<User> users)
        {
            _users = users;
        }

        public IEnumerable<User> GetUsers() => _users;
    }
}
