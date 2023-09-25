using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksProject2.Domain.Dtos.TankDtos;
using TanksProject2.Domain.Models.Servise;
using TanksProject2.Domain.Models.TankModel;
using TanksProject2.Servise.IServise;
using TanksProject2.Domain.Models.TankModel.TankComponents;
using TanksProject2.DAL.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using TanksProject2.Domain.Enum;
using TanksProject2.Servise.MyConvert;

namespace TanksProject2.Servise.Servise
{
    public class TankServise : ITankServise
    {
        private readonly ITankInterface _tank;
        private readonly IMapper mapper;
        public TankServise(ITankInterface _tank, IMapper mapper)
        {
            this._tank = _tank;
            this.mapper = mapper;
            
        }
        public async Task<ServiseResponse<TankDtos>> AddTank(TankDtos tankDtos)
        {
            var servise = new ServiseResponse<TankDtos>();
            try
            {
                var tank = new Tank()
                {
                    Name = tankDtos.Name,
                    Level = tankDtos.Level,
                    Description = tankDtos.Description,
                    HP = tankDtos.HP,
                    Made = tankDtos.Made,
                    TankType = (TankType)Convert.ToInt32(tankDtos.TankType),

                    Firepower = new Firepower()
                    {
                        GunName = tankDtos.FirepowerDtos.GunName,
                        Ammunition = tankDtos.FirepowerDtos.Ammunition,
                        Damage = tankDtos.FirepowerDtos.Damage,
                        RateOfFire = tankDtos.FirepowerDtos.RateOfFire,
                    },

                    Mobility = new Mobility()
                    {
                        EnginePower = tankDtos.MobilityDtos.EnginePower,
                        SpeedForward = tankDtos.MobilityDtos.SpeedForward,
                        SpeedBack = tankDtos.MobilityDtos.SpeedBack
                    },

                    Observation = new Observation()
                    {
                        Review = tankDtos.ObservationDtos.Review,
                        CommunicationRange = tankDtos.ObservationDtos.CommunicationRange
                    },

                    
                };

                var res = await _tank.Create(tank);

                if(res == true)
                {
                    var conv = new ConvertTankToTankDtos(mapper);

                    servise.Data = conv.ConvertToTankDtos(tank);
                    servise.Description = "Танк добавлен";
                    servise.StatusCode = Domain.Enum.StatusCode.OK;
                }
                else
                {
                    servise.Description = "Возникли проблемы с добавление танка";
                    servise.StatusCode = Domain.Enum.StatusCode.BadRequest;
                }


            }
            catch(Exception ex)
            {
                servise.Description = $"[AddTank] : {ex.Message}";
                servise.StatusCode = Domain.Enum.StatusCode.InternalServerError;
            }
            return servise;
        }

        public async Task<ServiseResponse<bool>> DeleteTank(int id)
        {
            var servise = new ServiseResponse<bool>();
            try
            {
                var tank = await _tank.Get(id);
                if (tank == null)
                {
                    servise.Description = "Танк не найден";
                    servise.StatusCode = Domain.Enum.StatusCode.NotFound;
                }
                else
                {
                    var res = await _tank.Delete(tank);

                    if(res == true)
                    {
                        servise.Description = "Танк удален";
                        servise.StatusCode = Domain.Enum.StatusCode.OK;
                    }
                }

            }
            catch(Exception ex)
            {
                servise.Description = $"[DeleteTank] : {ex.Message}";
                servise.StatusCode = Domain.Enum.StatusCode.InternalServerError;

            }
            return servise;
        }

        public async Task<ServiseResponse<List<TankDtos>>> GetAllTank()
        {
            var servise = new ServiseResponse<List<TankDtos>>();
            try
            {
                var tanks = await _tank.GetAll();
                if (tanks == null)
                {
                    servise.Description = "Танки не найден";
                    servise.StatusCode = Domain.Enum.StatusCode.NotFound;
                }
                else
                {
                    var conv = new ConvertTankToTankDtos(mapper);
                    var tanksDT = new List<TankDtos>();
                    foreach (var tank in tanks)
                    {

                        tanksDT.Add(conv.ConvertToTankDtos(tank));
                    }

                    servise.Data = tanksDT;
                    servise.Description = "Танки получены";
                    servise.StatusCode = Domain.Enum.StatusCode.OK;
                    
                }    
                

            }
            catch(Exception ex)
            {
                servise.Description = $"[GetAllTank] : {ex.Message}";
                servise.StatusCode = Domain.Enum.StatusCode.InternalServerError;
            }
            return servise;
        }

        public async Task<ServiseResponse<TankDtos>> GetTank(int id)
        {
            var servise = new ServiseResponse<TankDtos>();
            try
            {
                var tank = await _tank.Get(id);
                if(tank == null)
                {
                    servise.Description = "Танк не найден";
                    servise.StatusCode = Domain.Enum.StatusCode.NotFound;
                }
                else
                {
                    var conv = new ConvertTankToTankDtos(mapper);

                    servise.Data = conv.ConvertToTankDtos(tank);
                    servise.Description = "Танк найден";
                    servise.StatusCode = Domain.Enum.StatusCode.OK;

                }
            }
            catch(Exception ex)
            {
                servise.Description = $"[GetTank] : {ex.Message}";
                servise.StatusCode = Domain.Enum.StatusCode.InternalServerError;
            }
            return servise;
        }

