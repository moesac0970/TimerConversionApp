using B4.PE2.ManuVanLook.Domain.Models;
using B4.PE2.ManuVanLook.Domain.Models.ConversionEenheden;
using B4.PE2.ManuVanLook.Domain.Models.Conversions;

namespace B4.PE2.ManuVanLook.UniTests.MockDataUnitTests
{
    public class MockData
    {

        public ConversionTijd conversionNormalDTS = new ConversionTijd { HerkomstGetal = 1, TijdseenheidHerkomst = TijdsEenheid.days, TijdseenheidToekomst = TijdsEenheid.seconds };
        public ConversionTijd conversionNormalSTD = new ConversionTijd { HerkomstGetal = 86400, TijdseenheidHerkomst = TijdsEenheid.seconds, TijdseenheidToekomst = TijdsEenheid.days };
        public ConversionTijd conversionNormalHTD = new ConversionTijd { HerkomstGetal = 24, TijdseenheidHerkomst = TijdsEenheid.hours, TijdseenheidToekomst = TijdsEenheid.days };
        public ConversionTijd conversionNormalDTH = new ConversionTijd { HerkomstGetal = 1, TijdseenheidHerkomst = TijdsEenheid.days, TijdseenheidToekomst = TijdsEenheid.hours };
        public ConversionTijd conversionNormalMTH = new ConversionTijd { HerkomstGetal = 60, TijdseenheidHerkomst = TijdsEenheid.minutes, TijdseenheidToekomst = TijdsEenheid.hours };
        public ConversionTijd conversionNormalSTM = new ConversionTijd { HerkomstGetal = 60, TijdseenheidHerkomst = TijdsEenheid.seconds, TijdseenheidToekomst = TijdsEenheid.minutes };
        public ConversionTijd conversionNormalHTM = new ConversionTijd { HerkomstGetal = 1, TijdseenheidHerkomst = TijdsEenheid.hours, TijdseenheidToekomst = TijdsEenheid.minutes };
        public ConversionTijd conversionNormalMTS = new ConversionTijd { HerkomstGetal = 1, TijdseenheidHerkomst = TijdsEenheid.minutes, TijdseenheidToekomst = TijdsEenheid.seconds };
        public ConversionTijd conversionNormalNan = new ConversionTijd { HerkomstGetal = double.NaN, TijdseenheidHerkomst = TijdsEenheid.minutes, TijdseenheidToekomst = TijdsEenheid.seconds };

    }
}
