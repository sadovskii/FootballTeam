using System;
using Backend.DAL.EF;
using Backend.DAL.Interfaces.Repositories;
using Backend.Infrastructure.Converters.Common.InstrumentalStudies;
using Backend.Infrastructure.Converters.Common.LaboratoryResearch;
using Backend.Infrastructure.Converters.MedicalExaminationConverters;
using Backend.Views.Common.InstrumentalStudies.Components;
using Backend.Views.Common.LaboratoryResearch.Components;
using Backend.Views.MedicalExaminationEntities.Components;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Main
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalExaminationController : ControllerBase
    {
        IMedicalExaminationRepository _medicalExaminationRepository;

        public MedicalExaminationController(ApplicationContext applicationContext, IMedicalExaminationRepository medicalExaminationRepository)
        {
            _medicalExaminationRepository = medicalExaminationRepository;
        }

        #region GET
        // GET: api/MedicalExamination
        [HttpGet]
        public IActionResult GetMedicalExamination()
        {
            var elem = _medicalExaminationRepository.GetAll().EntityToView();

            if (elem != null)
                return Ok(elem);

            return NotFound();
        }

        // GET: api/MedicalExamination/5
        [HttpGet("{id}")]
        public IActionResult GetMedicalExamination(int id)
        {
            if (id == 0)
                return BadRequest("id is zero");

            var elem = _medicalExaminationRepository.GetBy(t => t.Id == id).EntityToView();

            if (elem != null)
                return Ok(elem);

            return NotFound();
        }

        // GET: api/Patients/5/DoctorsDiagnosis
        [HttpGet("{id}/DoctorsDiagnosis")]
        public IActionResult GetDoctorsDiagnosis(int id)
        {
            if (id == 0)
                return BadRequest("id is zero");

            var elem = _medicalExaminationRepository.GetDoctorsDiagnosisById(id).EntityToView();

            if (elem != null && elem != null)
                return Ok(elem);

            return NotFound();
        }

        // GET: api/Patients/5/BloodChemistryAnalysis
        [HttpGet("{id}/BloodChemistryAnalysis")]
        public IActionResult GetBloodChemistryAnalysis(int id)
        {
            if (id == 0)
                return BadRequest("id is zero");

            var elem = _medicalExaminationRepository.GetBloodChemistryAnalysisById(id).EntityToView();

            if (elem != null && elem != null)
                return Ok(elem);

            return NotFound();
        }

        // GET: api/Patients/5/GeneralBloodAnalysis
        [HttpGet("{id}/GeneralBloodAnalysis")]
        public IActionResult GetGeneralBloodAnalysis(int id)
        {
            if (id == 0)
                return BadRequest("id is zero");

            var elem = _medicalExaminationRepository.GetGeneralBloodAnalysisById(id).EntityToView();

            if (elem != null && elem != null)
                return Ok(elem);

            return NotFound();
        }

        // GET: api/Patients/5/GeneralUrineAnalysis
        [HttpGet("{id}/GeneralUrineAnalysis")]
        public IActionResult GetGeneralUrineAnalysis(int id)
        {
            if (id == 0)
                return BadRequest("id is zero");

            var elem = _medicalExaminationRepository.GetGeneralUrineAnalysisById(id).EntityToView();

            if (elem != null && elem != null)
                return Ok(elem);

            return NotFound();
        }

        // GET: api/Patients/5/HeartUltrasound
        [HttpGet("{id}/HeartUltrasound")]
        public IActionResult GetHeartUltrasound(int id)
        {
            if (id == 0)
                return BadRequest("id is zero");

            var elem = _medicalExaminationRepository.GetHeartUltrasoundById(id).EntityToView();

            if (elem != null && elem != null)
                return Ok(elem);

            return NotFound();
        }

        // GET: api/Patients/5/Electrocardiogram
        [HttpGet("{id}/Electrocardiogram")]
        public IActionResult GetElectrocardiogram(int id)
        {
            if (id == 0)
                return BadRequest("id is zero");

            var elem = _medicalExaminationRepository.GetElectrocardiogramById(id).EntityToView();

            if (elem != null && elem != null)
                return Ok(elem);

            return NotFound();
        }
        #endregion

        // POST: api/MedicalExamination
        [HttpPost]
        public IActionResult Post([FromBody] MedicalExaminationView medicalExaminationView)
        {
            try
            {
                if (medicalExaminationView == null)
                {
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                _medicalExaminationRepository.Insert(medicalExaminationView.ViewToEntity());

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        // POST: api/Patients/5/DoctorsDiagnosis
        [HttpPost("{id}/DoctorsDiagnosis")]
        public IActionResult PostWithDoctorsDiagnosis(int id, [FromBody] DoctorsDiagnosisView doctorsDiagnosisView)
        {
            try
            {

                if (id == 0)
                {
                    return BadRequest("id is zero");
                }
                if (doctorsDiagnosisView == null)
                {
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                _medicalExaminationRepository.InsertDoctorsDiagnosis(id, doctorsDiagnosisView.ViewToEntity());

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, string.Format("Internal server error. Message error: {0}", ex.Message));
            }
        }

        // POST: api/Patients/5/BloodChemistryAnalysis
        [HttpPost("{id}/BloodChemistryAnalysis")]
        public IActionResult PostWithBloodChemistryAnalysis(int id, [FromBody] BloodChemistryAnalysisView bloodChemistryAnalysisView)
        {
            try
            {

                if (id == 0)
                {
                    return BadRequest("id is zero");
                }
                if (bloodChemistryAnalysisView == null)
                {
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                _medicalExaminationRepository.InsertBloodChemistryAnalysis(id, bloodChemistryAnalysisView.ViewToEntity());

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, string.Format("Internal server error. Message error: {0}", ex.Message));
            }
        }

        // POST: api/Patients/5/GeneralBloodAnalysis
        [HttpPost("{id}/GeneralBloodAnalysis")]
        public IActionResult PostWithGeneralBloodAnalysis(int id, [FromBody] GeneralBloodAnalysisView generalBloodAnalysisView)
        {
            try
            {

                if (id == 0)
                {
                    return BadRequest("id is zero");
                }
                if (generalBloodAnalysisView == null)
                {
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                _medicalExaminationRepository.InsertGeneralBloodAnalysis(id, generalBloodAnalysisView.ViewToEntity());

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, string.Format("Internal server error. Message error: {0}", ex.Message));
            }
        }

        // POST: api/Patients/5/GeneralUrineAnalysis
        [HttpPost("{id}/GeneralUrineAnalysis")]
        public IActionResult PostWithGeneralUrineAnalysis(int id, [FromBody] GeneralUrineAnalysisView generalUrineAnalysisView)
        {
            try
            {

                if (id == 0)
                {
                    return BadRequest("id is zero");
                }
                if (generalUrineAnalysisView == null)
                {
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                _medicalExaminationRepository.InsertGeneralUrineAnalysis(id, generalUrineAnalysisView.ViewToEntity());

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, string.Format("Internal server error. Message error: {0}", ex.Message));
            }
        }

        // POST: api/Patients/5/HeartUltrasound
        [HttpPost("{id}/HeartUltrasound")]
        public IActionResult PostWithHeartUltrasound(int id, [FromBody] HeartUltrasoundView heartUltrasoundView)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("id is zero");
                }
                if (heartUltrasoundView == null)
                {
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                _medicalExaminationRepository.InsertHeartUltrasound(id, heartUltrasoundView.ViewToEntity());

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, string.Format("Internal server error. Message error: {0}", ex.Message));
            }
        }

        // POST: api/Patients/5/Electrocardiogram
        [HttpPost("{id}/Electrocardiogram")]
        public IActionResult PostWithElectrocardiogram(int id, [FromBody] ElectrocardiogramView electrocardiogramView)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("id is zero");
                }
                if (electrocardiogramView == null)
                {
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                _medicalExaminationRepository.InsertElectrocardiogram(id, electrocardiogramView.ViewToEntity());

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, string.Format("Internal server error. Message error: {0}", ex.Message));
            }
        }

        // PUT: api/MedicalExamination/5
        [HttpPut]
        public IActionResult Put(int id, [FromBody] MedicalExaminationView medicalExaminationView)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");

                _medicalExaminationRepository.Update(medicalExaminationView.ViewToEntity());
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _medicalExaminationRepository.Delete(id);
        }
    }
}
