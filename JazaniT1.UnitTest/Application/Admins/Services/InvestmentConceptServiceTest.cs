using AutoFixture;
using AutoMapper;
using JazaniT1.Application.Mc.Dtos.InvestmentConcepts;
using JazaniT1.Application.Mc.Dtos.InvestmentConcepts.Profiles;
using JazaniT1.Application.Mc.Services;
using JazaniT1.Application.Mc.Services.Implementations;
using JazaniT1.Domain.Admins.Models;
using JazaniT1.Domain.Admins.Repositories;
using Moq;

namespace JazaniT1.UnitTest.Application.Admins.Services
{

    public class InvestmentConceptServiceTest
    {
        Mock<IInvestmentConceptRepository> _mockInvestmentConceptRepository = new Mock<IInvestmentConceptRepository>();
        Mock<Microsoft.Extensions.Logging.ILogger<InvestmentConceptService>> _mockILogger = new Mock<Microsoft.Extensions.Logging.ILogger<InvestmentConceptService>>();
        IMapper _mapper;
        Fixture _fixture;

        public InvestmentConceptServiceTest() {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<InvestmentConceptProfile>();
            });
            _fixture =new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
                _mapper =mapperConfiguration.CreateMapper();
            _mockInvestmentConceptRepository = new Mock<IInvestmentConceptRepository>();
        }
        [Fact]
        public async void returnInvestmentConceptDtoWhenFindByIdAsync() { 

            InvestmentConcept investmentConcept = _fixture.Create<InvestmentConcept>();

            _mockInvestmentConceptRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(investmentConcept);

            IInvestmentConceptService investmentConceptService = new InvestmentConceptService(_mockInvestmentConceptRepository.Object, _mapper, _mockILogger.Object);

            InvestmentConceptDto investmentConceptDto = await investmentConceptService.FindByIdAsync(investmentConcept.Id);

            Assert.Equal(investmentConcept.Name, investmentConceptDto.Name);
        }

        [Fact]
        public async void returnInvestmentConceptDtoWhenFindAllAsync()
        {
            //Arrage

            IReadOnlyList<InvestmentConcept> investmentConcepts = _fixture.CreateMany<InvestmentConcept>(5).ToList();

            _mockInvestmentConceptRepository
                .Setup(r => r.FindAllAsync())
                .ReturnsAsync(investmentConcepts);
            //Act
            IInvestmentConceptService investmentConceptService = new InvestmentConceptService(_mockInvestmentConceptRepository.Object, _mapper, _mockILogger.Object);

            IReadOnlyList<InvestmentConceptDto> investmentConceptDtos = await investmentConceptService.FindAllAsync();

            //Assert
            Assert.Equal(investmentConcepts.Count, investmentConceptDtos.Count);
        }

        [Fact]
        public async void returnInvestmentConceptDtoWhenCreateAsync()
        {
            //Arrage

            InvestmentConcept investmentConcept = new()
            {
                Id = 1,
                Name = "Compromiso",
                Description ="Description",
                State =true,
                RegistrationDate = DateTime.Now
            };

            _mockInvestmentConceptRepository
                .Setup(r => r.SaveAsync(It.IsAny<InvestmentConcept>())).ReturnsAsync(investmentConcept);


            //Act
            InvestmentConceptSaveDto investmentConceptSaveDto = new()
            {
                Name = investmentConcept.Name,
                Description = investmentConcept.Description
            };

            IInvestmentConceptService investmentConceptService = new InvestmentConceptService(_mockInvestmentConceptRepository.Object, _mapper, _mockILogger.Object);

            InvestmentConceptDto investmentConceptDto = await investmentConceptService.CreateAsync(investmentConceptSaveDto);

            //Assert
            Assert.Equal(investmentConcept.Name, investmentConceptDto.Name);
        }

        [Fact]
        public async void returnInvestmentConceptDtoWhenEditAsync()
        {
            //Arrage
            int id = 1;
            InvestmentConcept investmentConcept = new()
            {
                Id = id,
                Name = "Compromiso",
                Description = "Description",
                State = true,
                RegistrationDate = DateTime.Now
            };

            _mockInvestmentConceptRepository
                .Setup(r => r.SaveAsync(It.IsAny<InvestmentConcept>())).ReturnsAsync(investmentConcept);
            _mockInvestmentConceptRepository
                .Setup(r=> r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(investmentConcept);

            //Act
            InvestmentConceptSaveDto investmentConceptSaveDto = new()
            {
                Name = investmentConcept.Name,
                Description = investmentConcept.Description
            };

            IInvestmentConceptService investmentConceptService = new InvestmentConceptService(_mockInvestmentConceptRepository.Object, _mapper, _mockILogger.Object);

            InvestmentConceptDto investmentConceptDto = await investmentConceptService.EditAsync(id,investmentConceptSaveDto);

            //Assert
            Assert.Equal(investmentConcept.Id, investmentConceptDto.Id);
        }

        [Fact]
        public async void returnInvestmentConceptDtoWhenDisabledAsync()
        {
            //Arrage
            int id = 1;
            InvestmentConcept investmentConcept = new()
            {
                Id = id,
                Name = "Compromiso",
                Description = "Description",
                State = false,
                RegistrationDate = DateTime.Now
            };
            _mockInvestmentConceptRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(investmentConcept);
            _mockInvestmentConceptRepository
                .Setup(r => r.SaveAsync(It.IsAny<InvestmentConcept>())).ReturnsAsync(investmentConcept);
            

            IInvestmentConceptService investmentConceptService = new InvestmentConceptService(_mockInvestmentConceptRepository.Object, _mapper, _mockILogger.Object);

            InvestmentConceptDto investmentConceptDto = await investmentConceptService.DisabledAsync(id);

            //Assert
            Assert.Equal(investmentConcept.State, investmentConceptDto.State);
        }
    }
}
