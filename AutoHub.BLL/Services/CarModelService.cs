using System.Collections.Generic;
using AutoHub.BLL.Interfaces;
using AutoHub.DAL.Entities;
using AutoHub.DAL.Interfaces;

namespace AutoHub.BLL.Services
{
    public class CarModelService : ICarModelService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CarModelService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<CarModel> GetAll()
        {
            return _unitOfWork.CarModels.GetAll();
        }

        public CarModel GetById(int id)
        {
            var carModel = _unitOfWork.CarModels.GetById(id);
            return carModel;
        }

        public CarModel CreateCarModel(CarModel carModelModel)
        {
            _unitOfWork.CarModels.Add(carModelModel);
            _unitOfWork.Commit();
            return carModelModel;
        }

        public CarModel UpdateCarModel(CarModel carModelModel)
        {
            var carModel = _unitOfWork.CarModels.GetById(carModelModel.CarModelId);
            carModel.CarModelName = carModelModel.CarModelName;

            _unitOfWork.CarModels.Update(carModelModel);
            _unitOfWork.Commit();

            return carModelModel;
        }

        public bool Exist(string carModelName)
        {
            return _unitOfWork.CarModels.Any(model => model.CarModelName == carModelName);
        }
    }
}