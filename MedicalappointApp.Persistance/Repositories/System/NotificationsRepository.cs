using MedicalappointmentApp.Persistance.Base;
using MedicalappointmentApp.Persistance.Context;
using MedicalappointmentApp.Persistance.Interfaces.System;
using MedicalAppointmentApp.Domain.Entities.System;
using Microsoft.Extensions.Logging;


namespace MedicalappointmentApp.Persistance.Repositories.System
{
    public sealed class NotificationsRepository : BaseRepository<Notifications>, INotificationsRepository
    {
        private readonly MedicalContext context;
        private readonly ILogger<NotificationsRepository> logger;

        public NotificationsRepository(MedicalContext context, ILogger<NotificationsRepository> logger) : base(context) 
        {
            this.context = context;
            this.logger = logger;
        }
    }
}
