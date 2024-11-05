using MedicalappointmentApp.Persistance.Base;
using MedicalappointmentApp.Persistance.Context;
using MedicalappointmentApp.Persistance.Interfaces.Insurance;
using MedicalAppointmentApp.Domain.Entities.Insurance;
using MedicalAppointmentApp.Domain.Result;
using Microsoft.Extensions.Logging;


namespace MedicalappointmentApp.Persistance.Repositories.Insurance
{
    public sealed class InsuranceProvidersRepository ( MedicalContext medicalContext,
                                        ILogger<InsuranceProvidersRepository> logger) : BaseRepository <InsuranceProviders>(medicalContext), IInsuranceProvidersRepository
    {
        private readonly MedicalContext _medicalContext = medicalContext;
        private readonly ILogger<InsuranceProvidersRepository> logger = logger;


        public async override Task<OperationResult> Save(InsuranceProviders entity)
        {
            OperationResult operationResult = new OperationResult();

            if (entity == null)
            { 
                operationResult.Success = false;
                operationResult.Message = "La entidad es requerida.";
                return operationResult;

            
            }

            return await base.Save(entity);
        }
        public override Task<OperationResult> Update(InsuranceProviders entity)
        {
            return base.Update(entity);
        }

        public override Task<OperationResult> GetAll()
        {
            return base.GetAll();
        }
    }  
       
    
}
