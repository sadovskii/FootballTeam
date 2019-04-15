using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DAL.EF;
using Backend.DAL.Interfaces.Repositories.Other.MedicalExamination;
using Backend.Infrastructure.Converters.Common.LaboratoryResearch;
using Backend.Views.Common.LaboratoryResearch.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Other.MedicalExamination
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralBloodAnalysisController : ControllerBase
    {
        private readonly IGeneralBloodAnalysisRepository _generalBloodAnalysisRepository;

        public GeneralBloodAnalysisController(ApplicationContext applicationContext, IGeneralBloodAnalysisRepository generalBloodAnalysisRepository)
        {
            _generalBloodAnalysisRepository = generalBloodAnalysisRepository;
        }

        // GET: api/GeneralBloodAnalysis
        [HttpGet]
        public IActionResult GetGeneralBloodAnalysis()
        {
            var elem = _generalBloodAnalysisRepository.GetAll().EntityToView();

            if (elem != null)
                return Ok(elem);

            return NotFound();
        }

        // GET: api/GeneralBloodAnalysis/5
        [HttpGet("{id}")]
        public IActionResult GetGeneralBloodAnalysis(int id)
        {
            if (id == 0)
                return BadRequest("id is zero");

            var elem = _generalBloodAnalysisRepository.GetBy(t => t.Id == id).EntityToView();

            if (elem != null)
                return Ok(elem);

            return NotFound();
        }

        // POST: api/GeneralBloodAnalysis
        [HttpPost]
        public IActionResult PostGeneralBloodAnalysis([FromBody] GeneralBloodAnalysisView generalBloodAnalysis)
        {
            try
            {
                if (generalBloodAnalysis == null)
                {
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                generalBloodAnalysis.Id = 0;
                _generalBloodAnalysisRepository.Insert(generalBloodAnalysis.ViewToEntity());

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        // PUT: api/GeneralBloodAnalysis
        [HttpPut]
        public IActionResult PutGeneralBloodAnalysis(int id, [FromBody] GeneralBloodAnalysisView generalBloodAnalysis)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");

                var elem = _generalBloodAnalysisRepository.GetBy(t => t.Id == generalBloodAnalysis.Id);

                if (elem != null)
                {
                    elem.Info = generalBloodAnalysis.Info;

                    _generalBloodAnalysisRepository.Update(elem);

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
        public IActionResult DeleteGeneralBloodAnalysis(int id)
        {
            var elem = _generalBloodAnalysisRepository.GetBy(t => t.Id == id);

            if (elem != null)
            {
                _generalBloodAnalysisRepository.Delete(elem);
                return Ok();
            }

            return NotFound();
        }
    }
}
