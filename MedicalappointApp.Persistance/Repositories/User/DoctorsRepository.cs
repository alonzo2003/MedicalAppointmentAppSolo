
using MedicalappointmentApp.Persistance.Base;
using MedicalappointmentApp.Persistance.Context;
using MedicalappointmentApp.Persistance.Interfaces.User;
using MedicalAppointmentApp.Domain.Entities.User;
using Microsoft.Extensions.Logging;

namespace MedicalappointmentApp.Persistance.Repositories.User
{
    public sealed class DoctorsRepository : BaseRepository<Doctors>, IDoctorsRepository

    {
        private readonly MedicalContext context;
        private readonly ILogger<DoctorsRepository> logger;

        public DoctorsRepository(MedicalContext context, ILogger<DoctorsRepository> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }
    }
}
