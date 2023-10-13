﻿using AutoFixture;
using AutoMapper;
using JazaniT1.Application.Admins.Dtos.Holders.Profiles;
using JazaniT1.Application.Admins.Dtos.InvestmentConcepts.Profiles;
using JazaniT1.Application.Admins.Dtos.Investments;
using JazaniT1.Application.Admins.Dtos.Investments.Profiles;
using JazaniT1.Application.Admins.Dtos.InvestmentTypes.Profiles;
using JazaniT1.Application.Admins.Dtos.MeasureUnits.Mappers;
using JazaniT1.Application.Admins.Dtos.MiningConcessions.Profiles;
using JazaniT1.Application.Admins.Dtos.PeriodTypes.Profiles;
using JazaniT1.Application.Admins.Services;
using JazaniT1.Application.Admins.Services.Implementations;
using JazaniT1.Domain.Admins.Models;
using JazaniT1.Domain.Admins.Repositories;
using Moq;

namespace JazaniT1.UnitTest.Application.Admins.Services
{
    public class InvestmentServiceTest
    {
        
        Mock<IInvestmentRepository> _mockInvestmentRepository = new Mock<IInvestmentRepository>();
        Mock<Microsoft.Extensions.Logging.ILogger<InvestmentService>> _mockILogger = new Mock<Microsoft.Extensions.Logging.ILogger<InvestmentService>>();
        IMapper _mapper;
        Fixture _fixture;

        public InvestmentServiceTest()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<InvestmentProfile>();
                c.AddProfile<MiningConcessionProfile>();
                c.AddProfile<InvestmentTypeProfile>();
                c.AddProfile<PeriodTypeProfile>();
                c.AddProfile<MiningConcessionProfile>();
                c.AddProfile<MeasureUnitMapper>();
                c.AddProfile<InvestmentConceptProfile>();
                c.AddProfile<HolderProfile>();
            });
            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            _mapper = mapperConfiguration.CreateMapper();
            _mockInvestmentRepository = new Mock<IInvestmentRepository>();
        }
        [Fact]
        public async void returnInvestmentDtoWhenFindByIdAsync()
        {

            Investment investment = _fixture.Create<Investment>();

            _mockInvestmentRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(investment);

            IInvestmentService investmentService = new InvestmentService(_mockInvestmentRepository.Object, _mapper, _mockILogger.Object);

            InvestmentDto investmentDto = await investmentService.FindByIdAsync(investment.Id);

            Assert.Equal(investment.AmountInvestd, investmentDto.AmountInvestd);
        }

        [Fact]
        public async void returnInvestmentDtoWhenFindAllAsync()
        {
            //Arrage

            IReadOnlyList<Investment> investments = _fixture.CreateMany<Investment>(5).ToList();

            _mockInvestmentRepository
                .Setup(r => r.FindAllAsync())
                .ReturnsAsync(investments);
            //Act
            IInvestmentService investmentService = new InvestmentService(_mockInvestmentRepository.Object, _mapper, _mockILogger.Object);

            IReadOnlyList<InvestmentDto> investmentDtos = await investmentService.FindAllAsync();

            //Assert
            Assert.Equal(investments.Count, investmentDtos.Count);
        }

        [Fact]
        public async void returnInvestmentDtoWhenCreateAsync()
        {
            //Arrage

            Investment investment = new()
            {
                Id = 1,
                AmountInvestd = 100,
                MiningConcessionId = 4,
                InvestmentTypeId=4,
                HolderId=4,
                State = true,
                RegistrationDate = DateTime.Now
            };

            _mockInvestmentRepository
                .Setup(r => r.SaveAsync(It.IsAny<Investment>())).ReturnsAsync(investment);


            //Act
            InvestmentSaveDto investmentSaveDto = new()
            {
                AmountInvestd = investment.AmountInvestd,
                MiningConcessionId = investment.MiningConcessionId,
                HolderId = investment.HolderId,

            };

            IInvestmentService investmentService = new InvestmentService(_mockInvestmentRepository.Object, _mapper, _mockILogger.Object);

            InvestmentDto investmentDto = await investmentService.CreateAsync(investmentSaveDto);

            //Assert
            Assert.Equal(investment.AmountInvestd, investmentDto.AmountInvestd);
        }

        [Fact]
        public async void returnInvestmentDtoWhenEditAsync()
        {
            //Arrage
            Investment investment = new()
            {
                Id = 1,
                AmountInvestd = 100,
                MiningConcessionId = 4,
                InvestmentTypeId = 4,
                HolderId = 4,
                State = true,
                RegistrationDate = DateTime.Now
            };

            _mockInvestmentRepository
                .Setup(r => r.SaveAsync(It.IsAny<Investment>())).ReturnsAsync(investment);
            _mockInvestmentRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(investment);

            //Act
            InvestmentSaveDto investmentSaveDto = new()
            {
                AmountInvestd = investment.AmountInvestd,
                MiningConcessionId = investment.MiningConcessionId,
                HolderId = investment.HolderId,

            };

            IInvestmentService investmentService = new InvestmentService(_mockInvestmentRepository.Object, _mapper, _mockILogger.Object);

            InvestmentDto investmentDto = await investmentService.EditAsync(1, investmentSaveDto);

            //Assert
            Assert.Equal(investment.Id, investmentDto.Id);
        }

        [Fact]
        public async void returnInvestmentDtoWhenDisabledAsync()
        {
            //Arrage
            int id = 1;
            Investment investment = new()
            {
                Id = 1,
                AmountInvestd = 100,
                MiningConcessionId = 4,
                InvestmentTypeId = 4,
                HolderId = 4,
                State = false,
                RegistrationDate = DateTime.Now
            };
            _mockInvestmentRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(investment);
            _mockInvestmentRepository
                .Setup(r => r.SaveAsync(It.IsAny<Investment>())).ReturnsAsync(investment);


            IInvestmentService investmentService = new InvestmentService(_mockInvestmentRepository.Object, _mapper, _mockILogger.Object);

            InvestmentDto investmentDto = await investmentService.DisabledAsync(id);

            //Assert
            Assert.Equal(investment.State, investmentDto.State);
        }
    }
}