using NQ.Core.Extensions;
using NQ.Database.Interfaces;
using NQ.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NQ.Database.Services
{
    public class UsersRepository : IUsersRepository
    {
        IUsersDatabase _database;

        public UsersRepository(IUsersDatabase database)
        {
            _database = database;
        }

        public IEnumerable<User> GetPaged(int take, int skip, IEnumerable<User> filtered = default)
        {
            return GetFilteredOrDatabase(filtered).Skip(skip).Take(take);
        }

        public IEnumerable<User> GetWithFacebookLink(IEnumerable<User> filtered = default)
        {
            return GetFilteredOrDatabase(filtered).Where(x => string.IsNullOrWhiteSpace(x.FacebookLink) == false);
        }

        public IEnumerable<User> Sort(string columnName, bool desc, IEnumerable<User> filtered = default)
        {
            if (columnName?.Equals(nameof(User.Id), StringComparison.OrdinalIgnoreCase) == true)
                throw new NotImplementedException($"Sotring by column '{nameof(User.Id)}' not implemented.");

            var selector = ExpressionExtensions.CreatePropertyAccessor<User, string>(columnName);

            if (desc)
                return GetFilteredOrDatabase(filtered).OrderByDescending(selector);
            else
                return GetFilteredOrDatabase(filtered).OrderBy(selector);
        }

        private IEnumerable<User> GetFilteredOrDatabase(IEnumerable<User> filtered)
        {
            if (filtered == default)
                return _database.GetUsers();
            else
                return filtered;
        }
    }
}
