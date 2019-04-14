using Backend.DAL.Entities.GeneralInformationEntities;

namespace Backend.DAL.Interfaces.Repositories
{
    public interface IGeneralInformationRepository : IGenericRepository<GeneralInformation>
    {
        GeneralInformation GetFluorographyById(int id);
        GeneralInformation GetVaccinationStatusById(int id);
        GeneralInformation GetSurgicalInterventionById(int id);
        void InsertFluorography(int id, Fluorography fluorography);
        void InsertVaccinationStatus(int id, VaccinationStatus vaccinationStatus);
        void InsertSurgicalIntervention(int id, SurgicalIntervention surgicalIntervention);
    }
}
