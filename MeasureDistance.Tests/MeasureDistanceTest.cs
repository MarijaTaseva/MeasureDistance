using MeasureDistance.Controllers;
using MeasureDistance.Domain.Models;
using MeasureDistance.Interfaces;
using Moq;
using System;
using Xunit;

namespace MeasureDistance.Tests
{
    public class MeasureDistanceTest
    {
        [Fact]
        public async void Should_ReturnAValidResult_When_AirportDataIsReturned()
        {
            // Arrange
            var mock = new Mock<IMeasureDistanceService>();
            mock.Setup(service => service.Get("AMS", "SKP")).ReturnsAsync(GetValidDistance());
            var controller = new MeasureDistanceController(mock.Object);

            // Act
            var result = await controller.Get("AMS", "SKP");

            // Assert
            Assert.IsType<DistanceDTO>(result);
        }

        [Fact]
        public async void Should_ReturnErrorMessage_When_ServerIsNotResponding()
        {
            // Arrange
            var mockRepo = new Mock<IMeasureDistanceService>();
            mockRepo.Setup(repo => repo.Get("", "")).ReturnsAsync(GetInvalidDistance());
            var controller = new MeasureDistanceController(mockRepo.Object);

            // Act
            var result = await controller.Get("", "");

            // Assert
            Assert.NotNull(result.ErrorMessage);
        }


        private DistanceDTO GetValidDistance()
        {
            DistanceDTO _distance;
            _distance = new DistanceDTO()
            {
                FirstAirportName = "Amsterdam",
                SecondAirportName = "Skopje",
                Distance = 1063.61
            };
            return _distance;
        }
        private DistanceDTO GetInvalidDistance()
        {
            DistanceDTO _distance;
            _distance = new DistanceDTO()
            {
                FirstAirportName = "",
                SecondAirportName = "",
                Distance = 0.00,
                ErrorMessage = "Something happened, please try again later."
            };
            return _distance;
        }
    }
}
