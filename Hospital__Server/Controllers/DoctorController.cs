using Hospital.Models;
using Hospital.Servise;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace Hospital__Server.Controllers
{
    [ApiController]
    [Route("doctor")]
    public class DoctorController : ControllerBase
    {
        private readonly DoctorService _service;
        public DoctorController(DoctorService service)
        {
            _service = service;
        }

        [HttpGet("get_idoctor")]
        public ActionResult GetDoctorById(int id)
        {
            var res = _service.GetDoctorById(id);
            if (res.IsFailure)
            {
                return Problem(statusCode: 404, detail: res.Error);
            }
            return Ok(res.Value);
        }

        [HttpGet("all_doctors")]
        public ActionResult GetAllDoctors()
        {
            var res = _service.GetAll();
            if (res.IsFailure)
            {
                return Problem(statusCode: 404, detail: res.Error);
            }
            return Ok(res.Value);
        }


        [HttpPost("create_doctor")]
        public ActionResult CreateDoctor([FromBody] Doctors doctor)
        {
            var res = _service.CreateDoctor(doctor);
            if (res.IsFailure)
                return Problem(statusCode: 404, detail: res.Error);
            _service.Save();

            return Ok(new { Success = true });
        }

        [HttpGet("exist_doctor")]
        public ActionResult IsExists(int id)
        {
            var res = _service.IsDoctorExists(id);
            if (res.IsFailure)
            {
                return Problem(statusCode: 404, detail: res.Error);
            }
            return Ok(res.Value);
        }

        [HttpGet("get_sdoctor")]
        public ActionResult GetDoctorBySpec(Specialization specialization)
        {
            var res = _service.GetDoctorBySpecialization(specialization);
            if (res.IsFailure)
            {
                return Problem(statusCode: 404, detail: res.Error);
            }
            return Ok(res.Value);
        }

        [HttpDelete("delete_doctor")]
        public ActionResult DeleteDoctor(Doctors doctor)
        {
            var doctorRes = _service.DeleteDoctor(doctor);
            if (doctorRes.IsFailure)
            {
                return Problem(statusCode: 404, detail: doctorRes.Error);
            }
            return Ok(doctorRes.Value);
        }

    }
}
