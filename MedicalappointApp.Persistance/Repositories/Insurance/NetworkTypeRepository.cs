using MedicalappointmentApp.Persistance.Base;
using MedicalappointmentApp.Persistance.Context;
using MedicalappointmentApp.Persistance.Interfaces.Insurance;
using MedicalAppointmentApp.Domain.Entities.Insurance;
using MedicalAppointmentApp.Domain.Result;
using Microsoft.Extensions.Logging;


namespace MedicalappointmentApp.Persistance.Repositories.Insurance
{
    public sealed class NetworkTypeRepository : BaseRepository<NetworkType>, INetworkTypeRepository

    {
        private readonly MedicalContext context;
        private readonly ILogger<NetworkTypeRepository> logger;

        public NetworkTypeRepository(MedicalContext context, ILogger<NetworkTypeRepository> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }
        public override Task<OperationResult> Save(NetworkType entity)
        {
            return base.Save(entity);
        }
    }
}
