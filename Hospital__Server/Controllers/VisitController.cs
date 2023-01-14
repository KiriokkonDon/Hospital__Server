using Hospital.Models;
using Hospital.Servise;
using Hospital__Server.Model;
using Microsoft.AspNetCore.Mvc;

namespace Hospital__Server.Controllers
{

    [ApiController]
    [Route("visit")]
    public class VisitController : ControllerBase
    {

        private readonly VisitService _service;
        public VisitController(VisitService service)
        {
            _service = service;
        }

        [HttpPost("create_visit")]
        public ActionResult CreateVisit([FromBody] VisitCreat app)
        {
            var answer = _service.CreateVisit(app.user, app.doctor);
            if (answer.IsFailure)
                return Problem(statusCode: 404, detail: answer.Error);

            return Ok(answer.Value);
        }


    }
}
