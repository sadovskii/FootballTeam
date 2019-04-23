using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DAL.EF;
using Backend.DAL.Interfaces.Repositories.Other.MedicalExamination;
using Backend.Infrastructure.Converters.Common.LaboratoryResearch;
using Backend.Views.Common.LaboratoryResearch.Components;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Other.MedicalExamination
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodChemistryAnalysisController : ControllerBase
    {
        private readonly IBloodChemistryAnalysisRepository _bloodChemistryAnalysisRepository;

        public BloodChemistryAnalysisController(ApplicationContext applicationContext, IBloodChemistryAnalysisRepository bloodChemistryAnalysisRepository)
        {
            _bloodChemistryAnalysisRepository = bloodChemistryAnalysisRepository;
        }

        // GET: api/BloodChemistryAnalysis
        [HttpGet]
        public IActionResult GetHeartUltrasound()
        {
            var elem = _bloodChemistryAnalysisRepository.GetAll().EntityToView();

            if (elem != null)
                return Ok(elem);

            return NotFound();
        }

        // GET: api/BloodChemistryAnalysis/5
        [HttpGet("{id}")]
        public IActionResult GetHeartUltrasound(int id)
        {
            if (id == 0)
                return BadRequest("id is zero");

            var elem = _bloodChemistryAnalysisRepository.GetBy(t => t.Id == id).EntityToView();

            if (elem != null)
                return Ok(elem);

            return NotFound();
        }

        // POST: api/BloodChemistryAnalysis
        [HttpPost]
        public IActionResult PostHeartUltrasound([FromBody] BloodChemistryAnalysisView bloodChemistryAnalysis)
        {
            try
            {
                if (bloodChemistryAnalysis == null)
                {
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                bloodChemistryAnalysis.Id = 0;
                _bloodChemistryAnalysisRepository.Insert(bloodChemistryAnalysis.ViewToEntity());

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        // PUT: api/BloodChemistryAnalysis
        [HttpPut]
        public IActionResult PutHeartUltrasound([FromBody] BloodChemistryAnalysisView bloodChemistryAnalysis)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");

                var elem = _bloodChemistryAnalysisRepository.GetBy(t => t.Id == bloodChemistryAnalysis.Id);

                if (elem != null)
                {
                    elem.Info = bloodChemistryAnalysis.Info;

                    _bloodChemistryAnalysisRepository.Update(elem);

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
        public IActionResult DeleteHeartUltrasound(int id)
        {
            var elem = _bloodChemistryAnalysisRepository.GetBy(t => t.Id == id);

            if (elem != null)
            {
                _bloodChemistryAnalysisRepository.Delete(elem);
                return Ok();
            }

            return NotFound();
        }
    }
}
