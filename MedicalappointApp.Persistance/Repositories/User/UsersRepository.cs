using MedicalappointmentApp.Persistance.Base;
using MedicalappointmentApp.Persistance.Context;
using MedicalappointmentApp.Persistance.Interfaces.User;
using MedicalAppointmentApp.Domain.Entities.User;
using Microsoft.Extensions.Logging;

namespace MedicalappointmentApp.Persistance.Repositories.User
{
    public sealed class UsersRepository : BaseRepository<Users>, IUsersRepository

    {
        private readonly MedicalContext context;
        private readonly ILogger<UsersRepository> logger;

        public UsersRepository(MedicalContext context, ILogger<UsersRepository> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }
    }
}
