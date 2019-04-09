using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DAL.EF;
using Backend.DAL.Entities.Common.InstrumentalStudies;
using Backend.DAL.Entities.Common.LaboratoryResearch;
using Backend.DAL.Entities.MedicalExaminationEntities;
using Backend.DAL.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
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
        public IEnumerable<MedicalExamination> GetMedicalExamination()
        {
            return _medicalExaminationRepository.GetAll();
        }

        // GET: api/MedicalExamination/5
        [HttpGet("{id}")]
        public MedicalExamination GetMedicalExamination(int id)
        {
            return _medicalExaminationRepository.GetBy(t => t.Id == id);
        }

        // GET: api/Patients/5/DoctorsDiagnosis
        [HttpGet("{id}/DoctorsDiagnosis", Name = "GetDoctorsDiagnosis")]
        public List<DoctorsDiagnosis> GetDoctorsDiagnosis(int id)
        {
            return _medicalExaminationRepository.GetDoctorsDiagnosisById(id);
        }

        // GET: api/Patients/5/BloodChemistryAnalysis
        [HttpGet("{id}/BloodChemistryAnalysis", Name = "GetBloodChemistryAnalysis")]
        public List<BloodChemistryAnalysis> GetBloodChemistryAnalysis(int id)
        {
            return _medicalExaminationRepository.GetBloodChemistryAnalysisById(id);
        }

        // GET: api/Patients/5/GeneralBloodAnalysis
        [HttpGet("{id}/GeneralBloodAnalysis", Name = "GetGeneralBloodAnalysis")]
        public List<GeneralBloodAnalysis> GetGeneralBloodAnalysis(int id)
        {
            return _medicalExaminationRepository.GetGeneralBloodAnalysisById(id);
        }

        // GET: api/Patients/5/GeneralUrineAnalysis
        [HttpGet("{id}/GeneralUrineAnalysis", Name = "GetGeneralUrineAnalysis")]
        public List<GeneralUrineAnalysis> GetGeneralUrineAnalysis(int id)
        {
            return _medicalExaminationRepository.GetGeneralUrineAnalysisById(id);
        }

        // GET: api/Patients/5/HeartUltrasound
        [HttpGet("{id}/HeartUltrasound", Name = "GetHeartUltrasound")]
        public List<HeartUltrasound> GetHeartUltrasound(int id)
        {
            return _medicalExaminationRepository.GetHeartUltrasoundById(id);
        }

        // GET: api/Patients/5/Electrocardiogram
        [HttpGet("{id}/Electrocardiogram", Name = "GetElectrocardiogram")]
        public List<Electrocardiogram> GetElectrocardiogram(int id)
        {
            return _medicalExaminationRepository.GetElectrocardiogramById(id);
        }
        #endregion

        // POST: api/MedicalExamination
        [HttpPost]
        public void Post([FromBody] MedicalExamination medicalExamination)
        {
            _medicalExaminationRepository.Insert(medicalExamination);
        }

        // POST: api/Patients/5/DoctorsDiagnosis
        [HttpPost("{id}/DoctorsDiagnosis")]
        public void PostWithDoctorsDiagnosis(int id, [FromBody] DoctorsDiagnosis doctorsDiagnosis)
        {
            _medicalExaminationRepository.InsertDoctorsDiagnosis(id, doctorsDiagnosis);
        }

        // POST: api/Patients/5/BloodChemistryAnalysis
        [HttpPost("{id}/BloodChemistryAnalysis")]
        public void PostWithBloodChemistryAnalysis(int id, [FromBody] BloodChemistryAnalysis bloodChemistryAnalysis)
        {
            _medicalExaminationRepository.InsertBloodChemistryAnalysis(id, bloodChemistryAnalysis);
        }

        // POST: api/Patients/5/GeneralBloodAnalysis
        [HttpPost("{id}/GeneralBloodAnalysis")]
        public void PostWithGeneralBloodAnalysis(int id, [FromBody] GeneralBloodAnalysis generalBloodAnalysis)
        {
            _medicalExaminationRepository.InsertGeneralBloodAnalysis(id, generalBloodAnalysis);
        }

        // POST: api/Patients/5/GeneralUrineAnalysis
        [HttpPost("{id}/GeneralUrineAnalysis")]
        public void PostWithGeneralUrineAnalysis(int id, [FromBody] GeneralUrineAnalysis generalUrineAnalysis)
        {
            _medicalExaminationRepository.InsertGeneralUrineAnalysis(id, generalUrineAnalysis);
        }

        // POST: api/Patients/5/HeartUltrasound
        [HttpPost("{id}/HeartUltrasound")]
        public void PostWithHeartUltrasound(int id, [FromBody] HeartUltrasound heartUltrasound)
        {
            _medicalExaminationRepository.InsertHeartUltrasound(id, heartUltrasound);
        }

        // POST: api/Patients/5/Electrocardiogram
        [HttpPost("{id}/Electrocardiogram")]
        public void PostWithElectrocardiogram(int id, [FromBody] Electrocardiogram electrocardiogram)
        {
            _medicalExaminationRepository.InsertElectrocardiogram(id, electrocardiogram);
        }

        // PUT: api/MedicalExamination/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] MedicalExamination medicalExamination)
        {
            try
            {
                _medicalExaminationRepository.Update(medicalExamination);
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
        }
    }
}
