using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DAL.EF;
using Backend.DAL.Interfaces.Repositories.Other.MedicalExamination;
using Backend.Infrastructure.Converters.MedicalExaminationConverters;
using Backend.Views.MedicalExaminationEntities.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Other.MedicalExamination
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsDiagnosisController : ControllerBase
    {
        private readonly IDoctorsDiagnosisRepository _doctorsDiagnosisRepository;

        public DoctorsDiagnosisController(ApplicationContext applicationContext, IDoctorsDiagnosisRepository doctorsDiagnosisRepository)
        {
            _doctorsDiagnosisRepository = doctorsDiagnosisRepository;
        }

        // GET: api/DoctorsDiagnosis
        [HttpGet]
        public IActionResult GetDoctorsDiagnosis()
        {
            var elem = _doctorsDiagnosisRepository.GetAll().EntityToView();

            if (elem != null)
                return Ok(elem);

            return NotFound();
        }

        // GET: api/DoctorsDiagnosis/5
        [HttpGet("{id}")]
        public IActionResult GetDoctorsDiagnosis(int id)
        {
            if (id == 0)
                return BadRequest("id is zero");

            var elem = _doctorsDiagnosisRepository.GetBy(t => t.Id == id).EntityToView();

            if (elem != null)
                return Ok(elem);

            return NotFound();
        }

        // POST: api/DoctorsDiagnosis
        [HttpPost]
        public IActionResult PostDoctorsDiagnosis([FromBody] DoctorsDiagnosisView doctorsDiagnosis)
        {
            try
            {
                if (doctorsDiagnosis == null)
                {
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                doctorsDiagnosis.Id = 0;
                _doctorsDiagnosisRepository.Insert(doctorsDiagnosis.ViewToEntity());

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        // PUT: api/DoctorsDiagnosis
        [HttpPut]
        public IActionResult PutDoctorsDiagnosis([FromBody] DoctorsDiagnosisView doctorsDiagnosis)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");

                var elem = _doctorsDiagnosisRepository.GetBy(t => t.Id == doctorsDiagnosis.Id);

                if (elem != null)
                {
                    elem.Diagnosis = doctorsDiagnosis.Diagnosis;
                    elem.MedicalProfessionId = (int)doctorsDiagnosis.MedicalProfession;

                    _doctorsDiagnosisRepository.Update(elem);

                    return Ok();
                }

                return NotFound();

            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult DeleteDoctorsDiagnosis(int id)
        {
            var elem = _doctorsDiagnosisRepository.GetBy(t => t.Id == id);

            if (elem != null)
            {
                _doctorsDiagnosisRepository.Delete(elem);
                return Ok();
            }

            return NotFound();
        }
    }
}
