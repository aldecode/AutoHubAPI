﻿using AutoHub.BusinessLogic.DTOs.CarDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoHub.BusinessLogic.Interfaces;

public interface ICarService
{
    Task<IEnumerable<CarResponseDTO>> GetAll();

    Task<CarResponseDTO> GetById(int carId);

    Task Create(CarCreateRequestDTO createCarDTO);

    Task Update(int carId, CarUpdateRequestDTO updateCarDTO);

    Task UpdateStatus(int carId, int statusId);

    Task Delete(int carId);
}
