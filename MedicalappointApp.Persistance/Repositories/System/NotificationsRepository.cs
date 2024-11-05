using MedicalappointmentApp.Persistance.Base;
using MedicalappointmentApp.Persistance.Context;
using MedicalappointmentApp.Persistance.Interfaces.System;
using MedicalAppointmentApp.Domain.Entities.System;
using MedicalAppointmentApp.Domain.Result;
using Microsoft.Extensions.Logging;


namespace MedicalappointmentApp.Persistance.Repositories.System
{
    public sealed class NotificationsRepository (MedicalContext medicalContext,
                        ILogger<NotificationsRepository> logger) : BaseRepository<Notifications>(medicalContext), INotificationsRepository
    {
        private readonly MedicalContext _medicalContext = medicalContext;
        private readonly ILogger<NotificationsRepository> logger = logger;

        public override Task<OperationResult> Save(Notifications entity)
        {
            return base.Save(entity);
        }
    }
}
