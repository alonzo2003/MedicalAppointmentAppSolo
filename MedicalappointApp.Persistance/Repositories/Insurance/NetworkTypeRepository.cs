using MedicalappointmentApp.Persistance.Base;
using MedicalappointmentApp.Persistance.Context;
using MedicalappointmentApp.Persistance.Interfaces.Insurance;
using MedicalAppointmentApp.Domain.Entities.Insurance;
using MedicalAppointmentApp.Domain.Result;
using Microsoft.Extensions.Logging;


namespace MedicalappointmentApp.Persistance.Repositories.Insurance
{
    public sealed class NetworkTypeRepository (MedicalContext medicalContext,
        ILogger<NetworkTypeRepository> logger) : BaseRepository<NetworkType>(medicalContext), INetworkTypeRepository

    {
        private readonly MedicalContext _medicalContext = medicalContext;
        private readonly ILogger<NetworkTypeRepository> logger = logger;

        
        public override Task<OperationResult> Save(NetworkType entity)
        {
            return base.Save(entity);
        }
    }
}
