using MedicalappointmentApp.Persistance.Base;
using MedicalappointmentApp.Persistance.Context;
using MedicalappointmentApp.Persistance.Interfaces.System;
using MedicalAppointmentApp.Domain.Entities.System;
using MedicalAppointmentApp.Domain.Result;
using Microsoft.Extensions.Logging;

namespace MedicalappointmentApp.Persistance.Repositories.System
{
    public class StatusRepository (MedicalContext medicalContext, 
        ILogger<StatusRepository> logger) : BaseRepository<Status>(medicalContext), IStatusRepository
    {
        private readonly MedicalContext _medicalContext = medicalContext;
        private readonly ILogger<StatusRepository> logger = logger;

        public async override Task<OperationResult> Save(Status entity)
        {
            return await base.Save(entity);
        }


    }
}
