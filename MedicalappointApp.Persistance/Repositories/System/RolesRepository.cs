using MedicalappointmentApp.Persistance.Base;
using MedicalappointmentApp.Persistance.Context;
using MedicalappointmentApp.Persistance.Interfaces.System;
using MedicalAppointmentApp.Domain.Entities.System;
using Microsoft.Extensions.Logging;


namespace MedicalappointmentApp.Persistance.Repositories.System
{
    public sealed class RolesRepository : BaseRepository<Roles>, IRolesRepository

    {
        private readonly MedicalContext context;
        private readonly ILogger<RolesRepository> logger;

        public RolesRepository(MedicalContext context, ILogger<RolesRepository> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }
    }
}
