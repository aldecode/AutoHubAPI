using System.Collections.Generic;
using AutoHub.BLL.Interfaces;
using AutoHub.DAL.Entities;
using AutoHub.DAL.Interfaces;

namespace AutoHub.BLL.Services
{
    public class CarColorService : ICarColorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CarColorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<CarColor> GetAll()
        {
            return _unitOfWork.CarColors.GetAll();
        }

        public CarColor GetById(int id)
        {
            var carColor = _unitOfWork.CarColors.GetById(id);

            return carColor ?? null;
        }

        public CarColor CreateCarColor(CarColor carColorModel)
        {
            _unitOfWork.CarColors.Add(new CarColor
            {
                CarColorName = carColorModel.CarColorName
            });
            _unitOfWork.Commit();
            return carColorModel;
        }

        public bool Exist(string carColorName)
        {
            var carColor = _unitOfWork.CarColors.Find(color => color.CarColorName == carColorName);
            return carColor != null;
        }
    }
}