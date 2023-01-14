using Hospital.Models;
using Hospital.Servise;
using Hospital__Server.Views;
using Microsoft.AspNetCore.Mvc;

namespace Hospital__Server.Controllers
{

    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {

        private readonly UserService _service;
        public UserController(UserService service)
        {
            _service = service;
        }

        [HttpGet("is_user")]
        public ActionResult IsUserExists(string login)
        {
            if (login == string.Empty)
                return Problem(statusCode: 404, detail: "Error login");

            var res = _service.IsUserExists(login);
            if (res.IsFailure)
                return Problem(statusCode: 404, detail: res.Error);

            return Ok(new { IsExists = res.Value });
        }

        [HttpGet("login_user")]
        public ActionResult<UserSearchView> GetUserByLogin(string login)
        {

            if (login == string.Empty)
                return Problem(statusCode: 404, detail: "Error login");

            var res = _service.GetUserByLogin(login);
            if (res.IsFailure)
                return Problem(statusCode: 404, detail: res.Error);

            return Ok(new UserSearchView
            {
                Id = res.Value.Id,
                Login = res.Value.Name,
            });
        }

        [HttpPost("reg")]
        public ActionResult Register([FromBody] User user)
        {
            var res = _service.Register(user);
            if (res.IsFailure)
                return Problem(statusCode: 404, detail: res.Error);
            _service.Save();

            return Ok(new { Success = true });
        }
    }
}
