using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PollIO.Api.Controllers;
using PollIO.Api.ViewModels;
using PollIO.Business.Interfaces;
using PollIO.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PollIO.Test
{
    public class PollControllerTest
    {
        PollController _controller;
        IPollService _service;
        private readonly IPollRepository _pollRepository;
        private Mock _mapper;
        INotificador notificador;

        public PollControllerTest()
        {
            _service = new PollServiceFake();
            //_mapper = new Mock<IMapper>();
            //_controller = new PollController(_pollRepository, _mapper, _service,notificador);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            //Arrange
            var poll = new PollDto
            {
                Id = 7,
                Poll_description = "Testando poll 7",
                Options = new List<OptionPollDto>
                {
                    new OptionPollDto
                    {
                        Description = "Opção 7",
                        Id = 3,
                        Votes = "3"
                    }
                }
            };

            // Act
            var okResult = _controller.Adicionar(poll);

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
    }
}
