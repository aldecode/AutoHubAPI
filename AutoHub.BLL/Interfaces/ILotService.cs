﻿using System.Collections.Generic;
using AutoHub.BLL.Models;

namespace AutoHub.BLL.Interfaces
{
    public interface ILotService
    {
        IEnumerable<LotModel> GetAll();
        LotModel GetById(int id);
    }
}