        public async Task<ServiseResponse<List<TankDtos>>> GetTankByName(string name)
        {
            var servise = new ServiseResponse<List<TankDtos>>();
            
            try
            {
                var tanks = await _tank.GetByName(name);
                if(tanks == null)
                {
                    servise.Description = "Танки с таким названием не найдены";
                    servise.StatusCode = Domain.Enum.StatusCode.NotFound;
                }
                else
                {
                    var conv = new ConvertTankToTankDtos(mapper);
                    int count = tanks.Count;
                    var tanksDtos = new List<TankDtos>();
                    foreach (var tank in tanks)
                    {
                        
                        tanksDtos.Add(conv.ConvertToTankDtos(tank));
                    }

                    servise.Data = tanksDtos;
                    servise.Description = $"Найдено {count} танков";
                    servise.StatusCode = Domain.Enum.StatusCode.OK;

                }
               

            }
            catch(Exception ex)
            {

                servise.Description = $"[GetTankByName] : {ex.Message}";
                servise.StatusCode = Domain.Enum.StatusCode.InternalServerError;
            }
            return servise;
        }

        public async Task<ServiseResponse<List<TankDtos>>> GetTanksByNation(string nation)
        {
            var servise = new ServiseResponse<List<TankDtos>>();
            try
            {
                var tanks = await _tank.GetByNation(nation);
                if(tanks == null)
                {
                    servise.Description = $"Танки нации {nation} не найдены";
                    servise.StatusCode = StatusCode.NotFound;   
                }
                else
                {
                    var tanksDtos = new List<TankDtos>();
                    var convertation = new ConvertTankToTankDtos(mapper);
                    foreach(var tank in tanks)
                    {
                        tanksDtos.Add(convertation.ConvertToTankDtos(tank));

                    }
                    servise.Data = tanksDtos;
                    servise.Description = $"Танки нации {nation} найдены";
                    servise.StatusCode = StatusCode.OK;
                }

            }
            catch(Exception ex)
            {
                servise.Description = $"[GetTanksByNation] : {ex.Message}";
                servise.StatusCode = StatusCode.InternalServerError;
            }
            return servise;
        }

        public async Task<ServiseResponse<List<TankDtos>>> GetTanksByType(string type)
        {
            var servise = new ServiseResponse<List<TankDtos>>();
            try
            {
                var tanks = await _tank.GetByType(type);
                if(tanks == null)
                {
                    servise.Description = $"Танков типа {type} нет";
                    servise.StatusCode = StatusCode.NotFound;
                }
                else
                {
                    var conv = new ConvertTankToTankDtos(mapper);
                    var tanksDtos = new List<TankDtos>();
                    foreach(var tank in tanks)
                    {
                        tanksDtos.Add(conv.ConvertToTankDtos(tank));
                    }
                    servise.Data = tanksDtos;
                    servise.Description = $"Найденные танки типа {type}";
                    servise.StatusCode = StatusCode.OK;
                }
            }
            catch(Exception ex)
            {
                servise.Description = $"[GetTankByName] : {ex.Message}";
                servise.StatusCode = Domain.Enum.StatusCode.InternalServerError;
            }
            return servise;
        }

        public async Task<ServiseResponse<TankDtos>> UpdateTank(int id, TankDtos tankDtos)
        {
            var servise = new ServiseResponse<TankDtos>();
            try
            {
                var tank = await _tank.Get(id);
                if(tank == null)
                {
                    servise.Description = "Танк не найден";
                    servise.StatusCode = Domain.Enum.StatusCode.NotFound;
                }
                else
                {
                    tank.Name = tankDtos.Name;
                    tank.Level = tankDtos.Level;
                    tank.Made = tankDtos.Made;
                    tank.Description = tankDtos.Description;
                    tank.TankType = (TankType)Convert.ToInt32(tankDtos.TankType);

                    tank.Firepower.GunName = tankDtos.FirepowerDtos.GunName;
                    tank.Firepower.Damage = tankDtos.FirepowerDtos.Damage;
                    tank.Firepower.Ammunition = tankDtos.FirepowerDtos.Ammunition;
                    tank.Firepower.RateOfFire = tankDtos.FirepowerDtos.RateOfFire;

                    tank.Mobility.EnginePower = tankDtos.MobilityDtos.EnginePower;
                    tank.Mobility.SpeedForward = tankDtos.MobilityDtos.SpeedForward;
                    tank.Mobility.SpeedBack = tankDtos.MobilityDtos.SpeedBack;

                    tank.Observation.Review = tankDtos.ObservationDtos.Review;
                    tank.Observation.CommunicationRange = tank.Observation.CommunicationRange;

                    var res = await  _tank.Update(tank);
                    if(res == true)
                    {
                        servise.Description = "Данные изменены";
                        servise.StatusCode = Domain.Enum.StatusCode.OK;
                    }
                    else
                    {
                        servise.Description = "Не удалось изменить данные";
                        servise.StatusCode = Domain.Enum.StatusCode.BadRequest;
                    }
                  

                }

            }
            catch(Exception ex)
            {
                servise.Description = $"[UpdateTank] : {ex.Message}";
                servise.StatusCode = Domain.Enum.StatusCode.InternalServerError;
            }
            return servise;
            
        }

        
    }
}
