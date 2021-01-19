using Microsoft.AspNetCore.Mvc;
using NQ.Database.Interfaces;
using NQ.Database.Models;
using NQ.Models.Requests.Users;
using System.Collections.Generic;

namespace NQ.Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : NQControllerBase
    {
        IUsersRepository _usersRepository;

        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [HttpGet]
        public IActionResult Get([FromQuery]UsersRequest request)
        {
            return ExecuteAction(() =>
            {
                IEnumerable<User> result = null;

                if (request.WithFacebookLink)
                    result = _usersRepository.GetWithFacebookLink(result);

                if (!string.IsNullOrWhiteSpace(request.OrderBy))
                    result = _usersRepository.Sort(request.OrderBy, request.Desc, result);

                return _usersRepository.GetPaged(request.Take, request.Skip, result);
            });
        }
    }
}
