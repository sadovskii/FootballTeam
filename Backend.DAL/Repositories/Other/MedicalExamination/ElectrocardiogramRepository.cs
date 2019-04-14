using Backend.DAL.EF;
using Backend.DAL.Entities.Common.InstrumentalStudies;
using Backend.DAL.Interfaces.Repositories.Other.MedicalExamination;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.DAL.Repositories.Other.MedicalExamination
{
    public class ElectrocardiogramRepository : GenericRepository<ApplicationContext, Electrocardiogram>, IElectrocardiogramRepository
    {
        public ElectrocardiogramRepository(ApplicationContext context) : base(context) { }
    }
}
