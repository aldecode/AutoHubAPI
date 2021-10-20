using System.Collections.Generic;
using AutoHub.BLL.Interfaces;
using AutoHub.DAL.Entities;
using AutoHub.DAL.Interfaces;

namespace AutoHub.BLL.Services
{
    public class CarBrandService : ICarBrandService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CarBrandService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IEnumerable<CarBrand> GetAll()
        {
            return _unitOfWork.CarBrands.GetAll();
        }

        public CarBrand GetById(int id)
        {
            var carBrand = _unitOfWork.CarBrands.GetById(id);

            return carBrand ?? null;
        }

        public CarBrand CreateCarBrand(CarBrand carBrandModel)
        {
            _unitOfWork.CarBrands.Add(new CarBrand
            {
                CarBrandName = carBrandModel.CarBrandName
            });
            _unitOfWork.Commit();
            return carBrandModel;
        }

        public bool Exist(string carBrandName)
        {
            var carBrand = _unitOfWork.CarBrands.Find(brand => brand.CarBrandName == carBrandName);
            return carBrand != null;
        }
    }
}