using MedicalappointmentApp.Persistance.Context;
using MedicalAppointmentApp.Domain.Repositories;
using MedicalAppointmentApp.Domain.Result;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MedicalappointmentApp.Persistance.Base
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly MedicalContext _medicalContext;
        private DbSet<TEntity> entities;

        public BaseRepository(MedicalContext medicalContext)
        {
            _medicalContext = medicalContext;
            this.entities = _medicalContext.Set<TEntity>();
        }
        public virtual async Task<OperationResult> Exists(Expression<Func<TEntity, bool>> filter)
        {
            OperationResult result = new OperationResult();

            try
            {
                var exists = await this.entities.AnyAsync(filter);
                result.Data = exists;
            }
            catch (Exception ex)
            {
                result.Success = false;

                result.Message = $" Ocurrió un error {ex.Message} verificando que existe el registro";
            }

            return result;
        }

        public virtual async Task<OperationResult> GetAll()
        {
            OperationResult result = new OperationResult();
            try
            {
                var datos =  await this.entities.ToListAsync();
                result.Data = datos;

            }
            catch (Exception ex)
            {
                result.Success = false;

                result.Message = $" Ocurrió un error {ex.Message} obteniendo los datos";
            }

            return result;

        }

        public virtual async Task<OperationResult> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            OperationResult result = new OperationResult();

            try
            {
                var datos = await this.entities.Where(filter).ToListAsync();
                result.Data = datos;
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Ocurrió un error {ex.Message} obteniendo los datos.";
            }

            return result;
        }

        public virtual async Task<OperationResult> GetEntityBy(int Id)
        {
            OperationResult result = new OperationResult();
            try
            {
                var entity = await this.entities.FindAsync(Id);
                result.Data = entity;
            }
            catch (Exception ex)
            {
                result.Success = false;

                result.Message = $" Ocurrió un error {ex.Message} obteniendo la entidad.";
            }
            return result;
        }

        public async virtual Task<OperationResult> Remove(TEntity entity)
        {

            OperationResult result = new OperationResult();
            try
            {
                entities.Remove(entity);
                await _medicalContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $" Ocurrió un error {ex.Message} eliminando la entidad.";
            }
            return result;
        }

        public virtual async Task<OperationResult> Save(TEntity entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                entities.Add(entity);
                await _medicalContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $" Ocurrió un error {ex.Message} agregando la entidad.";
            }
            return result;
        }

        public virtual async Task<OperationResult> Update(TEntity entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                entities.Update(entity);
                await _medicalContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $" Ocurrió un error {ex.Message} actualizando la entidad.";
            }
            return result;
        }

        Task<bool> IBaseRepository<TEntity>.Exists(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
