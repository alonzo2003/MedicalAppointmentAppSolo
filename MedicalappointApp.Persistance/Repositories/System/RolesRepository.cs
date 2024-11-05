using MedicalappointmentApp.Persistance.Base;
using MedicalappointmentApp.Persistance.Context;
using MedicalappointmentApp.Persistance.Interfaces.System;
using MedicalAppointmentApp.Domain.Entities.System;
using MedicalAppointmentApp.Domain.Result;
using Microsoft.Extensions.Logging;

namespace MedicalappointmentApp.Persistance.Repositories.System
{
    public sealed class RolesRepository(MedicalContext medicalContext,
        ILogger<RolesRepository> logger)  : BaseRepository<Roles>(medicalContext), IRolesRepository

    {
        private readonly MedicalContext _medicalContext = medicalContext;   
        private readonly ILogger<RolesRepository> logger = logger;

        public override Task<OperationResult> Save(Roles entity)
        {
            return base.Save(entity);
        }
    }
}
