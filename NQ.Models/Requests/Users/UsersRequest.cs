using NQ.Core.Validation;
using NQ.Database.Models;
using System.ComponentModel.DataAnnotations;

namespace NQ.Models.Requests.Users
{
    public class UsersRequest
    {
        [Range(1, 20)]
        public int Take { get; set; }

        [Range(0, double.MaxValue)]
        public int Skip { get; set; }

        [ClassProperty(typeof(User))]
        public string OrderBy { get; set; }

        public bool Desc { get; set; }

        public bool WithFacebookLink { get; set; }
    }
}
