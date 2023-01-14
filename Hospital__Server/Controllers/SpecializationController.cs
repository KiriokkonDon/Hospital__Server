using Hospital.Models;
using Hospital.Servise;
using Microsoft.AspNetCore.Mvc;

namespace Hospital__Server.Controllers
{

    [ApiController]
    [Route("specialization")]
    public class SpecializationController : ControllerBase
    {

        private readonly SpecializationService _service;
        public SpecializationController(SpecializationService service)
        {
            _service = service;
        }

        [HttpGet("all_specialization")]
        public ActionResult GetSpecs()
        {

            var res = _service.GetAllSpecializations();
            if (res.IsFailure)
                return Problem(statusCode: 404, detail: res.Error);

            return Ok(res.Value);
        }
        [HttpPost("reg_spec")]
        public ActionResult Register([FromBody] Specialization spec)
        {
            var res = _service.Create(spec);
            if (res.IsFailure)
                return Problem(statusCode: 404, detail: res.Error);
            _service.Save();

            return Ok(new { Success = true });
        }

        [HttpGet("get_spec")]
        public ActionResult GetSpecByName(string name)
        {
            var res = _service.GetSpecByName(name);
            if (res.IsFailure)
                return Problem(statusCode: 404, detail: res.Error);

            return Ok(res.Value);
        }
        [HttpGet("spec_exist")]
        public ActionResult IsExists(string name)
        {
            var res = _service.IsSpecExists(name);
            if (res.IsFailure)
            {
                return Problem(statusCode: 404, detail: res.Error);
            }
            return Ok(res.Value);
        }
    }
}
