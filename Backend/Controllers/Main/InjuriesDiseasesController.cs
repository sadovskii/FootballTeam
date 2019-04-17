﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.BLL.Interfaces;
using Backend.DAL.Entities.Common.InstrumentalStudies;
using Backend.DAL.Entities.InjuriesDiseasesEntities;
using Backend.DAL.Interfaces.Repositories;
using Backend.Infrastructure.Converters.Common.InstrumentalStudies;
using Backend.Infrastructure.Converters.InjuriesDiseasesConverters;
using Backend.Infrastructure.Helpers;
using Backend.Views.Common.InstrumentalStudies.Components;
using Backend.Views.Components.Common.InstrumentalStudies;
using Backend.Views.InjuriesDiseasesEntities.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Main
{
    [Route("api/[controller]")]
    [ApiController]
    public class InjuriesDiseasesController : ControllerBase
    {
        IInjuriesDiseasesRepository _injuriesDiseasesRepository;
        private readonly UploadFileAndSavePath _uploadFileAndSavePath;

        public InjuriesDiseasesController(IInjuriesDiseasesRepository injuriesDiseasesRepository, IImageHandler imageHandler)
        {
            _injuriesDiseasesRepository = injuriesDiseasesRepository;
            _uploadFileAndSavePath = new UploadFileAndSavePath(imageHandler);
        }

        // GET: api/InjuriesDiseases
        [HttpGet]
        public IActionResult GetInjuriesDiseases()
        {
            var elem = _injuriesDiseasesRepository.GetAll().EntityToView();

            if (elem != null)
                return Ok(elem);

            return NotFound();
        }

        // GET: api/InjuriesDiseases/5
        [HttpGet("{id}")]
        public IActionResult GetInjuriesDiseases(int id)
        {
            if (id == 0)
                return BadRequest("id is zero");

            var elem = _injuriesDiseasesRepository.GetBy(t => t.Id == id).EntityToView();

            if (elem != null)
                return Ok(elem);

            return NotFound();
        }

        // GET: api/InjuriesDiseases/5/MRIs
        [HttpGet("{id}/MRIs")]
        public IActionResult GetWithMRI(int id)
        {
            if (id == 0)
                return BadRequest("id is zero");

            var elem = _injuriesDiseasesRepository.GetMRIById(id)?.MRIs.EntityToView();

            if (elem != null)
                return Ok(elem);

            return NotFound();
        }

        // GET: api/InjuriesDiseases/5/HeartUltrasounds
        [HttpGet("{id}/HeartUltrasounds")]
        public IActionResult GetWithHeartUltrasound(int id)
        {
            if (id == 0)
                return BadRequest("id is zero");

            var elem = _injuriesDiseasesRepository.GetHeartUltrasoundById(id)?.HeartUltrasounds.EntityToView();

            if (elem != null)
                return Ok(elem);

            return NotFound();
        }

        // GET: api/InjuriesDiseases/5/Radiography
        [HttpGet("{id}/Radiography")]
        public IActionResult GetWithRadiography(int id)
        {
            if (id == 0)
                return BadRequest("id is zero");

            var elem = _injuriesDiseasesRepository.GetRadiographyById(id)?.Radiographies.EntityToView();

            if (elem != null)
                return Ok(elem);

            return NotFound();
        }

        // POST: api/Patients/5/MRI
        [HttpPost("{id}/MRI")]
        public IActionResult PostWithMRI(int id, [FromForm] MRIView mriView)
        {
            try
            {

                if (id == 0)
                {
                    return BadRequest("id is zero");
                }
                if (mriView == null)
                {
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                _injuriesDiseasesRepository.InsertMRI(id, mriView.ViewToEntity());

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, string.Format("Internal server error. Message error: {0}", ex.Message));
            }
        }

        // POST: api/Patients/5/HeartUltrasound
        [HttpPost("{id}/HeartUltrasound")]
        public IActionResult PostWithHeartUltrasound(int id, [FromForm] HeartUltrasoundView heartUltrasoundView)
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

                _injuriesDiseasesRepository.InsertHeartUltrasound(id, heartUltrasoundView.ViewToEntity());

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, string.Format("Internal server error. Message error: {0}", ex.Message));
            }
        }

        // POST: api/Patients/5/Radiography
        [HttpPost("{id}/Radiography")]
        public IActionResult PostWithRadiography(int id, [FromForm] RadiographyView radiographyView)
        {
            try
            {

                if (id == 0)
                {
                    return BadRequest("id is zero");
                }
                if (radiographyView == null)
                {
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                _injuriesDiseasesRepository.InsertRadiography(id, radiographyView.ViewToEntity());

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, string.Format("Internal server error. Message error: {0}", ex.Message));
            }
        }

        // PUT: api/InjuriesDiseases
        [HttpPut]
        public async Task<IActionResult> Put([FromForm] InjuriesDiseasesView injuriesDiseasesView)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");

                await _uploadFileAndSavePath.UloadFile(injuriesDiseasesView);

                if (_injuriesDiseasesRepository.UpdateFull(injuriesDiseasesView.ViewToEntity()))
                    return Ok();

                return NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var elem = _injuriesDiseasesRepository.GetBy(t => t.Id == id);

            if (elem != null)
            {
                _injuriesDiseasesRepository.Delete(elem);
                return Ok();
            }

            return NotFound();
        }
    }
}
