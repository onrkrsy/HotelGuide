using HotelService.Application.Models;
using HotelService.Application.Services.Abstract;
using HotelService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using HotelService.Application.Services.Concrete;
using HotelService.Infrastructure.Repositories.Concrete;
using AutoMapper;
using HotelService.Infrastructure.Repositories.Abstract;

namespace HotelService.Test.Business
{
    public class HotelBusinessTests
    {
        private readonly Mock<IHotelRepository> _mockRepository;
        public HotelBusinessTests()
        {
           _mockRepository = new Mock<IHotelRepository>();
        }


        [Fact]
        public async Task AddHotelAsync_ValidModel_ReturnsNewHotel()
        {
            // Arrange
            var mockHotelsBusiness = new Mock<IHotelsBusiness>();
            var createHotelDto = new CreateHotelDto
            {
                AuthorizedFirstName = "Name",
                AuthorizedLastName = "LastName",
                Location = "Mugla",
                Name = "Test Hotel"
            };
            var newHotel = new Hotel
            {
                Id = Guid.NewGuid(),
                HotelName = "Test Hotel",
                AuthorizedFirstName = "Name",
                AuthorizedLastName = "LastName",
                Location = "Mugla",
            };
            mockHotelsBusiness.Setup(repo => repo.Add(It.IsAny<CreateHotelDto>())).ReturnsAsync(newHotel);

            var hotelBusiness = mockHotelsBusiness.Object;

            // Act
            var result = await hotelBusiness.Add(createHotelDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(newHotel.Id, result.Id);

        }
    
        [Fact]
        public async Task UpdateHotelAsync_ValidModel_ReturnsUpdatedHotel()
        {
            // Arrange
            var mockHotelsBusiness = new Mock<IHotelsBusiness>();
            var updateHotelDto = new UpdateHotelDto
            {
                AuthorizedFirstName = "Name",
                AuthorizedLastName = "LastName",
                Location = "Mugla",
                Name = "Test Hotel"
            };
            var updatedHotel = new Hotel
            {
                Id = Guid.NewGuid(),
                HotelName = "Updated Hotel",
                AuthorizedFirstName = "Name",
                AuthorizedLastName = "LastName",
                Location = "Mugla",
            };
            mockHotelsBusiness.Setup(repo => repo.Update(It.IsAny<UpdateHotelDto>())).ReturnsAsync(updatedHotel);

            var hotelBusiness = mockHotelsBusiness.Object;

            // Act
            var result = await hotelBusiness.Update(updateHotelDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(updatedHotel.HotelName, result.HotelName);
            // Diğer karşılaştırmaları yapın.
        }
        [Fact]
        public async Task GetHotelAsync_ExistingId_ReturnsHotel()
        {
            // Arrange
            var mockHotelsBusiness = new Mock<IHotelsBusiness>();
            var existingHotelId = Guid.NewGuid();
            var existingHotel = new Hotel
            {
                Id = existingHotelId,
                HotelName = "Test Hotel",
                // Diğer özellikleri doldurun.
            };
            mockHotelsBusiness.Setup(repo => repo.Get(existingHotelId)).ReturnsAsync(existingHotel);

            var hotelBusiness = mockHotelsBusiness.Object;

            // Act
            var result = await hotelBusiness.Get(existingHotelId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(existingHotel.Id, result.Id);
            // Diğer karşılaştırmaları yapın.
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllHotels()
        {
            // Arrange
            var hotelBusiness = new HotelBusiness(_mockRepository.Object);
            var hotels = new List<Hotel>
            {
                new Hotel { Id = Guid.NewGuid(), AuthorizedFirstName = "John", AuthorizedLastName = "Doe", HotelName = "Test Hotel 1", Location = "Test Location 1" },
                new Hotel { Id = Guid.NewGuid(), AuthorizedFirstName = "Jane", AuthorizedLastName = "Doe", HotelName = "Test Hotel 2", Location = "Test Location 2" }
            };
            _mockRepository.Setup(x => x.GetAll()).ReturnsAsync(hotels);

            // Act
            var result = await hotelBusiness.GetAll();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task Get_ShouldReturnSpecificHotel()
        {
            // Arrange
            var hotelBusiness = new HotelBusiness(_mockRepository.Object);
            var id = Guid.NewGuid();
            var hotel = new Hotel { Id = id, AuthorizedFirstName = "John", AuthorizedLastName = "Doe", HotelName = "Test Hotel", Location = "Test Location" };
            _mockRepository.Setup(x => x.Get(id)).ReturnsAsync(hotel);

            // Act
            var result = await hotelBusiness.Get(id);

            // Assert
            Assert.Equal(id, result.Id);
        }

        [Fact]
        public async Task Delete_ShouldReturnTrueForSuccessfulDelete()
        {
            // Arrange
            var hotelBusiness = new HotelBusiness(_mockRepository.Object);
            var id = Guid.NewGuid();        
            _mockRepository.Setup(x => x.Delete(id)).ReturnsAsync(true);
            // Act
            bool result = await hotelBusiness.Delete(id);

            // Assert
            _mockRepository.Verify(x => x.Delete(id), Times.Once);
            Assert.True(result); // İşlem başarılıysa true dönmeli
        }

    }
}
