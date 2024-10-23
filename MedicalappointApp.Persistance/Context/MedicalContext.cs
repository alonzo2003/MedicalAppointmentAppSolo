

using MedicalAppointApp.Domain.Entities.Appointment;
using MedicalAppointmentApp.Domain.Entities.Insurance;
using MedicalAppointmentApp.Domain.Entities.Medical;
using MedicalAppointmentApp.Domain.Entities.System;
using MedicalAppointmentApp.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace MedicalappointmentApp.Persistance.Context
{
    public partial class MedicalContext: DbContext
    {
        public MedicalContext(DbContextOptions<MedicalContext> options) : base(options) 
        {

        }

        #region "Appointment Entities"
        public DbSet<Appointments> Appointments { get; set; }

        public DbSet<DoctorAvailability> DoctorAvailability { get; set; }
        #endregion

        #region "Insurance Entities"
        public DbSet<InsuranceProviders> InsuranceProviders { get; set; }

        public DbSet<NetworkType>  networkTypes { get; set; }


        #endregion

        #region "Medical Entities"

        public DbSet<AvailabilityModes> AvailabilityModes { get; set; }

        public DbSet<MedicalRecords>  MedicalRecords { get; set; }

        public DbSet<Specialties> Specialties { get; set; }

        #endregion
        
        #region "System Entities"
        public DbSet<Notifications> Notifications { get; set; }

        public DbSet<Roles> Roles { get; set; }

        public DbSet<Status> Statuss { get; set; }

        #endregion

        #region "User Entities"

        public DbSet<Doctors> Doctors { get; set; }

        public DbSet<Patients> Patients { get; set; }

        public DbSet<Users> Users { get; set; }

        #endregion
    }
}
