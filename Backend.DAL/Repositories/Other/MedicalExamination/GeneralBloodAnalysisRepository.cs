using Backend.DAL.EF;
using Backend.DAL.Entities.Common.LaboratoryResearch;
using Backend.DAL.Interfaces.Repositories.Other.MedicalExamination;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.DAL.Repositories.Other.MedicalExamination
{
    public class GeneralBloodAnalysisRepository : GenericRepository<ApplicationContext, GeneralBloodAnalysis>, IGeneralBloodAnalysisRepository
    {
        public GeneralBloodAnalysisRepository(ApplicationContext context) : base(context) { }
    }
}
