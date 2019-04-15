using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DAL.EF;
using Backend.DAL.Interfaces.Repositories.Other.GeneralInformation;
using Backend.Infrastructure.Converters.GeneralInformationConverters;
using Backend.Views.GeneralInformationEntities.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Other.GeneralInformation
{
    [Route("api/[controller]")]
    [ApiController]
    public class FluorographyController : ControllerBase
    {
        private readonly IFluorographyRepository _fluorographyRepository;

        public FluorographyController(ApplicationContext applicationContext, IFluorographyRepository fluorographyRepository)
        {
            _fluorographyRepository = fluorographyRepository;
        }

        // GET: api/Fluorography
        [HttpGet]
        public IActionResult GetFluorography()
        {
            var elem = _fluorographyRepository.GetAll().EntityToView();

            if (elem != null)
                return Ok(elem);

            return NotFound();
        }

        // GET: api/Fluorography/5
        [HttpGet("{id}")]
        public IActionResult GetFluorography(int id)
        {
            if (id == 0)
                return BadRequest("id is zero");

            var elem = _fluorographyRepository.GetBy(t => t.Id == id).EntityToView();

            if (elem != null)
                return Ok(elem);

            return NotFound();
        }

        // POST: api/Fluorography
        [HttpPost]
        public IActionResult PostFluorography([FromBody] FluorographyView fluorography)
        {
            try
            {
                if (fluorography == null)
                {
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                fluorography.Id = 0;
                _fluorographyRepository.Insert(fluorography.ViewToEntity());

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        // PUT: api/Fluorography
        [HttpPut]
        public IActionResult PutFluorography([FromBody] FluorographyView fluorography)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");

                var elem = _fluorographyRepository.GetBy(t => t.Id == fluorography.Id);

                if (elem != null)
                {
                    elem.Information = fluorography.Information;
                    elem.ProcedureTime = fluorography.ProcedureTime;

                    _fluorographyRepository.Update(elem);

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
        public IActionResult DeleteFluorography(int id)
        {
            var elem = _fluorographyRepository.GetBy(t => t.Id == id);

            if (elem != null)
            {
                _fluorographyRepository.Delete(elem);
                return Ok();
            }

            return NotFound();
        }
    }
}
