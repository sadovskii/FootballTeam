using Backend.DAL.Entities.Common.InstrumentalStudies;
using Backend.DAL.Entities.InjuriesDiseasesEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.DAL.Interfaces.Repositories
{
    public interface IInjuriesDiseasesRepository : IGenericRepository<InjuriesDiseases>
    {
        InjuriesDiseases GetMRIById(int id);
        InjuriesDiseases GetHeartUltrasoundById(int id);
        InjuriesDiseases GetRadiographyById(int id);

        void InsertRadiography(int id, Radiography radiography);
        void InsertHeartUltrasound(int id, HeartUltrasound heartUltrasound);
        void InsertMRI(int id, MRI mri);

        bool UpdateFull(InjuriesDiseases injuriesDiseases);
    }
}
