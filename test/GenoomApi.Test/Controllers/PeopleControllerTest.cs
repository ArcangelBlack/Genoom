﻿using GenoomApi.Controllers;
using GenoomApi.Extensions;
using GenoomApi.Services;
using GenoomApi.Test.Repositories;
using GenoomApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;

namespace GenoomApi.Test.Controllers
{
    public class PeopleControllerTest
    {
        [Fact]
        public async Task Production_GetFamilyAsync()
        {
            var repository = RepositoryMocker.PeopleService;

            // Arrange
            var controller = new PeopleController(repository);
            var id = 1;
            // Act
            var response = await controller.GetFamilyById(id) as ObjectResult;

            // Assert
            var value = response.Value as IListModelResponse<FamilyVm>;

            Assert.False(value.DidError);

        }

        [Fact]
        public async Task Production_GetPersonAsync()
        {
            var repository = RepositoryMocker.PeopleService;
            // Arrange
            var controller = new PeopleController(repository);
            var id = 1;

            // Act
            var response = await controller.GetPersonById(id) as ObjectResult;

            // Assert
            var value = response.Value as ISingleModelResponse<PersonVm>;

            Assert.False(value.DidError);
        }


        [Fact]
        public async Task GetNonExistingPersonAsync()
        {
            var repository = RepositoryMocker.PeopleService;

            // Arrange
            var controller = new PeopleController(repository);
            var id = 0;

            // Act
            var response = await controller.GetPersonById(id) as ObjectResult;

            // Assert
            var value = response.Value as ISingleModelResponse<PersonVm>;

            Assert.False(value.DidError);
        }


        //[Fact]
        //public async Task Production_CreateProductAsync()
        //{
        //    using (var repository = RepositoryMocker.AdventureWorksRepository)
        //    {
        //        // Arrange
        //        var controller = new ProductionController(repository);

        //        var viewModel = new ProductViewModel
        //        {
        //            ProductName = String.Format("New test product {0}{1}{2}", DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond),
        //            ProductNumber = String.Format("{0}{1}{2}", DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond)
        //        };

        //        // Act
        //        var response = await controller.CreateProduct(viewModel) as ObjectResult;

        //        // Assert
        //        var value = response.Value as ISingleModelResponse<ProductViewModel>;

        //        Assert.False(value.DidError);
        //    }
        //}
    }
}
