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

        void InsertHeartUltrasound(int id, HeartUltrasound heartUltrasound);
        void InsertMRI(int id, MRI mri);




    }
}
