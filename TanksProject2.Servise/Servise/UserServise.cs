using AutoMapper;
using MimeKit.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksProject2.DAL.Interfaces;
using TanksProject2.Domain.Dtos.DtosTank;
using TanksProject2.Domain.Dtos.TankDtos;
using TanksProject2.Domain.Dtos.UserDtos;
using TanksProject2.Domain.Dtos.UserTankDtos;
using TanksProject2.Domain.Models.Servise;
using TanksProject2.Domain.Models.UserTankModel;
using TanksProject2.Servise.IServise;

namespace TanksProject2.Servise.Servise
{
    public class UserServise : IUserServise
    {
        private readonly IMapper mapper;
        private readonly UserTankInterface _usertank;
        private readonly IUserAccountInterface _user;
        private readonly ITankInterface _tank;

        public UserServise(UserTankInterface _usertank,  IUserAccountInterface _user, ITankInterface _tank, IMapper mapper)
        {
            this._usertank = _usertank;
            this._user = _user;
            this._tank = _tank;
            this.mapper = mapper;
        }
        public async Task<ServiseResponse<bool>> AddTank(int userId, int tankId)
        {
            var servise = new ServiseResponse<bool>();
            try
            {
                var useraccount = await _user.Get(userId);
                var tank = await _tank.Get(tankId);
                var user = useraccount.User;
                
                if(user == null || tank == null)
                {
                   if(user == null)
                    {
                        servise.Description = "Пользователь не найден";
                        servise.StatusCode = Domain.Enum.StatusCode.NotFound;
                    }
                   if(tank == null)
                    {
                        servise.Description = "Танк не найден";
                        servise.StatusCode = Domain.Enum.StatusCode.NotFound;
                    }
                    return servise;
                    
                }
                else
                {
                    user.UserTanks  = new List<UserTank>();
                    tank.UserTanks = new List<UserTank>();
                    UserTank userTank = new UserTank()
                    {
                        
                        User = user,
                        Tank = tank
                    };
                    user.UserTanks.Add(userTank);
                    tank.UserTanks.Add(userTank);

                    var res = await _usertank.Create(userTank);
                    if (res == true)
                    {
                        servise.Description = "Танк добавлен пользователю";
                        servise.StatusCode = Domain.Enum.StatusCode.OK;
                    }
                }


            }
            catch(Exception ex)
            {
                servise.Description = $"[AddTank] : {ex.Message}";
                servise.StatusCode = Domain.Enum.StatusCode.InternalServerError;
            }
            return servise;
        }

        public async Task<ServiseResponse<bool>> DeleteTankUser(int userId, int tankId)
        {
            var servise = new ServiseResponse<bool>();
            try
            {
                var user = await _usertank.GetUserAndTanks(userId);
                var tank = user.UserTanks.FirstOrDefault(x => x.TankId == tankId);
                if(user == null || tank == null) 
                {
                    if (user == null)
                    {
                        servise.Description = "Пользователь не найден";
                        servise.StatusCode = Domain.Enum.StatusCode.NotFound;
                    }
                    if(tank == null)
                    {
                        servise.Description = "У данного пользователя нет такого танка";
                        servise.StatusCode = Domain.Enum.StatusCode.NotFound;
                    }
                }
                else
                {
                    
                    var res = await _usertank.DeleteTank(user, tank.Tank);
                    if(res == true)
                    {
                        servise.Description = "Танк удален";
                        servise.StatusCode = Domain.Enum.StatusCode.OK;
                    }
                    else
                    {
                        servise.Description = "Не удалось удалить танк";
                        servise.StatusCode = Domain.Enum.StatusCode.BadRequest;
                    }
                }

            }
            catch(Exception ex)
            {
                servise.Description = $"[DeleteTankUser] : {ex.Message}";
                servise.StatusCode = Domain.Enum.StatusCode.InternalServerError;
            }
            return servise;
        }

        public async Task<ServiseResponse<UserTankDT>> GetTanks(int userId)
        {
            var servise = new ServiseResponse<UserTankDT>();
            try
            {
                var user = await _usertank.GetUserAndTanks(userId);
                if(user == null)
                {
                    servise.Description = "Пользователь не найден";
                    servise.StatusCode = Domain.Enum.StatusCode.NotFound;
                }
                else
                {
                    var tanks = user.UserTanks.Select(x=>x.Tank).ToList();
                    var tankdtos = new List<TankDtoUser>();
                    
                   
                    foreach(var item in tanks)
                    {
                        var tankdt = mapper.Map<TankDtoUser>(item);
                        tankdtos.Add(tankdt);
                    }
                    UserTankDT userTankDt = new UserTankDT()
                    {
                        UserDto = mapper.Map<UserDtos>(user),
                        TankDtoUser = tankdtos

                    };

                    servise.Data = userTankDt;
                    servise.Description = "Танки пользователя получены";
                    servise.StatusCode = Domain.Enum.StatusCode.OK;
                }

            }
            catch(Exception ex)
            {
                servise.Description = $"[GetTanks] : {ex.Message}";
                servise.StatusCode = Domain.Enum.StatusCode.InternalServerError;
            }
            return servise;
            
        }
    }
}
