using MedicalappointmentApp.Persistance.Base;
using MedicalappointmentApp.Persistance.Context;
using MedicalappointmentApp.Persistance.Interfaces.Medical;
using MedicalAppointmentApp.Domain.Entities.Medical;
using MedicalAppointmentApp.Domain.Result;
using Microsoft.Extensions.Logging;

namespace MedicalappointmentApp.Persistance.Repositories.Medical
{
    public sealed class SpecialtiesRepository (MedicalContext medicalContext,
                        ILogger<SpecialtiesRepository> logger) : BaseRepository<Specialties> (medicalContext), ISpecialtiesRepository
    {
        private readonly MedicalContext _medicalContext = medicalContext;
        private readonly ILogger<SpecialtiesRepository> logger = logger;

        public override Task<OperationResult> Save(Specialties entity)
        {
            return base.Save(entity);
        }


    }
}
