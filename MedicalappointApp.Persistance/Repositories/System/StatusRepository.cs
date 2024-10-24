using MedicalappointmentApp.Persistance.Base;
using MedicalappointmentApp.Persistance.Context;
using MedicalappointmentApp.Persistance.Interfaces.System;
using MedicalAppointmentApp.Domain.Entities.System;
using Microsoft.Extensions.Logging;

namespace MedicalappointmentApp.Persistance.Repositories.System
{
    public class StatusRepository : BaseRepository<Status>, IStatusRepository
    {
        private readonly MedicalContext context;
        private readonly ILogger<StatusRepository> logger;

        public StatusRepository(MedicalContext context, ILogger<StatusRepository> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }
    }
}
