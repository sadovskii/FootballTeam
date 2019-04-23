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
    public class GeneralUrineAnalysisController : ControllerBase
    {
        private readonly IGeneralUrineAnalysisRepository _generalUrineAnalysisRepository;

        public GeneralUrineAnalysisController(ApplicationContext applicationContext, IGeneralUrineAnalysisRepository generalUrineAnalysisRepository)
        {
            _generalUrineAnalysisRepository = generalUrineAnalysisRepository;
        }

        // GET: api/GeneralUrineAnalysis
        [HttpGet]
        public IActionResult GetGeneralUrineAnalysis()
        {
            var elem = _generalUrineAnalysisRepository.GetAll().EntityToView();

            if (elem != null)
                return Ok(elem);

            return NotFound();
        }

        // GET: api/GeneralUrineAnalysis/5
        [HttpGet("{id}")]
        public IActionResult GetGeneralUrineAnalysis(int id)
        {
            if (id == 0)
                return BadRequest("id is zero");

            var elem = _generalUrineAnalysisRepository.GetBy(t => t.Id == id).EntityToView();

            if (elem != null)
                return Ok(elem);

            return NotFound();
        }

        // POST: api/GeneralUrineAnalysis
        [HttpPost]
        public IActionResult PostGeneralUrineAnalysis([FromBody] GeneralUrineAnalysisView GeneralUrineAnalysis)
        {
            try
            {
                if (GeneralUrineAnalysis == null)
                {
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                GeneralUrineAnalysis.Id = 0;
                _generalUrineAnalysisRepository.Insert(GeneralUrineAnalysis.ViewToEntity());

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        // PUT: api/GeneralUrineAnalysis/5
        [HttpPut("{id}")]
        public IActionResult PutGeneralUrineAnalysis(int id, [FromBody] GeneralUrineAnalysisView GeneralUrineAnalysis)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");

                var elem = _generalUrineAnalysisRepository.GetBy(t => t.Id == GeneralUrineAnalysis.Id);

                if (elem != null)
                {
                    elem.Info = GeneralUrineAnalysis.Info;

                    _generalUrineAnalysisRepository.Update(elem);

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
        public IActionResult DeleteGeneralUrineAnalysis(int id)
        {
            var elem = _generalUrineAnalysisRepository.GetBy(t => t.Id == id);

            if (elem != null)
            {
                _generalUrineAnalysisRepository.Delete(elem);
                return Ok();
            }

            return NotFound();
        }
    }
}
