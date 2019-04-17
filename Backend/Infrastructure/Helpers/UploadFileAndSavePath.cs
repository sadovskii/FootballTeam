using Backend.BLL.Interfaces;
using Backend.Views.Components;
using Backend.Views.InjuriesDiseasesEntities.Components;
using Backend.Views.MedicalExaminationEntities.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Helpers
{
    public class UploadFileAndSavePath
    {
        private readonly IImageHandler _imageHandler;

        public UploadFileAndSavePath(IImageHandler imageHandler)
        {
            _imageHandler = imageHandler;
        }

        public async Task UloadFile(MedicalExaminationView medicalExamination)
        {
            if(medicalExamination.BloodChemistryAnalyses != null)
                foreach (var a in medicalExamination.BloodChemistryAnalyses)
                    if (a.File != null)
                        a.Info = await _imageHandler.UploadImagePath(a.File);

            if (medicalExamination.Electrocardiograms != null)
                foreach (var a in medicalExamination.Electrocardiograms)
                    if (a.File != null)
                        a.Info = await _imageHandler.UploadImagePath(a.File);

            if (medicalExamination.GeneralBloodAnalyses != null)
                foreach (var a in medicalExamination.GeneralBloodAnalyses)
                    if (a.File != null)
                        a.Info = await _imageHandler.UploadImagePath(a.File);

            if (medicalExamination.GeneralUrineAnalyses != null)
                foreach (var a in medicalExamination.GeneralUrineAnalyses)
                    if (a.File != null)
                        a.Info = await _imageHandler.UploadImagePath(a.File);
        }

        public async Task UloadFile(InjuriesDiseasesView injuriesDiseases)
        {
            if (injuriesDiseases.MRIs != null)
                    foreach (var a in injuriesDiseases.MRIs)
                    if (a.File != null)
                        a.Info = await _imageHandler.UploadImagePath(a.File);

            if (injuriesDiseases.CommonUltrasounds != null)
                    foreach (var a in injuriesDiseases.CommonUltrasounds)
                    if (a.File != null)
                        a.Info = await _imageHandler.UploadImagePath(a.File);

            if (injuriesDiseases.Radiographies != null)
                foreach (var a in injuriesDiseases.Radiographies)
                    if (a.File != null)
                        a.Info = await _imageHandler.UploadImagePath(a.File);
        }

        public async Task UloadFile(PatientView patient)
        {
            if (patient.File != null)
                patient.Photo = await _imageHandler.UploadImagePath(patient.File);
        }
    }
}
