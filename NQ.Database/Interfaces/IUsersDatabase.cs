using NQ.Database.Models;
using System.Collections.Generic;

namespace NQ.Database.Interfaces
{
    public interface IUsersDatabase
    {
        IEnumerable<User> GetUsers();
    }
}
