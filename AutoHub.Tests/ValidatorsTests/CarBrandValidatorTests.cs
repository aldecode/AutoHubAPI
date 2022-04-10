﻿using AutoFixture;
using AutoHub.API.Models.CarBrandModels;
using AutoHub.API.Validators;
using FluentValidation.TestHelper;
using Xunit;

namespace AutoHub.Tests.ValidatorsTests
{
    public class CarBrandValidatorTests
    {
        private readonly Fixture _fixture;
        private readonly CarBrandCreateRequestModelValidator _createValidator;
        private readonly CarBrandUpdateRequestModelValidator _updateValidator;

        public CarBrandValidatorTests()
        {
            _fixture = new Fixture();
            _createValidator = new CarBrandCreateRequestModelValidator();
            _updateValidator = new CarBrandUpdateRequestModelValidator();
        }

        [Fact]
        public void CreateBrandTestValidate_ValidModel_ShouldNotHaveError()
        {
            //Arrange
            var model = _fixture.Create<CarBrandCreateRequestModel>();

            //Act
            var result = _createValidator.TestValidate(model);

            //Assert
            result.ShouldNotHaveValidationErrorFor(x => x.CarBrandName);
        }

        [Fact]
        public void CreateBrandTestValidate_InvalidModel_ShouldHaveError()
        {
            //Arrange
            var model = new CarBrandCreateRequestModel { CarBrandName = null };

            //Act
            var result = _createValidator.TestValidate(model);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.CarBrandName);
        }

        [Fact]
        public void UpdateBrandTestValidate_ValidModel_ShouldNotHaveError()
        {
            //Arrange
            var model = _fixture.Create<CarBrandUpdateRequestModel>();

            //Act
            var result = _updateValidator.TestValidate(model);

            //Assert
            result.ShouldNotHaveValidationErrorFor(x => x.CarBrandName);
        }

        [Fact]
        public void UpdateBrandTestValidate_InvalidModel_ShouldHaveError()
        {
            //Arrange
            var model = new CarBrandUpdateRequestModel { CarBrandName = null };

            //Act
            var result = _updateValidator.TestValidate(model);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.CarBrandName);
        }
    }
}