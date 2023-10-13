using AutoFixture;
using AutoMapper;
using JazaniT1.Application.Soc.Dtos.Holders;
using JazaniT1.Application.Soc.Dtos.Holders.Profiles;
using JazaniT1.Application.Soc.Services;
using JazaniT1.Application.Soc.Services.Implementations;
using JazaniT1.Domain.Admins.Models;
using JazaniT1.Domain.Admins.Repositories;
using Moq;

namespace JazaniT1.UnitTest.Application.Soc.Services
{
    public class HolderServiceTest
    {
        Mock<IHolderRepository> _mockHolderRepository = new Mock<IHolderRepository>();
        Mock<Microsoft.Extensions.Logging.ILogger<HolderService>> _mockILogger = new Mock<Microsoft.Extensions.Logging.ILogger<HolderService>>();
        IMapper _mapper;
        Fixture _fixture;

        public HolderServiceTest()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<HolderProfile>();
            });
            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            _mapper = mapperConfiguration.CreateMapper();
            _mockHolderRepository = new Mock<IHolderRepository>();
        }
        [Fact]
        public async void returnHolderDtoWhenFindByIdAsync()
        {

            Holder Holder = _fixture.Create<Holder>();

            _mockHolderRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(Holder);

            IHolderService HolderService = new HolderService(_mockHolderRepository.Object, _mapper, _mockILogger.Object);

            HolderDto HolderDto = await HolderService.FindByIdAsync(Holder.Id);

            Assert.Equal(Holder.Name, HolderDto.Name);
        }

        [Fact]
        public async void returnHolderDtoWhenFindAllAsync()
        {
            //Arrage

            IReadOnlyList<Holder> Holders = _fixture.CreateMany<Holder>(5).ToList();

            _mockHolderRepository
                .Setup(r => r.FindAllAsync())
                .ReturnsAsync(Holders);
            //Act
            IHolderService HolderService = new HolderService(_mockHolderRepository.Object, _mapper, _mockILogger.Object);

            IReadOnlyList<HolderDto> HolderDtos = await HolderService.FindAllAsync();

            //Assert
            Assert.Equal(Holders.Count, HolderDtos.Count);
        }

    }
}
