using Hospital.Models;
using Hospital.Servise;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using System.Xml;

namespace Hospital__Server.Controllers
{

    [ApiController]
    [Route("shedule")]
    public class SheduleController : ControllerBase
    {

        private readonly SheduleService _service;
        public SheduleController(SheduleService service)
        {
            _service = service;
        }

        [HttpPost("creat_shedule")]
        public ActionResult CreateShedule(int doctorId, DateTime start_Time, DateTime end_Time)
        {
            Shedule timeTable = new Shedule(0, start_Time, end_Time);
            var res = _service.CreateShedule(timeTable);
            if (res.IsFailure)
            {
                return Problem(statusCode: 404, detail: res.Error);
            }
            return Ok(res.Value);
        }

        [HttpPut("update_shedule")]
        public ActionResult UpdateShedule(int id, DateTime start_Time, DateTime end_Time)
        {
            var res = _service.UpdateShedule(new Shedule(id, start_Time, end_Time));
            if (res.IsFailure)
            {
                return Problem(statusCode: 404, detail: res.Error);
            }
            return Ok(res.Value);
        }

        [HttpGet("get_shedule")]
        public ActionResult GetAll (Doctors doctor, DateTime date)
        {
            var answer = _service.GetSheduleTableByDoctorAndDate(doctor, date);
            if (answer.IsFailure)
                return Problem(statusCode: 404, detail: answer.Error);

            return Ok(answer.Value);
        }
    }
}
