using B4.PE2.ManuVanLook.Domain.Models.ConversionEenheden;
using B4.PE2.ManuVanLook.Domain.Models.Conversions;
using B4.PE2.ManuVanLook.Domain.Services;
using B4.PE2.ManuVanLook.Domain.Validators;
using B4.PE2.ManuVanLook.UniTests.MockDataUnitTests;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace B4.PE2.ManuVanLook.UniTests
{
    public class UnitTestsFast
    {
        readonly ConversionServiceTijd serviceFast = new ConversionServiceTijd();
        readonly MockData mockData = new MockData();
        ConversionValidator convValidator = new ConversionValidator();

        // - fast unit tests
        // - arrange - act - assert unit tests
        [Fact]
        public void ConvertMinToHoursFast()
        {
            Assert.Equal(1, serviceFast.Convert(mockData.conversionNormalMTH));
        }

        [Fact]
        public void ConvertHoursToMinFast()
        {
            Assert.Equal(60, serviceFast.Convert(mockData.conversionNormalHTM));
        }

        [Fact]
        public void ConvertHoursToDaysFast()
        {
            Assert.Equal(1, serviceFast.Convert(mockData.conversionNormalHTD));
        }

        [Fact]
        public void ConvertDaysToHoursFast()
        {

            Assert.Equal(24, serviceFast.Convert(mockData.conversionNormalDTH));
        }

        [Fact]
        public void ConvertSecToMinFast()
        {
            Assert.Equal(1, serviceFast.Convert(mockData.conversionNormalSTM));
        }

        [Fact]
        public void ConvertMinToSecFast()
        {
            Assert.Equal(60, serviceFast.Convert(mockData.conversionNormalMTS));
        }


        [Fact]
        public void CheckEMptyConversion()
        {
            //arrange
            ConversionTijd conversionTijd = new ConversionTijd();

            //act
            var result = convValidator.Validate(conversionTijd);

            //assert
            Assert.True(result.Count == 1,  "the validationresult expects 1 error");

        }

        [Fact]
        public void CheckFullConversion()
        {
            //arrange
            ConversionTijd conversionTijd = new ConversionTijd { HerkomstGetal = 5, TijdseenheidHerkomst = TijdsEenheid.days, TijdseenheidToekomst = TijdsEenheid.hours };

            //act
            var result = convValidator.Validate(conversionTijd);

            //assert
            Assert.True(result.Count == 0, $"the validationresult expects 0 error, errors : {result.Count}");
        }


        [Fact]
        public void CheckDevilOrigin()
        {
            //arrange
            ConversionTijd conversionTijd = new ConversionTijd { HerkomstGetal = 666.666, TijdseenheidHerkomst = TijdsEenheid.days, TijdseenheidToekomst = TijdsEenheid.hours};

            //act
            var result = convValidator.Validate(conversionTijd);

            //assert
            Assert.True(result.Count == 1, $"the validationresult expects 1 error, errors : {result.Count}");
        }
    }
}
