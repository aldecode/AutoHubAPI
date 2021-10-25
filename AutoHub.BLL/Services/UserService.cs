using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using AutoHub.BLL.Interfaces;
using AutoHub.DAL.Entities;
using AutoHub.DAL.Enums;
using AutoHub.DAL.Interfaces;

namespace AutoHub.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<User> GetAll()
        {
            return _unitOfWork.Users.GetAll();
        }

        public User GetById(int id)
        {
            return _unitOfWork.Users.GetById(id);
        }

        public bool Register(User userModel)
        {
            if (!IsPasswordMatchRules(userModel.Password) || !IsEmailUnique(userModel.Email))
                return false;
            _unitOfWork.Users.Add(userModel);
            _unitOfWork.Commit();
            return true;
        }

        public bool SetAdminRole(int userId)
        {
            if (!_unitOfWork.Users.Any(user => user.UserId == userId))
                return false;

            var userToUpdate = _unitOfWork.Users.Find(user => user.UserId == userId).FirstOrDefault();
            userToUpdate.UserRoleId = UserRoleEnum.Administrator;
            _unitOfWork.Users.Update(userToUpdate);
            _unitOfWork.Commit();
            return true;
        }

        public bool SetRegularRole(int userId)
        {
            if (!_unitOfWork.Users.Any(user => user.UserId == userId))
                return false;

            var userToUpdate = _unitOfWork.Users.Find(user => user.UserId == userId).FirstOrDefault();
            userToUpdate.UserRoleId = UserRoleEnum.Regular;
            _unitOfWork.Users.Update(userToUpdate);
            _unitOfWork.Commit();
            return true;
        }

        public bool Login()
        {
            throw new NotImplementedException();
        }

        public bool IsEmailUnique(string email)
        {
            return _unitOfWork.Users.Any(user => user.Email != email);
        }

        public bool IsPasswordMatchRules(string password)
        {
            var rgx = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
            return rgx.IsMatch(password);
        }

        public string HashPassword(string password)
        {
            return Convert
                .ToBase64String(HashAlgorithm.Create("sha256")
                    .ComputeHash(Encoding.UTF8.GetBytes(password)));
        }
    }
}