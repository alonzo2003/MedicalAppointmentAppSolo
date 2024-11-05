
using MedicalappointmentApp.Persistance.Base;
using MedicalappointmentApp.Persistance.Context;
using MedicalappointmentApp.Persistance.Interfaces.User;
using MedicalAppointmentApp.Domain.Entities.User;
using MedicalAppointmentApp.Domain.Result;
using Microsoft.Extensions.Logging;

namespace MedicalappointmentApp.Persistance.Repositories.User
{
    public class PatientsRepository (MedicalContext medicalContext, 
                   ILogger<PatientsRepository> logger): BaseRepository<Patients> (medicalContext), IPatientsRepository
    {
        private readonly MedicalContext _medcalContext = medicalContext;
        private readonly ILogger<PatientsRepository> logger = logger;

        public async override Task<OperationResult> Save(Patients entity)
        {
            return await base.Save(entity);
        }


    }
}
