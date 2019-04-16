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

        public async void UloadFile(MedicalExaminationView medicalExamination)
        {
            foreach (var a in medicalExamination.BloodChemistryAnalyses)
                if (a.File != null)
                    a.Info = "images/" + await _imageHandler.UploadImagePath(a.File);

            foreach (var a in medicalExamination.Electrocardiograms)
                if (a.File != null)
                    a.Info = "images/" + await _imageHandler.UploadImagePath(a.File);

            foreach (var a in medicalExamination.GeneralBloodAnalyses)
                if (a.File != null)
                    a.Info = "images/" + await _imageHandler.UploadImagePath(a.File);

            foreach (var a in medicalExamination.GeneralUrineAnalyses)
                if (a.File != null)
                    a.Info = "images/" + await _imageHandler.UploadImagePath(a.File);

            foreach (var a in medicalExamination.Electrocardiograms)
                if (a.File != null)
                    a.Info = "images/" + await _imageHandler.UploadImagePath(a.File);
        }

        public async void UloadFile(InjuriesDiseasesView injuriesDiseases)
        {
            foreach (var a in injuriesDiseases.MRIs)
                if (a.File != null)
                    a.Info = "images/" + await _imageHandler.UploadImagePath(a.File);

            foreach (var a in injuriesDiseases.HeartUltrasounds)
                if (a.File != null)
                    a.Info = "images/" + await _imageHandler.UploadImagePath(a.File);
        }

        public async void UloadFile(PatientView patient)
        {
            if (patient.File != null)
                patient.Photo = "images/" + await _imageHandler.UploadImagePath(patient.File);
        }
    }
}
