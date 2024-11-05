
using MedicalappointmentApp.Persistance.Base;
using MedicalappointmentApp.Persistance.Context;
using MedicalappointmentApp.Persistance.Interfaces.User;
using MedicalAppointmentApp.Domain.Entities.User;
using MedicalAppointmentApp.Domain.Result;
using Microsoft.Extensions.Logging;

namespace MedicalappointmentApp.Persistance.Repositories.User
{
    public sealed class DoctorsRepository (MedicalContext medicalContext,
        ILogger<DoctorsRepository> logger) : BaseRepository<Doctors>(medicalContext), IDoctorsRepository

    {
        private readonly MedicalContext _MedicalContext = medicalContext;
        private readonly ILogger<DoctorsRepository> logger = logger;

        public  async override Task<OperationResult> Save(Doctors entity)
        {
            return await base.Save(entity);
        }
    }
}
