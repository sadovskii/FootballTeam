using Backend.DAL.EF;
using Backend.DAL.Entities.Common.InstrumentalStudies;
using Backend.DAL.Interfaces.Repositories.Other.InjuriesDiseases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.DAL.Repositories.Other.InjuriesDiseases
{
    public class RadiographyRepository : GenericRepository<ApplicationContext, Radiography>, IRadiographyRepository
    {
        public RadiographyRepository(ApplicationContext context) : base(context) { }
    }
}
