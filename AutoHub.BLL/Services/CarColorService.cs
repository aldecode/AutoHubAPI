using System.Collections.Generic;
using System.Linq;
using AutoHub.BLL.DTOs.CarColorDTOs;
using AutoHub.BLL.Exceptions;
using AutoHub.BLL.Interfaces;
using AutoHub.DAL;
using AutoHub.DAL.Entities;
using AutoMapper;

namespace AutoHub.BLL.Services
{
    public class CarColorService : ICarColorService
    {
        private readonly AutoHubContext _context;
        private readonly IMapper _mapper;

        public CarColorService(AutoHubContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<CarColorResponseDTO> GetAll()
        {
            var colors = _context.CarColors.ToList();
            var mappedColors = _mapper.Map<IEnumerable<CarColorResponseDTO>>(colors);
            return mappedColors;
        }

        public CarColorResponseDTO GetById(int carColorId)
        {
            var color = _context.CarColors.Find(carColorId);

            if (color == null) throw new NotFoundException($"Car color with ID {carColorId} not exist");

            var mappedColor = _mapper.Map<CarColorResponseDTO>(color);
            return mappedColor;
        }

        public void Create(CarColorCreateRequestDTO createColorDTO)
        {
            var color = _mapper.Map<CarColor>(createColorDTO);
            _context.CarColors.Add(color);
            _context.SaveChanges();
        }

        public void Update(int carColorId, CarColorUpdateRequestDTO updateColorDTO)
        {
            var carColor = _context.CarColors.Find(carColorId);

            if (carColor == null) throw new NotFoundException($"Car color with ID {carColorId} not exist");

            carColor.CarColorName = updateColorDTO.CarColorName;

            _context.CarColors.Update(carColor);
            _context.SaveChanges();
        }

        public void Delete(int carColorId)
        {
            var carColor = _context.CarColors.Find(carColorId);

            if (carColor == null) throw new NotFoundException($"Car color with ID {carColorId} not exist");

            _context.CarColors.Remove(carColor);
            _context.SaveChanges();
        }
    }
}