using MedicalAppointApp.Domain.Entities.Appointment;
using MedicalappointmentApp.Persistance.Base;
using MedicalappointmentApp.Persistance.Context;
using MedicalappointmentApp.Persistance.Interfaces.appointment;
using MedicalAppointmentApp.Domain.Result;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;


namespace MedicalappointmentApp.Persistance.Repositories.Appointment
{
    public sealed class AppointmentsRepository : BaseRepository<Appointments>, IAppointmentsRepository
    {
        private readonly MedicalContext context;
        private readonly ILogger<AppointmentsRepository> logger;

        public AppointmentsRepository(MedicalContext context, ILogger<AppointmentsRepository> logger) : base(context) 
        {
            this.context = context;
            this.logger = logger;
        }
        public override Task<OperationResult> Save(Appointments entity)
        {
            OperationResult operationResult = new OperationResult();

            

            return base.Save(entity);
        }

        public override Task<OperationResult> Update(Appointments entity)
        {
            return base.Update(entity);
        }
        public override Task<OperationResult> Remove(Appointments entity)
        {
            return base.Remove(entity);
        }

        public override Task<OperationResult> GetAll()
        {
            return base.GetAll();
        }

        public override Task<bool> Exists(Expression<Func<Appointments, bool>> filter)
        {
            return base.Exists(filter);
        }

        public override Task<OperationResult> GetAll(Expression<Func<Appointments, bool>> filter)
        {
            return base.GetAll(filter);
        }


    }
}
