using MedicalappointmentApp.Persistance.Base;
using MedicalappointmentApp.Persistance.Context;
using MedicalappointmentApp.Persistance.Interfaces.User;
using MedicalappointmentApp.Persistance.Models.User;
using MedicalAppointmentApp.Domain.Entities.User;
using MedicalAppointmentApp.Domain.Result;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MedicalappointmentApp.Persistance.Repositories.User
{
    public sealed class UsersRepository(MedicalContext medicalContext,
                          ILogger<UsersRepository> logger) : BaseRepository<Users>(medicalContext), IUsersRepository

    {
        private readonly MedicalContext _medicalContext = medicalContext;
        private readonly ILogger<UsersRepository> logger = logger;


        public async override Task<OperationResult> Save(Users entity)
        {
            OperationResult operationResult = new OperationResult();

            if (entity != null)
            {
                operationResult.Success = false;
                operationResult.Message = "La entidad es requerida.";
                return operationResult;
            }

            if (string.IsNullOrEmpty(entity.FirstName))
            {
                operationResult.Success = false;
                operationResult.Message = "El nombre es requerido.";
                return operationResult;
            }
            if (entity.FirstName.Length > 100)
            {
                operationResult.Success = false;
                operationResult.Message = "El Nombre no puede ser mayor a 50 caracteres.";
                return operationResult;
            }
            if (string.IsNullOrWhiteSpace(entity.LastName))
            {
                operationResult.Success = false;
                operationResult.Message = "El apellido es requerido.";
                return operationResult;
            }
            if (entity.LastName.Length > 100)
            {
                operationResult.Success = false;
                operationResult.Message = "El Apellido no puede ser mayor a 50 caracteres.";
                return operationResult;
            }
            if (string.IsNullOrWhiteSpace(entity.Email))
            {
                operationResult.Success = false;
                operationResult.Message = "El correo electrónico es requerido.";
                return operationResult;
            }
            if (entity.Email.Length > 225)
            {
                operationResult.Success = false;
                operationResult.Message = "El correo electrónico no puede ser mayor a 225 caracteres. ";
                return operationResult;
            }
            if (string.IsNullOrWhiteSpace(entity.Password))
            {
                operationResult.Success = false;
                operationResult.Message = "La contraseña es requerida.";
                return operationResult;
            }
            if (entity.Password.Length > 225)
            {
                operationResult.Success = false;
                operationResult.Message = "La contraseña no puede ser mayor a 225 caracteres. ";
                return operationResult;
            }
            if (entity.RoleID == 0)
            {
                operationResult.Success = false;
                operationResult.Message = "El rol es requerido.";
                return operationResult;
            }

            if (await base.Exists(user => user.Email == entity.Email))
            {
                operationResult.Success = false;
                operationResult.Message = "Ya existe un usuario con este correo electrónico.";
                return operationResult;
            }
            return operationResult;



        }
        public async override Task<OperationResult> Update(Users entity)
        {
            OperationResult operationResult = new OperationResult();

            // Validar que la entidad no sea nula
            if (entity == null)
            {
                operationResult.Success = false;
                operationResult.Message = "La entidad User es requerida.";
                return operationResult;
            }

            // Validar que el UserID sea válido
            if (entity.UserID <= 0)
            {
                operationResult.Success = false;
                operationResult.Message = "El ID de usuario no es válido.";
                return operationResult;
            }

            // Validar FirstName
            if (string.IsNullOrWhiteSpace(entity.FirstName))
            {
                operationResult.Success = false;
                operationResult.Message = "El nombre es requerido.";
                return operationResult;
            }

            
            if (string.IsNullOrWhiteSpace(entity.LastName))
            {
                operationResult.Success = false;
                operationResult.Message = "El apellido es requerido.";
                return operationResult;
            }

            if (string.IsNullOrWhiteSpace(entity.Email))
            {
                operationResult.Success = false;
                operationResult.Message = "El correo electrónico es requerido.";
                return operationResult;
            }

            if (entity.RoleID == 0)
            {
                operationResult.Success = false;
                operationResult.Message = "El rol es requerido.";
                return operationResult;
            }

            if (await base.Exists(user => user.Email == entity.Email && user.UserID != entity.UserID))
            {
                operationResult.Success = false;
                operationResult.Message = "Ya existe otro usuario con este correo electrónico.";
                return operationResult;
            }


            try
            {
                Users? usersToUpdate = await _medicalContext.Users.FindAsync(entity.UserID);

                usersToUpdate.UserID = entity.UserID;
                usersToUpdate.Email = entity.Email;
                usersToUpdate.FirstName = entity.FirstName;
                usersToUpdate.LastName = entity.LastName;

                operationResult = await base.Update(usersToUpdate);

            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Error actualizando el usuario.";
                logger.LogError(operationResult.Message, ex.ToString());
            }

            return operationResult;
        }
        public async override Task<OperationResult> GetAll()
        {
            OperationResult operationResult = new OperationResult();

            try
            {
                operationResult.Data = await (from user in this._medicalContext.Users
                                              where user.IsActive == true
                                              orderby user.CreatedAt descending
                                              select new UsersModel()
                                              {
                                                  UserID = user.UserID,
                                                  Email = user.Email,
                                                  FirstName = user.FirstName,
                                                  LastName = user.LastName,
                                                  Password = user.Password,
                                                  RoleID = user.RoleID,
                                                  CreatedAt = user.CreatedAt,
                                                  UpdatedAt = user.UpdatedAt

                                              }).ToListAsync();
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Error obteniendo los usuarios";
                logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;

        }

        public override async Task<OperationResult> GetEntityBy(int Id)
        {
            OperationResult operationResult = new OperationResult();
            try
            {
                operationResult.Data = await (from user in _medicalContext.Users
                                              where user.IsActive == true
                                              && user.UserID == Id
                                              select new UsersModel()
                                              {
                                                  UserID = user.UserID,
                                                  Email = user.Email,
                                                  FirstName = user.FirstName,
                                                  LastName = user.LastName,
                                                  Password = user.Password,
                                                  RoleID = user.RoleID,
                                                  CreatedAt = user.CreatedAt,
                                                  UpdatedAt = user.UpdatedAt
                                              }).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {

                operationResult.Success = false;
                operationResult.Message = "Error obteniendo el usuario.";
                logger.LogError(operationResult.Message, ex.ToString());
            }

            return operationResult;
        }
        public async override Task<OperationResult> Remove(Users entity)
        {
            OperationResult operationResult = new OperationResult();

            if (entity == null)
            {
                operationResult.Success = false;
                operationResult.Message = "La entidad es requerida.";
                return operationResult;
            }
            if (entity.UserID <= 0)
            {
                operationResult.Success = false;
                operationResult.Message = "Se requiere enviar el id del usuario para realizar la operación";
                return operationResult;
            }
            try
            {
                Users? userToRemove = await _medicalContext.Users.FirstOrDefaultAsync(a => a.UserID == entity.UserID);

                if (userToRemove == null)
                {
                    operationResult.Success = false;
                    operationResult.Message = "El usuario no existe";
                    return operationResult;
                }
                userToRemove.IsActive = false;
                userToRemove.UpdatedAt = entity.UpdatedAt;

                await base.Update(userToRemove);
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Error desactivando el usuario.";
                logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }

    }
}
