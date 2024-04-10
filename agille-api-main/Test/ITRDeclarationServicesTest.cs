using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.Services.Commom;
using AgilleApi.Domain.ViewModel;
using Moq;
using System;
using Xunit;

namespace Test
{
    public class ITRDeclarationServicesTest
    {
        private readonly ITRDeclarationServices _sut;
        private readonly Mock<ITaxPayerDeclarationServices> _taxPayerDeclarationServicesMock;
        private readonly Mock<ITaxProcedureServices> _taxProcedureServicesMock;
        private readonly Mock<IBareLandValueServices> _bareLandValueServicesMock;
        private readonly Mock<IEntitiesServices> _entitiesServicesMock;
        public ITRDeclarationServicesTest()
        {
            _taxPayerDeclarationServicesMock = new Mock<ITaxPayerDeclarationServices>();
            _taxProcedureServicesMock = new Mock<ITaxProcedureServices>();
            _bareLandValueServicesMock = new Mock<IBareLandValueServices>();
            _entitiesServicesMock = new Mock<IEntitiesServices>();
            _sut = new ITRDeclarationServices(
                _taxProcedureServicesMock.Object,
                _taxPayerDeclarationServicesMock.Object,
                _bareLandValueServicesMock.Object,
                _entitiesServicesMock.Object
                );
        }
        [Fact]
        public void Should_Be_Instantiated()
        {
            Assert.NotNull(_sut);
        }

        [Theory]
        [InlineData(10, 5, 7.5, 0.15)]
        [InlineData(100, 50, 750, 0.15)]
        [InlineData(20, 4, 12, 0.15)]
        [InlineData(20, 4, 16, 0.2)]
        public void Should_Return_Right_Declaration(decimal environmentalPreservationArea, decimal barelandEnvironmentValue, decimal itrTotalValue, decimal aliquot)
        {
            Guid procedureId = Guid.NewGuid();
            Guid proprietyId = Guid.NewGuid();
            var year = "2022";
            var totalArea = environmentalPreservationArea;
            SetupDependencies(procedureId, proprietyId, year, barelandEnvironmentValue, environmentalPreservationArea, totalArea, aliquot);

            var report = _sut.GetITRDeclaration(procedureId);

            Assert.Equal(itrTotalValue, report.TotalITRValue);
        }

        private void SetupDependencies(Guid procedureId, Guid proprietyId, string year, decimal barelandEnvironmentValue, decimal environmentalPreservationArea, decimal totalArea, decimal aliquot)
        {
            _taxProcedureServicesMock.Setup(x => x.View(procedureId)).Returns(
                            new TaxProcedureViewModel()
                            {
                                IntimationYear = year,
                                Propriety = new()
                                {
                                    Id = proprietyId,
                                }
                            });
            _bareLandValueServicesMock.Setup(x => x.GetByYear(year))
                .Returns(new BareLandValuesViewModel()
                {
                    PreservationOfFaunaOrFlora = barelandEnvironmentValue
                });
            _taxPayerDeclarationServicesMock.Setup(x => x.GetDeclaration(year, proprietyId, It.IsAny<string>()))
                .Returns(new TaxPayerDeclarationViewModel()
                {
                    PermanentPreservationArea = environmentalPreservationArea,
                    Total = totalArea
                });
            _entitiesServicesMock.Setup(x => x.GetAliquot()).Returns(aliquot);
        }
    }
}
