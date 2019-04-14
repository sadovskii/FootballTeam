using Backend.DAL.EF;
using Backend.DAL.Entities.GeneralInformationEntities;
using Backend.DAL.Interfaces.Repositories.Other.GeneralInformation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.DAL.Repositories.Other.GeneralInformation
{
    public class VaccinationStatusRepository : GenericRepository<ApplicationContext, VaccinationStatus>, IVaccinationStatusRepository
    {
        public VaccinationStatusRepository(ApplicationContext context) : base(context) { }
    }
}
