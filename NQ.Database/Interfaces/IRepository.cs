using System.Collections.Generic;

namespace NQ.Database.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetPaged(int take, int skip, IEnumerable<T> filtered = default);

        IEnumerable<T> Sort(string columnName, bool desc, IEnumerable<T> filtered = default);
    }
}
