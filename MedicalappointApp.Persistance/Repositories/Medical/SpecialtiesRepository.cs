using MedicalappointmentApp.Persistance.Base;
using MedicalappointmentApp.Persistance.Context;
using MedicalappointmentApp.Persistance.Interfaces.Medical;
using MedicalAppointmentApp.Domain.Entities.Medical;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalappointmentApp.Persistance.Repositories.Medical
{
    public sealed class SpecialtiesRepository : BaseRepository<Specialties>, ISpecialtiesRepository
    {
        private readonly MedicalContext context;
        private readonly ILogger<SpecialtiesRepository> logger;

        public SpecialtiesRepository(MedicalContext context, ILogger<SpecialtiesRepository> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }
        
        
    }
}
