using AutoMapper;
using FluentValidation;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TanksProject2.DAL.Interfaces;
using TanksProject2.Domain.Dtos.UserDtos;
using TanksProject2.Domain.Models.Servise;
using TanksProject2.Domain.Models.UserModel;
using TanksProject2.Servise.IServise;

namespace TanksProject2.Servise.Servise
{
    public class UserAccountServise : IUserAccountServise
    {
        private readonly ISendRegistrationEmail sendEmail;
        private readonly IMapper mapper;
        private readonly IValidator<UserRegistrationDtos> _validator;
       
        private readonly IUserAccountInterface _user;
        public UserAccountServise(IUserAccountInterface _user, IMapper mapper, ISendRegistrationEmail sendEmail, IValidator<UserRegistrationDtos> _validator)
        {
            this._user = _user;
            this.mapper = mapper;
            this.sendEmail = sendEmail;
            this._validator = _validator;
        }

        public async Task<ServiseResponse<bool>> DeleteUserAccount(int id)
        {
            var servise = new ServiseResponse<bool>();
            try
            {
                UserAccount userAccount = await _user.Get(id);
                if(userAccount == null)
                {
                    servise.Description = "Прльзователь не найден";
                    servise.StatusCode = Domain.Enum.StatusCode.NotFound;
                }
                else
                {
                    bool result = await _user.Delete(userAccount);
                    if(result == true)
                    {
                        servise.Description = "Учетная запись удалена";
                        servise.StatusCode = Domain.Enum.StatusCode.OK;
                    }
                    else
                    {
                        servise.Description = "Произошла ошибка при удалении пользователя";
                        servise.StatusCode = Domain.Enum.StatusCode.BadRequest;
                    }
                }
            }
            catch(Exception ex)
            {
                servise.Description = $"[DeleteUserAccount] : {ex.Message}";
                servise.StatusCode = Domain.Enum.StatusCode.InternalServerError;
            }
            return servise;
        }

        public async Task<ServiseResponse<UserDtos>> EditUserAccount(int id, UserRegistrationDtos userRegistrationDtos)
        {
            var servise = new ServiseResponse<UserDtos>();
            try
            {
                var user = await _user.Get(id);
                if(user==null)
                {
                    servise.Description = "Пользователь не найден";
                    servise.StatusCode = Domain.Enum.StatusCode.NotFound;
                }
                else
                {
                    user.Name = userRegistrationDtos.Name;
                    user.Email = userRegistrationDtos.Email;
                    user.Password = userRegistrationDtos.Password;
                    var us = await _user.Update(user);

                    servise.Data = mapper.Map<UserDtos>(us.User);
                    servise.Description = "Данные успешно изменены";
                    servise.StatusCode = Domain.Enum.StatusCode.OK;
                }
                   

                
                
            }
            catch(Exception ex)
            {
                servise.Description = $"[EditUserAccount] : {ex.Message}";
                servise.StatusCode = Domain.Enum.StatusCode.InternalServerError;
            }
            return servise;
        }

        public async Task<ServiseResponse<UserDtos>> Login(string email, string password)
        {
            var servise = new ServiseResponse<UserDtos>();
            try
            {
                var userAccounts = await _user.GetAll();
                var userAccount = userAccounts.FirstOrDefault(x=>x.Email == email && x.Password == password);
                if(userAccount == null)
                {
                    servise.Description = "Неверный Email или Password";
                    servise.StatusCode = Domain.Enum.StatusCode.BadRequest;
                }
                else
                {
                    var user = userAccount.User;
                   
                     
                    
                    servise.Data = mapper.Map<UserDtos>(user);
                    servise.Description = "Вы вошли";
                    servise.StatusCode = Domain.Enum.StatusCode.OK;
                }
            }
            catch(Exception ex)
            {
                servise.Description = $"[Login] : {ex.Message}";
                servise.StatusCode = Domain.Enum.StatusCode.InternalServerError;

            }
            return servise;
        }

        public async Task<ServiseResponse<bool>> Register(UserRegistrationDtos userRegistrationDtos)
        {
            var validationResult = _validator.Validate(userRegistrationDtos);
            var servise = new ServiseResponse<bool>();
            try
            {
               
                
                if (validationResult.IsValid)
                {
                    bool rez = await _user.NameChek(userRegistrationDtos.NickName);
                    if (rez == true)
                    {
                        return new ServiseResponse<bool>()
                        {
                            Description = "Такой NickName уже занят",
                            StatusCode = Domain.Enum.StatusCode.BadRequest

                        };
                    }

                    UserAccount userAccount = new UserAccount()
                    {
                        Name = userRegistrationDtos.Name,
                        Email = userRegistrationDtos.Email,
                        Password = userRegistrationDtos.Password
                    };
                    User user = new User()
                    {
                        NickName = userRegistrationDtos.NickName,
                        DataRegistration = DateTime.Now,
                        UserAccountId = userAccount.Id,
                        UserAccount = userAccount
                    };
                    userAccount.User = user;
                    var res = await _user.Create(userAccount);
                    if (res == true)
                    {
                        servise.Description = "Регистрация прошла успешно";
                        servise.StatusCode = Domain.Enum.StatusCode.OK;

                        await sendEmail.FuncSendRegistrationEmail(userAccount.Email);
                    }
                    else
                    {
                        servise.Description = "Регистрация не удалась";
                        servise.StatusCode = Domain.Enum.StatusCode.BadRequest;

                    }
                }
               if(!validationResult.IsValid)
                {
                    servise.ValidMessage = new List<string>();
                    var errors = validationResult.Errors.Select(e => new
                    {
                        Field = e.PropertyName,  // Имя поля
                        Message = e.ErrorMessage  // Сообщение об ошибке
                    });
                    foreach(var item in errors)
                    {
                        servise.ValidMessage.Add(item.Message);
                    }
                    servise.StatusCode = Domain.Enum.StatusCode.BadRequest;
                    servise.Description = "Неверно введенные данные";
                }
               

            }
            catch(Exception ex)
            {
                servise.Description = $"[Register] : {ex.Message}";
                servise.StatusCode = Domain.Enum.StatusCode.InternalServerError;
            }
            return servise;
        }
    }
}
