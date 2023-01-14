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
                return Problem(statusCode: 404, detail: "Не указан login");

            var res = _service.IsUserExists(login);
            if (res.IsFailure)
                return Problem(statusCode: 404, detail: res.Error);

            return Ok(new { IsExists = res.Value });
        }

        [HttpGet("login/{login}")]
        public ActionResult<UserSearchView> GetUserByLogin(string login)
        {

            if (login == string.Empty)
                return Problem(statusCode: 404, detail: "Не указан логин");

            var userRes = _service.GetUserByLogin(login);
            if (userRes.IsFailure)
                return Problem(statusCode: 404, detail: userRes.Error);

            return Ok(new UserSearchView
            {
                Id = userRes.Value.Id,
                Login = userRes.Value.Name,
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
