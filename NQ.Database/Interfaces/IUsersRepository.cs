using NQ.Database.Models;
using System.Collections.Generic;

namespace NQ.Database.Interfaces
{
    public interface IUsersRepository : IRepository<User>
    {
        IEnumerable<User> GetWithFacebookLink(IEnumerable<User> filtered = default);
    }
}
